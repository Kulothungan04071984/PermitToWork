using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Permit_to_work.Data;
using Permit_to_work.Models;
using System.Net;
using System.Net.Mail;

namespace Permit_to_work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebServicesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public class SendMailRequest
        {
            public string PermitType { get; set; }
            public int PermitId { get; set; }
        }
        public WebServicesController(ILogger<HomeController> logger, ApplicationDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        private void UpdatePermitStatus(PermitMaster permit, int totalApprovers)
        {
            int approved = 0;
            int rejected = 0;

            if (permit.FirstApproverStatus == "Approved")
                approved++;

            if (permit.SecondApproverStatus == "Approved")
                approved++;

            if (permit.ThirdApproverStatus == "Approved")
                approved++;

            if (permit.FourthApproverStatus == "Approved")
                approved++;

            if (permit.FirstApproverStatus == "Rejected")
                rejected++;

            if (permit.SecondApproverStatus == "Rejected")
                rejected++;

            if (permit.ThirdApproverStatus == "Rejected")
                rejected++;

            if (permit.FourthApproverStatus == "Rejected")
                rejected++;

            if (rejected == totalApprovers)
            {
                permit.Status = "Rejected";
            }
            else if (approved == totalApprovers)
            {
                permit.Status = "Approved";
            }
            else if (approved > 0 || rejected > 0)
            {
                permit.Status = "Partial Approved";
            }
            else
            {
                permit.Status = "Pending";
            }
        }

        private bool UpdateApproverStatus(PermitMaster permit, string token, string status)
        {
            if (permit.FirstApproverToken == token)
            {
                if (permit.FirstApproverStatus == "Approved" || permit.FirstApproverStatus == "Rejected")
                {
                    return false;
                }

                permit.FirstApproverStatus = status;
                permit.FirstApproverToken = null;
                return true;
            }

            if (permit.SecondApproverToken == token)
            {
                if (permit.SecondApproverStatus == "Approved" || permit.SecondApproverStatus == "Rejected")
                {
                    return false;
                }

                permit.SecondApproverStatus = status;
                permit.SecondApproverToken = null;
                return true;
            }

            if (permit.ThirdApproverToken == token)
            {
                if (permit.ThirdApproverStatus == "Approved" || permit.ThirdApproverStatus == "Rejected")
                {
                    return false;
                }

                permit.ThirdApproverStatus = status;
                permit.ThirdApproverToken = null;
                return true;
            }

            if (permit.FourthApproverToken == token)
            {
                if (permit.FourthApproverStatus == "Approved" || permit.FourthApproverStatus == "Rejected")
                {
                    return false;
                }

                permit.FourthApproverStatus = status;
                permit.FourthApproverToken = null;
                return true;
            }

            return false;
        }

        private bool SetApproverToken(PermitMaster permit, string token)
        {
            if (permit.FirstApproverStatus == "Pending")
            {
                permit.FirstApproverToken = token;
                return true;
            }

            else if (permit.SecondApproverStatus == "Pending")
            {
                permit.SecondApproverToken = token;
                return true;
            }

            else if (permit.ThirdApproverStatus == "Pending")
            {
                permit.ThirdApproverToken = token;
                return true;
            }

            else if (permit.FourthApproverStatus == "Pending")
            {
                permit.FourthApproverToken = token;
                return true;
            }

            return false;
        }

        [HttpGet("Approve")]
        public async Task<IActionResult> Approve(string token, string type, int id)
        {
            var permit = _context.PermitMasters.FirstOrDefault(x => x.PermitNumber == id.ToString() && x.PermitType == type &&
            (
                x.FirstApproverToken == token ||
                x.SecondApproverToken == token ||
                x.ThirdApproverToken == token ||
                x.FourthApproverToken == token
            ));

            _logger.LogInformation($"Approval request received for permit type {type} with ID {id} and token {token} and Permit id {permit?.Id}");

            if (permit == null)
                return Content("Invalid approval link.");

            bool updated = UpdateApproverStatus(permit, token, "Approved");

            if (!updated)
                return Content("Invalid or expired approval link.");

            int totalApprovers = 0;

            if (type == "Cold Work")
            {
                var coldWorkPermit = _context.ColdWorkPermits.FirstOrDefault(x => x.Id == id);

                if (coldWorkPermit != null)
                {
                    if (!string.IsNullOrWhiteSpace(coldWorkPermit.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(coldWorkPermit.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(coldWorkPermit.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(coldWorkPermit.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Hot Work")
            {
                var hotWorkPermit = _context.HotWorkPermits.FirstOrDefault(x => x.PermitId == id);

                if (hotWorkPermit != null)
                {
                    if (!string.IsNullOrWhiteSpace(hotWorkPermit.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(hotWorkPermit.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(hotWorkPermit.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(hotWorkPermit.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Work At Height")
            {
                var workAtHeight = _context.WorkAtHeightPermits.FirstOrDefault(x => x.PermitId == id);

                if (workAtHeight != null)
                {
                    if (!string.IsNullOrWhiteSpace(workAtHeight.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(workAtHeight.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(workAtHeight.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(workAtHeight.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Lifting Operation")
            {
                var liftingOperation = _context.LiftingOperationPermits.FirstOrDefault(x => x.PermitId == id);

                if (liftingOperation != null)
                {
                    if (!string.IsNullOrWhiteSpace(liftingOperation.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(liftingOperation.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(liftingOperation.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(liftingOperation.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Electrical Isolation")
            {
                var electricalIsolation = _context.ElectricalIsolationPermits.FirstOrDefault(x => x.PermitId == id);

                if (electricalIsolation != null)
                {
                    if (!string.IsNullOrWhiteSpace(electricalIsolation.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(electricalIsolation.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(electricalIsolation.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(electricalIsolation.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Confined Space")
            {
                var confinedSpace = _context.ConfinedSpacePermits.FirstOrDefault(x => x.Id == id);

                if (confinedSpace != null)
                {
                    if (!string.IsNullOrWhiteSpace(confinedSpace.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(confinedSpace.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(confinedSpace.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(confinedSpace.ApproverFour))
                        totalApprovers++;
                }
            }

            UpdatePermitStatus(permit, totalApprovers);

            await _context.SaveChangesAsync();

            return Content(@"



<!DOCTYPE html>
<html>
<head>
    <title>Permit Approved</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: #f4f7fa;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .card {
            background: #fff;
            width: 500px;
            padding: 40px;
            text-align: center;
            border-radius: 12px;
            box-shadow: 0 5px 20px rgba(0,0,0,0.15);
        }

        .success {
            font-size: 70px;
            color: #28a745;
        }

        h2 {
            color: #28a745;
            margin-top: 10px;
        }

        p {
            color: #555;
            font-size: 17px;
            line-height: 1.6;
        }

        .footer {
            margin-top: 25px;
            color: #888;
            font-size: 13px;
        }
    </style>
</head>
<body>

<div class='card'>
    <div class='success'></div>

    <h2>Permit Approved Successfully</h2>

    <p>
        Thank you.<br><br>
        Your approval has been recorded successfully.
    </p>

    <p>
        No further action is required.
    </p>

    <div class='footer'>
        Permit To Work System
    </div>
</div>

</body>
</html>
", "text/html");
        }

        [HttpGet("reject")]
        public async Task<IActionResult> Reject(string token, string type, int id)
        {
            var permit = _context.PermitMasters.FirstOrDefault(x => x.Id == id &&
            (
                x.FirstApproverToken == token ||
                x.SecondApproverToken == token ||
                x.ThirdApproverToken == token ||
                x.FourthApproverToken == token
            ));

            _logger.LogInformation(
                $"Rejection request received for permit type {type} with ID {id} and token {token} and Permit id {permit?.Id}");

            if (permit == null)
                return Content("Invalid or expired rejection link.");

            bool updated = UpdateApproverStatus(permit, token, "Rejected");

            if (!updated)
                return Content("Invalid or expired rejection link.");

            int totalApprovers = 0;

            if (type == "Cold Work")
            {
                var permitData = _context.ColdWorkPermits
                    .FirstOrDefault(x => x.Id == id);

                if (permitData != null)
                {
                    if (!string.IsNullOrWhiteSpace(permitData.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Hot Work")
            {
                var permitData = _context.HotWorkPermits
                    .FirstOrDefault(x => x.PermitId == id);

                if (permitData != null)
                {
                    if (!string.IsNullOrWhiteSpace(permitData.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Work At Height")
            {
                var permitData = _context.WorkAtHeightPermits
                    .FirstOrDefault(x => x.PermitId == id);

                if (permitData != null)
                {
                    if (!string.IsNullOrWhiteSpace(permitData.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Lifting Operation")
            {
                var permitData = _context.LiftingOperationPermits
                    .FirstOrDefault(x => x.PermitId == id);

                if (permitData != null)
                {
                    if (!string.IsNullOrWhiteSpace(permitData.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Electrical Isolation")
            {
                var permitData = _context.ElectricalIsolationPermits
                    .FirstOrDefault(x => x.PermitId == id);

                if (permitData != null)
                {
                    if (!string.IsNullOrWhiteSpace(permitData.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverFour))
                        totalApprovers++;
                }
            }
            else if (type == "Confined Space")
            {
                var permitData = _context.ConfinedSpacePermits
                    .FirstOrDefault(x => x.Id == id);

                if (permitData != null)
                {
                    if (!string.IsNullOrWhiteSpace(permitData.ApproverOne))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverTwo))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverThree))
                        totalApprovers++;

                    if (!string.IsNullOrWhiteSpace(permitData.ApproverFour))
                        totalApprovers++;
                }
            }

            UpdatePermitStatus(permit, totalApprovers);

            await _context.SaveChangesAsync();
            return Content(@"

<!DOCTYPE html>
<html>
<head>
    <title>Permit Rejected</title>

    <style>
        body{
            margin:0;
            font-family:'Segoe UI',Tahoma,sans-serif;
            background:#f8f3f3;
            display:flex;
            justify-content:center;
            align-items:center;
            height:100vh;
        }

        .card{
            background:#fff;
            width:520px;
            border-radius:15px;
            padding:45px;
            text-align:center;
            box-shadow:0 10px 25px rgba(0,0,0,.15);
        }

        .icon{
            width:90px;
            height:90px;
            line-height:90px;
            margin:auto;
            border-radius:50%;
            background:#dc3545;
            color:white;
            font-size:50px;
            font-weight:bold;
        }

        h1{
            color:#dc3545;
            margin-top:20px;
        }

        p{
            color:#666;
            font-size:17px;
            line-height:1.6;
        }

        .note{
            margin-top:25px;
            padding:12px;
            background:#fff5f5;
            border-left:4px solid #dc3545;
            border-radius:5px;
            color:#555;
        }

        .footer{
            margin-top:25px;
            font-size:13px;
            color:#999;
        }
    </style>

</head>

<body>

<div class=""card"">

    <div class=""icon""></div>

    <h1>Permit Rejected</h1>

    <p>
        Your rejection has been submitted successfully.
    </p>

    <div class=""note"">
        This rejection has been recorded in the Permit To Work system.<br />
        The requester will be notified and can review the permit before resubmission.
    </div>

    <div class=""footer"">
        You may now close this browser window.
    </div>

</div>

</body>
</html>
", "text/html");
        }

        [HttpPost("SendApprovalMail")]
        public IActionResult SendApprovalMail([FromBody] SendMailRequest request)
        {
            try
            {
                sendmail(request.PermitType, request.PermitId);

                return Ok(new
                {
                    Status = true,
                    Message = "Mail sent successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }
        [HttpPost("sendmail")]
        public async Task sendmail(string Type, int id)
        {

            string startdate = string.Empty;
            string enddate = string.Empty;
            string Tomail = string.Empty;
            string firstApprover = string.Empty;
            string scondApprover = string.Empty;
            string thiredApprover = string.Empty;
            string fourthApprover = string.Empty;
            //string baseUrl = "http://192.168.1.146:808";
            string baseUrl = _configuration["AppSettings"];
            //string baseUrl = "https://localhost:7174";
            //string baseUrl = "https://10.10.121.43:7174";

            try
            {
                var permit = _context.PermitMasters.FirstOrDefault(x => x.PermitNumber == id.ToString() && x.PermitType == Type);
                _logger.LogInformation($"Mail Approval request received for permit type {Type} with ID {id} and Permit id {permit?.Id}");

                if (permit == null)
                {
                    return;
                }

                //_context.SaveChanges();

                string approverOneEmail = "";
                string approverTwoEmail = "";
                string approverThreeEmail = "";
                string approverFourEmail = "";

                if (Type == "Cold Work")
                {
                    var permitData = _context.ColdWorkPermits.FirstOrDefault(x => x.Id == id);

                    if (permitData == null)
                        return;

                    approverOneEmail = permitData.ApproverOne;
                    approverTwoEmail = permitData.ApproverTwo;
                    approverThreeEmail = permitData.ApproverThree;
                    approverFourEmail = permitData.ApproverFour;
                }

                else if (Type == "Hot Work")
                {
                    var permitData = _context.HotWorkPermits.FirstOrDefault(x => x.PermitId == id);

                    if (permitData == null)
                        return;

                    approverOneEmail = permitData.ApproverOne;
                    approverTwoEmail = permitData.ApproverTwo;
                    approverThreeEmail = permitData.ApproverThree;
                    approverFourEmail = permitData.ApproverFour;
                }

                else if (Type == "Work At Height")
                {
                    var permitData = _context.WorkAtHeightPermits.FirstOrDefault(x => x.PermitId == id);

                    if (permitData == null)
                        return;

                    approverOneEmail = permitData.ApproverOne;
                    approverTwoEmail = permitData.ApproverTwo;
                    approverThreeEmail = permitData.ApproverThree;
                    approverFourEmail = permitData.ApproverFour;
                }

                else if (Type == "Lifting Operation")
                {
                    var permitData = _context.LiftingOperationPermits.FirstOrDefault(x => x.PermitId == id);

                    if (permitData == null)
                        return;

                    approverOneEmail = permitData.ApproverOne;
                    approverTwoEmail = permitData.ApproverTwo;
                    approverThreeEmail = permitData.ApproverThree;
                    approverFourEmail = permitData.ApproverFour;
                }

                else if (Type == "Electrical Isolation")
                {
                    var permitData = _context.ElectricalIsolationPermits.FirstOrDefault(x => x.PermitId == id);

                    if (permitData == null)
                        return;

                    approverOneEmail = permitData.ApproverOne;
                    approverTwoEmail = permitData.ApproverTwo;
                    approverThreeEmail = permitData.ApproverThree;
                    approverFourEmail = permitData.ApproverFour;
                }

                else if (Type == "Confined Space")
                {
                    var permitData = _context.ConfinedSpacePermits.FirstOrDefault(x => x.Id == id);

                    if (permitData == null)
                        return;

                    approverOneEmail = permitData.ApproverOne;
                    approverTwoEmail = permitData.ApproverTwo;
                    approverThreeEmail = permitData.ApproverThree;
                    approverFourEmail = permitData.ApproverFour;
                }

                _logger.LogInformation($"Approver 1 Email: {approverOneEmail}");
                _logger.LogInformation($"Approver 2 Email: {approverTwoEmail}");
                _logger.LogInformation($"Approver 3 Email: {approverThreeEmail}");
                _logger.LogInformation($"Approver 4 Email: {approverFourEmail}");

                if (!string.IsNullOrWhiteSpace(approverOneEmail))
                {
                    permit.FirstApproverToken = Guid.NewGuid().ToString();
                    permit.FirstApproverStatus = "Pending";
                }

                if (!string.IsNullOrWhiteSpace(approverTwoEmail))
                {
                    permit.SecondApproverToken = Guid.NewGuid().ToString();
                    permit.SecondApproverStatus = "Pending";
                }

                if (!string.IsNullOrWhiteSpace(approverThreeEmail))
                {
                    permit.ThirdApproverToken = Guid.NewGuid().ToString();
                    permit.ThirdApproverStatus = "Pending";
                }

                if (!string.IsNullOrWhiteSpace(approverFourEmail))
                {
                    permit.FourthApproverToken = Guid.NewGuid().ToString();
                    permit.FourthApproverStatus = "Pending";
                }

                await _context.SaveChangesAsync();

                string approveUrl1 = "";
                string rejectUrl1 = "";

                string approveUrl2 = "";
                string rejectUrl2 = "";

                string approveUrl3 = "";
                string rejectUrl3 = "";

                string approveUrl4 = "";
                string rejectUrl4 = "";


                if (!string.IsNullOrWhiteSpace(permit.FirstApproverToken))
                {
                    approveUrl1 = $"{baseUrl}/api/WebServices/Approve?token={permit.FirstApproverToken}&type={Uri.EscapeDataString(Type)}&id={id}";
                    rejectUrl1 = $"{baseUrl}/api/WebServices/Reject?token={permit.FirstApproverToken}&type={Uri.EscapeDataString(Type)}&id={id}";
                }

                if (!string.IsNullOrWhiteSpace(permit.SecondApproverToken))
                {
                    approveUrl2 = $"{baseUrl}/api/WebServices/Approve?token={permit.SecondApproverToken}&type={Uri.EscapeDataString(Type)}&id={id}";
                    rejectUrl2 = $"{baseUrl}/api/WebServices/Reject?token={permit.SecondApproverToken}&type={Uri.EscapeDataString(Type)}&id={id}";
                }

                if (!string.IsNullOrWhiteSpace(permit.ThirdApproverToken))
                {
                    approveUrl3 = $"{baseUrl}/api/WebServices/Approve?token={permit.ThirdApproverToken}&type={Uri.EscapeDataString(Type)}&id={id}";
                    rejectUrl3 = $"{baseUrl}/api/WebServices/Reject?token={permit.ThirdApproverToken}&type={Uri.EscapeDataString(Type)}&id={id}";
                }

                if (!string.IsNullOrWhiteSpace(permit.FourthApproverToken))
                {
                    approveUrl4 = $"{baseUrl}/api/WebServices/Approve?token={permit.FourthApproverToken}&type={Uri.EscapeDataString(Type)}&id={id}";
                    rejectUrl4 = $"{baseUrl}/api/WebServices/Reject?token={permit.FourthApproverToken}&type={Uri.EscapeDataString(Type)}&id={id}";
                }

                // SEND EMAIL TO APPROVER 1

                if (!string.IsNullOrWhiteSpace(approverOneEmail))
                {
                    string body1 = $@"
<html>
<body style='font-family:Arial'>

<h2>Permit Approval Request</h2>

<p>Please review the permit details below.</p>

<table border='1' cellpadding='8' cellspacing='0'
style='border-collapse:collapse;width:700px;'>

<tr style='background-color:#007ACC;color:white'>
<th>Field</th>
<th>Value</th>
</tr>

<tr>
<td>Permit Number</td>
<td>{permit.PermitNumber}</td>
</tr>

<tr>
<td>Permit Type</td>
<td>{Type}</td>
</tr>

<tr>
<td>Start Date</td>
<td>{permit.StartDate}</td>
</tr>

<tr>
<td>End Date</td>
<td>{permit.EndDate}</td>
</tr>

<tr>
<td>First Approver</td>
<td>{permit.FirstApproverToken}</td>
</tr>

<tr>
<td>Second Approver</td>
<td>{permit.SecondApproverToken}</td>
</tr>

<tr>
<td>Third Approver</td>
<td>{permit.ThirdApproverToken}</td>
</tr>

<tr>
<td>Fourth Approver</td>
<td>{permit.FourthApproverToken}</td>
</tr>

</table>

<br/><br/>

<a href='{approveUrl1}'
style='background:green;color:white;padding:12px 25px;
text-decoration:none;font-size:16px;border-radius:5px;'>
APPROVE
</a>

&nbsp;&nbsp;&nbsp;

<a href='{rejectUrl1}'
style='background:red;color:white;padding:12px 25px;
text-decoration:none;font-size:16px;border-radius:5px;'>
REJECT
</a>

<br/><br/>

<b>Permit Management System</b>

</body>
</html>";

                    SendApprovalEmail(approverOneEmail, body1, Type, id);
                }

                // SEND EMAIL TO APPROVER 2

                if (!string.IsNullOrWhiteSpace(approverTwoEmail))
                {
                    string body2 = $@"
<html>
<body style='font-family:Arial'>

<h2>Permit Approval Request</h2>

<p>Please review the permit details below.</p>

<table border='1' cellpadding='8' cellspacing='0'
style='border-collapse:collapse;width:700px;'>

<tr style='background-color:#007ACC;color:white'>
<th>Field</th>
<th>Value</th>
</tr>

<tr>
<td>Permit Number</td>
<td>{permit.PermitNumber}</td>
</tr>

<tr>
<td>Permit Type</td>
<td>{Type}</td>
</tr>

<tr>
<td>Start Date</td>
<td>{startdate}</td>
</tr>

<tr>
<td>End Date</td>
<td>{enddate}</td>
</tr>

<tr>
<td>First Approver</td>
<td>{permit.FirstApproverStatus}</td>
</tr>

<tr>
<td>Second Approver</td>
<td>{permit.SecondApproverStatus}</td>
</tr>

<tr>
<td>Third Approver</td>
<td>{permit.ThirdApproverStatus}</td>
</tr>

<tr>
<td>Fourth Approver</td>
<td>{permit.FourthApproverStatus}</td>
</tr>

</table>

<br/><br/>

<a href='{approveUrl2}'
style='background:green;color:white;padding:12px 25px;
text-decoration:none;font-size:16px;border-radius:5px;'>
APPROVE
</a>

&nbsp;&nbsp;&nbsp;

<a href='{rejectUrl2}'
style='background:red;color:white;padding:12px 25px;
text-decoration:none;font-size:16px;border-radius:5px;'>
REJECT
</a>

<br/><br/>

<b>Permit Management System</b>

</body>
</html>";

                    SendApprovalEmail(approverTwoEmail, body2, Type, id);
                }

                // SEND EMAIL TO APPROVER 3

                if (!string.IsNullOrWhiteSpace(approverThreeEmail))
                {
                    string body3 = $@"
<html>
<body style='font-family:Arial'>

<h2>Permit Approval Request</h2>

<p>Please review the permit details below.</p>

<table border='1' cellpadding='8' cellspacing='0'
style='border-collapse:collapse;width:700px;'>

<tr style='background-color:#007ACC;color:white'>
<th>Field</th>
<th>Value</th>
</tr>

<tr>
<td>Permit Number</td>
<td>{permit.PermitNumber}</td>
</tr>

<tr>
<td>Permit Type</td>
<td>{Type}</td>
</tr>

<tr>
<td>Start Date</td>
<td>{startdate}</td>
</tr>

<tr>
<td>End Date</td>
<td>{enddate}</td>
</tr>

<tr>
<td>First Approver</td>
<td>{permit.FirstApproverStatus}</td>
</tr>

<tr>
<td>Second Approver</td>
<td>{permit.SecondApproverStatus}</td>
</tr>

<tr>
<td>Third Approver</td>
<td>{permit.ThirdApproverStatus}</td>
</tr>

<tr>
<td>Fourth Approver</td>
<td>{permit.FourthApproverStatus}</td>
</tr>

</table>

<br/><br/>

<a href='{approveUrl3}'
style='background:green;color:white;padding:12px 25px;
text-decoration:none;font-size:16px;border-radius:5px;'>
APPROVE
</a>

&nbsp;&nbsp;&nbsp;

<a href='{rejectUrl3}'
style='background:red;color:white;padding:12px 25px;
text-decoration:none;font-size:16px;border-radius:5px;'>
REJECT
</a>

<br/><br/>

<b>Permit Management System</b>

</body>
</html>";

                    SendApprovalEmail(approverThreeEmail, body3, Type, id);
                }

                // SEND EMAIL TO APPROVER 4

                if (!string.IsNullOrWhiteSpace(approverFourEmail))
                {
                    string body4 = $@"
<html>
<body style='font-family:Arial'>

<h2>Permit Approval Request</h2>

<p>Please review the permit details below.</p>

<table border='1' cellpadding='8' cellspacing='0'
style='border-collapse:collapse;width:700px;'>

<tr style='background-color:#007ACC;color:white'>
<th>Field</th>
<th>Value</th>
</tr>

<tr>
<td>Permit Number</td>
<td>{permit.PermitNumber}</td>
</tr>

<tr>
<td>Permit Type</td>
<td>{Type}</td>
</tr>

<tr>
<td>Start Date</td>
<td>{startdate}</td>
</tr>

<tr>
<td>End Date</td>
<td>{enddate}</td>
</tr>

<tr>
<td>First Approver</td>
<td>{permit.FirstApproverStatus}</td>
</tr>

<tr>
<td>Second Approver</td>
<td>{permit.SecondApproverStatus}</td>
</tr>

<tr>
<td>Third Approver</td>
<td>{permit.ThirdApproverStatus}</td>
</tr>

<tr>
<td>Fourth Approver</td>
<td>{permit.FourthApproverStatus}</td>
</tr>

</table>

<br/><br/>

<a href='{approveUrl4}'
style='background:green;color:white;padding:12px 25px;
text-decoration:none;font-size:16px;border-radius:5px;'>
APPROVE
</a>

&nbsp;&nbsp;&nbsp;

<a href='{rejectUrl4}'
style='background:red;color:white;padding:12px 25px;
text-decoration:none;font-size:16px;border-radius:5px;'>
REJECT
</a>

<br/><br/>

<b>Permit Management System</b>

</body>
</html>";

                    SendApprovalEmail(approverFourEmail, body4, Type, id);
                }
                _logger.LogInformation($"Email sent to {Tomail} for permit type {Type} with ID {id}");

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send email for permit type {Type} with ID {id}");
            }
        }

        private void SendApprovalEmail(string email, string body, string type, int id)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(_configuration["SmtpSettings:User"]);

                mail.To.Add(email);

                mail.Subject = "Permit To Work Approval Request";

                mail.Body = body;

                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(_configuration["SmtpSettings:Host"],
                    int.Parse(_configuration["SmtpSettings:Port"])))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(_configuration["SmtpSettings:User"], _configuration["SmtpSettings:Password"]);
                    smtp.Send(mail);
                }

                _logger.LogInformation($"Email sent to {email} for permit type {type} with ID {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send email to {email} for permit type {type} with ID {id}");
            }
        }
    }
}
        



