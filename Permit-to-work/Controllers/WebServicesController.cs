using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Permit_to_work.Data;
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

        [HttpGet("Approve")]
        public async Task<IActionResult> Approve(string token, string type, int id)
        {
            var permit = _context.PermitMasters.FirstOrDefault(x =>
         x.FirstApproverToken == token ||
         x.SecondApproverToken == token ||
         x.ThirdApproverToken == token ||
         x.FourthApproverToken == token);
            _logger.LogInformation($"Approval request received for permit type {type} with ID {id} and token {token} and Permit id {permit?.Id}");
            if (permit == null)
                return Content("Invalid approval link.");

            if (permit.FirstApproverToken == token)
            {
                permit.FirstApproverStatus = "Approved";
                permit.FirstApproverToken = null;
              await _context.SaveChangesAsync();
               await sendmail(type, id);
            }
            else if (permit.SecondApproverToken == token)
            {
                permit.SecondApproverStatus = "Approved";
                permit.SecondApproverToken = null;
               await _context.SaveChangesAsync();
               await sendmail(type, id);
            }
            else if (permit.ThirdApproverToken == token)
            {
                permit.ThirdApproverStatus = "Approved";
                permit.ThirdApproverToken = null;
               await _context.SaveChangesAsync();
               await sendmail(type, id);
            }
            else if (permit.FourthApproverToken == token)
            {
                permit.FourthApproverStatus = "Approved";
                permit.FourthApproverToken = null;
               await _context.SaveChangesAsync();
               await sendmail(type, id);
            }



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
    <div class='success'>✔</div>

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
            var permit = _context.PermitMasters.FirstOrDefault(x =>
            x.FirstApproverToken == token ||
            x.SecondApproverToken == token ||
            x.ThirdApproverToken == token ||
            x.FourthApproverToken == token);
            _logger.LogInformation($"Approval request received for permit type {type} with ID {id} and token {token} and Permit id {permit?.Id}");
            if (permit == null)
                return Content("Invalid approval link.");

            if (permit.FirstApproverToken == token)
            {
                permit.FirstApproverStatus = "Rejected";
                permit.FirstApproverToken = null;
            }
            else if (permit.SecondApproverToken == token)
            {
                permit.SecondApproverStatus = "Rejected";
                permit.SecondApproverToken = null;
            }
            else if (permit.ThirdApproverToken == token)
            {
                permit.ThirdApproverStatus = "Rejected";
                permit.ThirdApproverToken = null;
            }
            else if (permit.FourthApproverToken == token)
            {
                permit.FourthApproverStatus = "Rejected";
                permit.FourthApproverToken = null;
            }

            _context.SaveChanges();

            return Content(@"<!DOCTYPE html>
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

    <div class=""icon"">✕</div>

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
</html>");
        }

        //        [HttpPost("SendApprovalMail")]
        //        public IActionResult SendApprovalMail([FromBody] SendMailRequest request)
        //        {
        //            try
        //            {
        //                sendmail(request.PermitType, request.PermitId);

        //                return Ok(new
        //                {
        //                    Status = true,
        //                    Message = "Mail sent successfully."
        //                });
        //            }
        //            catch (Exception ex)
        //            {
        //                return BadRequest(new
        //                {
        //                    Status = false,
        //                    Message = ex.Message
        //                });
        //            }
        //        }
        [HttpPost("sendmail")]
        public async Task sendmail(string Type, int id)
        {
            string token = Guid.NewGuid().ToString();
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

            string approveUrl = $"{baseUrl}/api/WebServices/Approve?token={token}&type={Uri.EscapeDataString(Type)}&id={id}";
            string rejectUrl = $"{baseUrl}/api/WebServices/Reject?token={token}&type={Uri.EscapeDataString(Type)}&id={id}";
            _logger.LogInformation($"Approval URL: {approveUrl}");
            _logger.LogInformation($"Reject URL: {rejectUrl}");
            try
            {
                var permit = _context.PermitMasters.FirstOrDefault(x => x.PermitNumber == id.ToString() && x.PermitType == Type);
                _logger.LogInformation($"Mail Approval request received for permit type {Type} with ID {id} and token {token} and Permit id {permit?.Id}");
                if (permit != null)
                {


                    if (permit.FirstApproverStatus == "Pending")
                    {
                        permit.FirstApproverToken = token;
                    }
                    else if (permit.SecondApproverStatus == "Pending")
                    {
                        permit.SecondApproverToken = token;
                    }
                    else if (permit.ThirdApproverStatus == "Pending")
                    {
                        permit.ThirdApproverToken = token;
                    }
                    else if (permit.FourthApproverStatus == "Pending")
                    {
                        permit.FourthApproverToken = token;
                    }

                    _context.SaveChanges();
                    if (Type == "Cold Work")
                    {
                        var coldWorkPermit = _context.ColdWorkPermits.FirstOrDefault(x => x.Id == id);
                        if (coldWorkPermit != null)
                        {
                            if (permit.FirstApproverStatus == "Pending")
                            {
                                Tomail = coldWorkPermit.ApproverOne;
                            }
                            else if (permit.SecondApproverStatus == "Pending")
                            {
                                Tomail = coldWorkPermit.ApproverTwo;
                            }
                            else if (permit.ThirdApproverStatus == "Pending")
                            {
                                Tomail = coldWorkPermit.ApproverThree;
                            }
                            else if (permit.FourthApproverStatus == "Pending")
                            {
                                Tomail = coldWorkPermit.ApproverFour;
                            }
                        }
                        startdate = coldWorkPermit.StartDate.ToString();
                        enddate = coldWorkPermit.EndDate.ToString();

                        firstApprover = string.IsNullOrEmpty(coldWorkPermit.ApproverOne) ? string.Empty : coldWorkPermit.ApproverOne.Split('@')[0].ToString();
                        scondApprover = string.IsNullOrEmpty(coldWorkPermit.ApproverTwo) ? string.Empty : coldWorkPermit.ApproverTwo.Split('@')[0].ToString();
                        thiredApprover = string.IsNullOrEmpty(coldWorkPermit.ApproverThree) ? string.Empty : coldWorkPermit.ApproverThree.Split('@')[0].ToString();
                        fourthApprover = string.IsNullOrEmpty(coldWorkPermit.ApproverFour) ? string.Empty : coldWorkPermit.ApproverFour.Split('@')[0].ToString();
                    }
                    else if (Type == "Hot Work")
                    {
                        var hotWorkPermit = _context.HotWorkPermits.FirstOrDefault(x => x.PermitId == id);
                        if (hotWorkPermit != null)
                        {
                            if (permit.FirstApproverStatus == "Pending")
                            {
                                Tomail = hotWorkPermit.ApproverOne;
                            }
                            else if (permit.SecondApproverStatus == "Pending")
                            {
                                Tomail = hotWorkPermit.ApproverTwo;
                            }
                            else if (permit.ThirdApproverStatus == "Pending")
                            {
                                Tomail = hotWorkPermit.ApproverThree;
                            }
                            else if (permit.FourthApproverStatus == "Pending")
                            {
                                Tomail = hotWorkPermit.ApproverFour;
                            }
                        }
                        startdate = hotWorkPermit.StartDate.ToString();
                        enddate = hotWorkPermit.EndDate.ToString();

                        firstApprover = string.IsNullOrEmpty(hotWorkPermit.ApproverOne) ? string.Empty : hotWorkPermit.ApproverOne.Split('@')[0].ToString();
                        scondApprover = string.IsNullOrEmpty(hotWorkPermit.ApproverTwo) ? string.Empty : hotWorkPermit.ApproverTwo.Split('@')[0].ToString();
                        thiredApprover = string.IsNullOrEmpty(hotWorkPermit.ApproverThree) ? string.Empty : hotWorkPermit.ApproverThree.Split('@')[0].ToString();
                        fourthApprover = string.IsNullOrEmpty(hotWorkPermit.ApproverFour) ? string.Empty : hotWorkPermit.ApproverFour.Split('@')[0].ToString();
                    }
                    else if (Type == "Work At Height")
                    {
                        var workAtHeight = _context.WorkAtHeightPermits.FirstOrDefault(x => x.PermitId == id);
                        if (workAtHeight != null)
                        {
                            if (permit.FirstApproverStatus == "Pending")
                            {
                                Tomail = workAtHeight.ApproverOne;
                            }
                            else if (permit.SecondApproverStatus == "Pending")
                            {
                                Tomail = workAtHeight.ApproverTwo;
                            }
                            else if (permit.ThirdApproverStatus == "Pending")
                            {
                                Tomail = workAtHeight.ApproverThree;
                            }
                            else if (permit.FourthApproverStatus == "Pending")
                            {
                                Tomail = workAtHeight.ApproverFour;
                            }
                        }
                        startdate = workAtHeight.StartDate.ToString();
                        enddate = workAtHeight.EndDate.ToString();

                        firstApprover = string.IsNullOrEmpty(workAtHeight.ApproverOne) ? string.Empty : workAtHeight.ApproverOne.Split('@')[0].ToString();
                        scondApprover = string.IsNullOrEmpty(workAtHeight.ApproverTwo) ? string.Empty : workAtHeight.ApproverTwo.Split('@')[0].ToString();
                        thiredApprover = string.IsNullOrEmpty(workAtHeight.ApproverThree) ? string.Empty : workAtHeight.ApproverThree.Split('@')[0].ToString();
                        fourthApprover = string.IsNullOrEmpty(workAtHeight.ApproverFour) ? string.Empty : workAtHeight.ApproverFour.Split('@')[0].ToString();
                    }
                    else if (Type == "Lifting Operation")
                    {
                        var liftingOperation = _context.LiftingOperationPermits.FirstOrDefault(x => x.PermitId == id);
                        if (liftingOperation != null)
                        {
                            if (permit.FirstApproverStatus == "Pending")
                            {
                                Tomail = liftingOperation.ApproverOne;
                            }
                            else if (permit.SecondApproverStatus == "Pending")
                            {
                                Tomail = liftingOperation.ApproverTwo;
                            }
                            else if (permit.ThirdApproverStatus == "Pending")
                            {
                                Tomail = liftingOperation.ApproverThree;
                            }
                            else if (permit.FourthApproverStatus == "Pending")
                            {
                                Tomail = liftingOperation.ApproverFour;
                            }
                        }
                        startdate = liftingOperation.StartDate.ToString();
                        enddate = liftingOperation.EndDate.ToString();

                        firstApprover = string.IsNullOrEmpty(liftingOperation.ApproverOne) ? string.Empty : liftingOperation.ApproverOne.Split('@')[0].ToString();
                        scondApprover = string.IsNullOrEmpty(liftingOperation.ApproverTwo) ? string.Empty : liftingOperation.ApproverTwo.Split('@')[0].ToString();
                        thiredApprover = string.IsNullOrEmpty(liftingOperation.ApproverThree) ? string.Empty : liftingOperation.ApproverThree.Split('@')[0].ToString();
                        fourthApprover = string.IsNullOrEmpty(liftingOperation.ApproverFour) ? string.Empty : liftingOperation.ApproverFour.Split('@')[0].ToString();
                    }
                    else if (Type == "Electrical Isolation")
                    {
                        var electricalIsolation = _context.ElectricalIsolationPermits.FirstOrDefault(x => x.PermitId == id);
                        if (electricalIsolation != null)
                        {
                            if (permit.FirstApproverStatus == "Pending")
                            {
                                Tomail = electricalIsolation.ApproverOne;
                            }
                            else if (permit.SecondApproverStatus == "Pending")
                            {
                                Tomail = electricalIsolation.ApproverTwo;
                            }
                            else if (permit.ThirdApproverStatus == "Pending")
                            {
                                Tomail = electricalIsolation.ApproverThree;
                            }
                            else if (permit.FourthApproverStatus == "Pending")
                            {
                                Tomail = electricalIsolation.ApproverFour;
                            }
                        }
                        startdate = electricalIsolation.StartDate.ToString();
                        enddate = electricalIsolation.EndDate.ToString();

                        firstApprover = string.IsNullOrEmpty(electricalIsolation.ApproverOne) ? string.Empty : electricalIsolation.ApproverOne.Split('@')[0].ToString();
                        scondApprover = string.IsNullOrEmpty(electricalIsolation.ApproverTwo) ? string.Empty : electricalIsolation.ApproverTwo.Split('@')[0].ToString();
                        thiredApprover = string.IsNullOrEmpty(electricalIsolation.ApproverThree) ? string.Empty : electricalIsolation.ApproverThree.Split('@')[0].ToString();
                        fourthApprover = string.IsNullOrEmpty(electricalIsolation.ApproverFour) ? string.Empty : electricalIsolation.ApproverFour.Split('@')[0].ToString();
                    }
                    else if (Type == "Confined Space")
                    {
                        var confinedSpace = _context.ConfinedSpacePermits.FirstOrDefault(x => x.Id == id);
                        if (confinedSpace != null)
                        {
                            if (permit.FirstApproverStatus == "Pending")
                            {
                                Tomail = confinedSpace.ApproverOne;
                            }
                            else if (permit.SecondApproverStatus == "Pending")
                            {
                                Tomail = confinedSpace.ApproverTwo;
                            }
                            else if (permit.ThirdApproverStatus == "Pending")
                            {
                                Tomail = confinedSpace.ApproverThree;
                            }
                            else if (permit.FourthApproverStatus == "Pending")
                            {
                                Tomail = confinedSpace.ApproverFour;
                            }
                        }
                        startdate = confinedSpace.StartDate.ToString();
                        enddate = confinedSpace.EndDate.ToString();

                        firstApprover = string.IsNullOrEmpty(confinedSpace.ApproverOne) ? string.Empty : confinedSpace.ApproverOne.Split('@')[0].ToString();
                        scondApprover = string.IsNullOrEmpty(confinedSpace.ApproverTwo) ? string.Empty : confinedSpace.ApproverTwo.Split('@')[0].ToString();
                        thiredApprover = string.IsNullOrEmpty(confinedSpace.ApproverThree) ? string.Empty : confinedSpace.ApproverThree.Split('@')[0].ToString();
                        fourthApprover = string.IsNullOrEmpty(confinedSpace.ApproverFour) ? string.Empty : confinedSpace.ApproverFour.Split('@')[0].ToString();
                    }
                    if (string.IsNullOrEmpty(Tomail))
                    {
                        // No pending approvers, exit the method
                        return;
                    }
                }
                string body = $@"
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
<td>First Approver - {(string.IsNullOrEmpty(firstApprover) ? string.Empty : firstApprover)}</td>
<td>{permit.FirstApproverStatus}</td>
</tr>

<tr>
<td>Second Approver - {(string.IsNullOrEmpty(scondApprover) ? string.Empty : scondApprover)}</td>
<td>{permit.SecondApproverStatus}</td>
</tr>

<tr>
<td>Third Approver - {(string.IsNullOrEmpty(thiredApprover) ? string.Empty : thiredApprover)}</td>
<td>{permit.ThirdApproverStatus}</td>
</tr>

<tr>
<td>Fourth Approver - {(string.IsNullOrEmpty(fourthApprover) ? string.Empty : fourthApprover)}</td>
<td>{permit.FourthApproverStatus}</td>
</tr>

</table>

<br/><br/>

<a href='{approveUrl}'
style='background:green;
color:white;
padding:12px 25px;
text-decoration:none;
font-size:16px;
border-radius:5px;'>
APPROVE
</a>

&nbsp;&nbsp;&nbsp;

<a href='{rejectUrl}'
style='background:red;
color:white;
padding:12px 25px;
text-decoration:none;
font-size:16px;
border-radius:5px;'>
REJECT
</a>

<br/><br/>

<b>Permit Management System</b>

</body>

</html>";


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_configuration["SmtpSettings:User"]);
                mail.To.Add(Tomail);
                // mail.To.Add("kulothungan.k@syrmasgs.com"); // For testing purposes, replace with actual recipient email
                mail.Subject = "Permit To Work Approval Request";
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(
                    _configuration["SmtpSettings:Host"],
                    int.Parse(_configuration["SmtpSettings:Port"])))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(
                        _configuration["SmtpSettings:User"],
                        _configuration["SmtpSettings:Password"]);
                    smtp.Send(mail); //Testing purpose, comment out to avoid actual email sending
                    _logger.LogInformation($"Email sent to {Tomail} for permit type {Type} with ID {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send email for permit type {Type} with ID {id}");
            }

        }
    }
}
