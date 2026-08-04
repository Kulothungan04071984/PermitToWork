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

        

            return Content("Permit Approved Successfully.");
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

            return Content("Permit Rejected Successfully.");
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
            //string baseUrl = "http://192.168.1.146:808";
             string baseUrl = _configuration["AppSettings"];
           // string baseUrl = "https://localhost:7174";
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
                    }
                    //else if (Type == "Height")
                    //{
                    //    var heightPermit = _context.WorkAtHeightPermits.FirstOrDefault(x => x.PermitId == id);
                    //    //if (heightPermit != null)
                    //    //{
                    //    //    Tomail = heightPermit.ApproverOne ?? heightPermit.ApproverTwo ?? heightPermit.ApproverThree ?? heightPermit.ApproverFour ?? string.Empty;
                    //    //}
                    //    startdate = heightPermit.StartDate.ToString();
                    //    enddate = heightPermit.EndDate.ToString();
                    //}
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
