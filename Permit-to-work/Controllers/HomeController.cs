using Registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Permit_to_work.Data;
using Permit_to_work.Models;
using Permit_to_work.ViewModel;
using Registration.Models;
using RTools_NTS.Util;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetTopologySuite.Noding;

namespace Permit_to_work.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
      
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        //public JsonResult GetApprovalCount(int permitDashBoardId)
        //{
        //    var master = _context.PermitMasters.Find(permitDashBoardId);
        //    if (master == null)
        //        return Json(new { Count = 0 });
        //    string? firstMail = null, secondMail = null, thirdMail = null, fourthMail = null;
        //    int count = 0;

        //    if (master.PermitType == "Height")
        //    {
        //        var permit = _context.WorkAtHeightPermits.Find(master.RelatedPermitId);
        //        if (permit !=null)
        //        {
        //            firstMail = permit.ApproverOne;
        //            secondMail = permit.ApproverTwo;
        //            thirdMail = permit.ApproverThree;
        //            fourthMail = permit.ApproverFour;
        //        }
        //    }
        //    else if (master.PermitType == "Hot")
        //    {
        //        var permit = _context.HotWorkPermits.Find(master.RelatedPermitId)
        //    }


        //    return Json(new {count, firstMail, secondMail, thirdMail, fourthMail});

        //}

        //public IActionResult GetApprovalStatus(int permitDashBoardId)
        //{
        //    var permit = _context.PermitMasters
        //        .FirstOrDefault(x => Convert.ToInt32(x.PermitNumber) == permitDashBoardId);

        //    if (permit == null)
        //    {
        //        return Json(null);
        //    }

        //    int approvedCount = 0;

        //    if (permit.FirstApproverStatus == "Approved")
        //        approvedCount++;

        //    if (permit.SecondApproverStatus == "Approved")
        //        approvedCount++;

        //    if (permit.ThirdApproverStatus == "Approved")
        //        approvedCount++;

        //    if (permit.FourthApproverStatus == "Approved")
        //        approvedCount++;

        //    var coldWork = _context.ColdWorkPermits
        //        .FirstOrDefault(x => x.PermitNumber == permit.PermitNumber);

        //    return Json(new
        //    {
        //        ApprovedCount = approvedCount,
        //        ApproverOne = coldWork?.ApproverOne,
        //        ApproverTwo = coldWork?.ApproverTwo,
        //        ApproverThree = coldWork?.ApproverThree,
        //        ApproverFour = coldWork?.ApproverFour
        //    });
        //}



        public IActionResult GetApprovalStatus(int permitDashBoardId)
        {
            var permit = _context.PermitMasters
                .FirstOrDefault(x => Convert.ToInt32(x.PermitNumber) == permitDashBoardId);

            if (permit == null)

            {
                return Json(0);
            }

            int approvedCount = 0;

            if (permit.FirstApproverStatus == "Approved")
                approvedCount++;

            if (permit.SecondApproverStatus == "Approved")
                approvedCount++;

            if (permit.ThirdApproverStatus == "Approved")
                approvedCount++;

            if (permit.FourthApproverStatus == "Approved")
                approvedCount++;

            return Json(new
            {
                count = approvedCount,

                FirstStatus = permit.FirstApproverStatus,
                SecondStatus = permit.SecondApproverStatus,
                ThirdStatus = permit.ThirdApproverStatus,
                FourthStatus = permit.FourthApproverStatus,

                FirstMail = permit.FirstApproverStatus == "Approved" ? permit.FirstApproverStatus : "",
                SecondMail = permit.SecondApproverStatus == "Approved" ? permit.SecondApproverStatus : "",
                ThirdMail = permit.ThirdApproverStatus == "Approved" ? permit.ThirdApproverStatus : "",
                FourthMail = permit.FourthApproverStatus == "Approved" ? permit.FourthApproverStatus : ""
            });
        }

        //public IActionResult GetApprovalStatus(int permitDashBoardId)
        //{
        //    var permit = _context.PermitMasters
        //        .FirstOrDefault(x => Convert.ToInt32(x.PermitNumber) == permitDashBoardId);


        //    if (permit == null)
        //    {
        //        return Json(new
        //        {
        //            count = 0,
        //            FirstMail = "",
        //            SecondMail = "",
        //            ThirdMail = "",
        //            FourthMail = ""
        //        });
        //    }

        //    int approvedCount = 0;

        //    if (permit.FirstApproverStatus == "Approved")
        //        approvedCount++;
        //    if (permit.SecondApproverStatus == "Approved")
        //        approvedCount++;
        //    if (permit.ThirdApproverStatus == "Approved")
        //        approvedCount++;
        //    if (permit.FourthApproverStatus == "Approved")
        //        approvedCount++;

        //    return Json(new
        //    {
        //        count = approvedCount,
        //        FirstMail = permit.FirstApproverStatus == "Approved" ? permit.FirstApproverStatus : string.Empty,
        //        SecondMail = permit.SecondApproverStatus == "Approved" ? permit.SecondApproverStatus : string.Empty,
        //        ThirdMail = permit.ThirdApproverStatus == "Approved" ? permit.ThirdApproverStatus : string.Empty,
        //        FourthMail = permit.SecondApproverStatus == "Approved" ? permit.FourthApproverStatus : string.Empty,

        //    });


        //}


        public IActionResult Index()
        {
            return View();
        }

            public IActionResult Privacy()
            {
                return View();
            }

            public IActionResult Registration()
            {
                return View();
            }

            public IActionResult TicketApproval()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Save(Login emp)
            {
                var isExistUser = _context.Logins.Any(a => a.Username == emp.Username);
                if (!isExistUser)
                {
                    emp.isActive = true;
                    emp.AdminRights ??= false;
                    _context.Logins.Add(emp);
                    _context.SaveChanges();
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Username already exits. Please enter another username.");
                    return View("Registration", emp);
                }

            }

            // COLD WORK PERMIT
            [HttpGet]
            public IActionResult workpermitform(int? id)
            {
                if (id.HasValue && id > 0)
                {
                    var existing = _context.ColdWorkPermits.FirstOrDefault(x => x.Id == id.Value);
                    if (existing != null)
                        return View(existing);
                }
                return View(new ColdWorkPermit());
            }

        [HttpPost]
        public async Task<IActionResult> workpermitform(ColdWorkPermit vm)
        {
            try
            {
                if (!vm.RiskFallHeight &&
                    !vm.RiskWeather &&
                    !vm.RiskFlying &&
                    !vm.RiskEquipment &&
                    !vm.RiskFalling &&
                    !vm.RiskProtruding &&
                    !vm.RiskTripping &&
                    !vm.RiskFaulty &&
                    !vm.RiskNoise &&
                    !vm.RiskHeat &&
                    !vm.RiskVibration &&
                    !vm.RiskIllumination &&
                    !vm.RiskFire &&
                   string.IsNullOrWhiteSpace(vm.RiskOther))
                {
                    ModelState.AddModelError("RiskIdentification", "Please select at least one Risk Identification or enter Other Risk.");
                }

                //else if (!vm.DocJSA &&
                //         !vm.DocRiskAssessment &&
                //         string.IsNullOrWhiteSpace(vm.DocOther))
                //{
                //    ModelState.AddModelError("Documents", "Please select at least one of the document or enter Other Risk.");
                //}

                //else if (string.IsNullOrWhiteSpace(vm.Precaution))
                //{
                //    ModelState.AddModelError("Precaution&Tools", "Please select at least one of the Precaution.");
                //}

                else if (string.IsNullOrWhiteSpace(vm.ToolsTested))
                {
                    ModelState.AddModelError("ToolsTested", "Please select at least one of the Tools.");
                }

                //else if (!vm.HazardWorkAtHeight &&
                //         !vm.HazardScaffolding &&
                //         !vm.HazardToolEquipment &&
                //         !vm.HazardChemical &&
                //         !vm.HazardElectrical &&
                //         !vm.HazardLifting &&
                //         !vm.HazardHotSurface &&
                //         !vm.HazardDust &&                   
                //         string.IsNullOrWhiteSpace(vm.HazardNA))  
                //{
                //    ModelState.AddModelError("Hazards", "Please select at least one of the Hazards.");
                //}

                //else if (!vm.PermitHotWork &&
                //         !vm.PermitWorkAtHeight &&
                //         !vm.PermitExcavation &&
                //         !vm.PermitElectrical &&
                //         !vm.PermitConfinedSpace &&
                //         string.IsNullOrWhiteSpace(vm.PermitOther) &&
                //         string.IsNullOrWhiteSpace(vm.PermitAssociated))
                //{
                //    ModelState.AddModelError("AssociatedPermits", "Please select at least one of the Associated Permits or enter other permit.");
                //}

                else if (!vm.WC &&
                         !vm.ESI)
                {
                    ModelState.AddModelError("Insurance", "Please select at least one of the Insurance Copy.");
                }

                else if (!vm.InspectAccess &&
                         !vm.InspectDangerSign &&
                         !vm.InspectLighting &&
                         !vm.InspectSafetyBarriers &&
                         !vm.InspectHandTools &&
                         string.IsNullOrWhiteSpace(vm.InspectOther) &&
                         string.IsNullOrWhiteSpace(vm.InspectedNA))
                {
                    ModelState.AddModelError("InspectedAreas", "Please select at least one of the Inspected Areas or fill other.");
                }

                else if (!vm.PPEHelmet &&
                         !vm.PPEShoes &&
                         !vm.PPEGloves &&
                         !vm.PPEGoggles &&
                         !vm.PPEDustMask &&
                         !vm.PPEEarPlugs &&
                         !vm.PPEReflectiveVest &&
                         !vm.PPEHarness &&
                         string.IsNullOrWhiteSpace(vm.PPEOther) &&
                         string.IsNullOrWhiteSpace(vm.PPENA))
                {
                    ModelState.AddModelError("PPE", "Please select at least one of the PPE or fill other.");
                }

                else if (string.IsNullOrWhiteSpace(vm.ApproverOne) &&
                         string.IsNullOrWhiteSpace(vm.ApproverTwo) &&
                         string.IsNullOrWhiteSpace(vm.ApproverThree) &&
                         string.IsNullOrWhiteSpace(vm.ApproverFour))
                {
                    ModelState.AddModelError("ApproverDetails", "Please fill at least one field in Approver Details.");
                }

                //if (!ModelState.IsValid)
                //    return View(vm);

                ModelState.Remove("CreatedOn");
                ModelState.Remove("IsActive");

                if (!ModelState.IsValid)
                {
                    // Log errors to Output window
                    foreach (var key in ModelState.Keys)
                        foreach (var error in ModelState[key].Errors)
                            Console.WriteLine($"Field: {key} => {error.ErrorMessage}");

                    return View(vm);
                }

                var entity = new ColdWorkPermit
                {
                    // ── Basic Details ──────────────────────────────────────
                    Unit = vm.Unit,
                    ContractorTeam = vm.ContractorTeam,
                    Location = vm.Location,
                    NoOfWorkmen = vm.NoOfWorkmen,

                    // ── Dates & Times ──────────────────────────────────────
                    StartDate = vm.StartDate,
                    StartTime = vm.StartTime,
                    EndDate = vm.EndDate,
                    EndTime = vm.EndTime,

                    // ── Work & Tools ───────────────────────────────────────
                    WorkDescription = vm.WorkDescription,
                    ToolsEquipment = vm.ToolsEquipment,

                    // ── Risk Identification ────────────────────────────────
                    RiskFallHeight = vm.RiskFallHeight,
                    RiskWeather = vm.RiskWeather,
                    RiskFlying = vm.RiskFlying,
                    RiskEquipment = vm.RiskEquipment,
                    RiskFalling = vm.RiskFalling,
                    RiskProtruding = vm.RiskProtruding,
                    RiskTripping = vm.RiskTripping,
                    RiskFaulty = vm.RiskFaulty,
                    RiskNoise = vm.RiskNoise,
                    RiskHeat = vm.RiskHeat,
                    RiskVibration = vm.RiskVibration,
                    RiskIllumination = vm.RiskIllumination,
                    RiskFire = vm.RiskFire,
                    RiskOther = vm.RiskOther,

                    // ── Documents ─────────────────────────────────────────
                    DocJSA = vm.DocJSA,
                    DocRiskAssessment = vm.DocRiskAssessment,
                    DocOther = vm.DocOther,

                    //// ── Precaution ────────────────────────────
                    //Precaution = vm.Precaution,
                    // ── Precaution & Tools Tested ────────────────────────────

                    //── Tools Tested ──────────────────────────
                    ToolsTested = vm.ToolsTested,

                    // ── Hazards Identified ────────────────────────────────
                    //HazardWorkAtHeight = vm.HazardWorkAtHeight,
                    //HazardScaffolding = vm.HazardScaffolding,
                    //HazardToolEquipment = vm.HazardToolEquipment,
                    //HazardChemical = vm.HazardChemical,
                    //HazardElectrical = vm.HazardElectrical,
                    //HazardLifting = vm.HazardLifting,
                    //HazardHotSurface = vm.HazardHotSurface,
                    //HazardDust = vm.HazardDust,
                    //HazardNA = vm.HazardNA,

                    // ── Associated Permits ───────────────────────────────────
                    PermitHotWork = vm.PermitHotWork,
                    PermitWorkAtHeight = vm.PermitWorkAtHeight,
                    PermitExcavation = vm.PermitExcavation,
                    PermitElectrical = vm.PermitElectrical,
                    PermitConfinedSpace = vm.PermitConfinedSpace,
                    PermitOther = vm.PermitOther,
                    PermitAssociated = vm.PermitAssociated,

                    // ── Insurance ─────────────────────────────────────────
                    WC = vm.WC,
                    ESI = vm.ESI,

                    // ── Inspected Areas ───────────────────────────────────
                    InspectAccess = vm.InspectAccess,
                    InspectDangerSign = vm.InspectDangerSign,
                    InspectLighting = vm.InspectLighting,
                    InspectSafetyBarriers = vm.InspectSafetyBarriers,
                    InspectHandTools = vm.InspectHandTools,
                    InspectOther = vm.InspectOther,
                    InspectedNA = vm.InspectedNA,

                    // ── PPE Required ──────────────────────────────────────
                    PPEHelmet = vm.PPEHelmet,
                    PPEShoes = vm.PPEShoes,
                    PPEGloves = vm.PPEGloves,
                    PPEGoggles = vm.PPEGoggles,
                    PPEDustMask = vm.PPEDustMask,
                    PPEEarPlugs = vm.PPEEarPlugs,
                    PPEReflectiveVest = vm.PPEReflectiveVest,
                    PPEHarness = vm.PPEHarness,
                    PPEOther = vm.PPEOther,
                    PPENA = vm.PPENA,

                    // ── Authorization ─────────────────────────────────────
                    ReceiverName = vm.ReceiverName,
                    ReceiverDate = vm.ReceiverDate,
                    IssuerName = vm.IssuerName,
                    IssuerDate = vm.IssuerDate,

                    // ── Suspension / Clearance ────────────────────────────
                    Name = vm.Name,
                    SuspensionDate = vm.SuspensionDate,

                    //── Approver Details ───────────────────────────────────

                    ApproverOne = vm.ApproverOne,
                    ApproverTwo = vm.ApproverTwo,
                    ApproverThree = vm.ApproverThree,
                    ApproverFour = vm.ApproverFour,

                    // ── Meta ──────────────────────────────────────────────
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                if (vm.Id > 0)
                {
                    entity.Id = vm.Id;
                    entity.CreatedOn = _context.ColdWorkPermits
                                        .Where(x => x.Id == vm.Id)
                                        .Select(x => x.CreatedOn)
                                        .FirstOrDefault();   // preserve original CreatedOn
                    _context.ColdWorkPermits.Update(entity);
                }

                else
                {
                    _context.ColdWorkPermits.Add(entity);
                }

                var x = entity.ApproverFour;
                _context.SaveChanges();
                insertPermitMaster("Cold Work",entity.Id.ToString(),entity.Unit,Convert.ToString(entity.StartDate),Convert.ToString(entity.EndDate), entity.Location);
               await sendmail("Cold Work", entity.Id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the Cold permit.");
                ModelState.AddModelError(ex.Message.ToString(), "An error occurred while saving the Cold permit. Please try again.");
                return View(vm);
            }


            return RedirectToAction("Dashboard");
        }
        
        [HttpPost("sendmail")]
        public async Task sendmail(string Type, int id)
        {
            string token = Guid.NewGuid().ToString();
            string startdate = string.Empty;
            string enddate = string.Empty;
            string Tomail = string.Empty;
            //string baseUrl = "http://192.168.1.146:808";
            string baseUrl = _configuration["AppSettings"];
            //string baseUrl = "https://localhost:7174";
            // string baseUrl = "https://10.10.121.43:7174";

            string approveUrl = $"{baseUrl}/api/WebServices/Approve?token={token}&type={Uri.EscapeDataString(Type)}&id={id}";
            _logger.LogInformation($"Approval URL: {approveUrl}");
            string rejectUrl = $"{baseUrl}/api/WebServices/Reject?token={token}&type={Uri.EscapeDataString(Type)}&id={id}";
            _logger.LogInformation($"Reject URL: {rejectUrl}");
            try
            {
                var permit = _context.PermitMasters.FirstOrDefault(x => x.PermitNumber == id.ToString() && x.PermitType == Type);
                if( permit != null )
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

            // HOT WORK PERMIT

            [HttpPost]
            public async Task<IActionResult> Hotwork(HotWorkPermit model)
            {
                if (!model.Welding &&
                   !model.ChippingCuttingGrinding)
                {
                    ModelState.AddModelError("WorkType", "Please select at least one Work Type.");
                }

                if (!model.Electrocution &&
                    !model.ArcFlash &&
                    !model.FlyingParticles &&
                    !model.Noise &&
                    !model.FallingObjects &&
                    !model.ProtrudingObjects &&
                    !model.TrippingSlipping &&
                    !model.ElectricShock &&
                    !model.FireSpark &&
                    !model.ManualHandling &&
                    !model.HotBurn &&
                    !model.Explosion &&
                    !model.HealthHazard &&
                    !model.FumeSmoke &&
                    string.IsNullOrWhiteSpace(model.AttachOther))
                {
                    ModelState.AddModelError("Risk", "Please select at least one Risk Identification");
                }

                if (string.IsNullOrWhiteSpace(model.EmergencyTeamAvailable) &&
                    string.IsNullOrWhiteSpace(model.EmergencyContact1) &&
                    string.IsNullOrWhiteSpace(model.EmergencyContact2) &&
                    string.IsNullOrWhiteSpace(model.EmergencyContact3) &&
                    string.IsNullOrWhiteSpace(model.ToolsTested))
                {
                    ModelState.AddModelError("EmergencyTeam", "Please fill at least one Emergency Team field.");
                }

                if (!model.WC &&
                    !model.ESI)
                {
                    ModelState.AddModelError("Insurance", "Please select at least one Insurance");
                }

                if (!model.FireExtinguisherChecked &&
                    !model.FireBlanketChecked &&
                    !model.WarningSignChecked &&
                    !model.LightingChecked &&
                    !model.SafetyBarriersChecked &&
                    !model.SandBucketChecked &&
                    string.IsNullOrWhiteSpace(model.FireExtinguisherDetails))
                {
                    ModelState.AddModelError("Inspection", "Please select at least one Inspection");
                }

                if (!model.Helmet &&
                    !model.SafetyShoes &&
                    !model.WeldingGloves &&
                    !model.FaceShield &&
                    !model.WeldingGoggles &&
                    !model.Apron &&
                    !model.GasMask &&
                    !model.EarPlugs &&
                    !model.WeldingShield &&
                    !model.WeldingClothes &&
                    string.IsNullOrWhiteSpace(model.OtherPPE))
                {
                    ModelState.AddModelError("PPE", "Please select at least one PPE");
                }

                if (string.IsNullOrWhiteSpace(model.ApproverOne) &&
                    string.IsNullOrWhiteSpace(model.ApproverTwo) &&
                    string.IsNullOrWhiteSpace(model.ApproverThree) &&
                    string.IsNullOrWhiteSpace(model.ApproverFour))
                {
                    ModelState.AddModelError("ApproverDetails", "Please fill at least one field in Approver Detail.");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var entity = new HotWorkPermit

                {
                    // ── Basic Details ────────────────────────────────────────────
                    Unit = model.Unit,
                    ContractorName = model.ContractorName,
                    Location = model.Location,
                    NoOfWorkmen = model.NoOfWorkmen,

                    // ── Date & Time ────────────────────────────────────────────
                    StartDate = model.StartDate,
                    StartTime = model.StartTime,
                    EndDate = model.EndDate,
                    EndTime = model.EndTime,

                    // ── Work Type ────────────────────────────────────────────
                    Welding = model.Welding,
                    ChippingCuttingGrinding = model.ChippingCuttingGrinding,

                    // ── Work Details ────────────────────────────────────────────
                    WorkDescription = model.WorkDescription,

                    // ── Tools ───────────────────────────────────────
                    ToolsEquipment = model.ToolsEquipment,

                    // ── Risk ──────────────────────────────────────────────────
                    Electrocution = model.Electrocution,
                    ArcFlash = model.ArcFlash,
                    FlyingParticles = model.FlyingParticles,
                    Noise = model.Noise,
                    FallingObjects = model.FallingObjects,
                    ProtrudingObjects = model.ProtrudingObjects,
                    TrippingSlipping = model.TrippingSlipping,
                    ElectricShock = model.ElectricShock,
                    FireSpark = model.FireSpark,
                    ManualHandling = model.ManualHandling,
                    HotBurn = model.HotBurn,
                    Explosion = model.Explosion,
                    HealthHazard = model.HealthHazard,
                    FumeSmoke = model.FumeSmoke,

                    // ── Documents ──────────────────────────────────────────────────
                    AttachJSA = model.AttachJSA,
                    AttachOther = model.AttachOther,

                    // ── Certification Safety ───────────────────────────────────────
                    CombustibleRemoved = model.CombustibleRemoved,

                    // ── Regulators ───────────────────────────────────────
                    FlashbackArrestors = model.FlashbackArrestors,
                    CylindersProvided = model.CylindersProvided,

                    // ── Emergency Team ────────────────────────────────────────────
                    EmergencyTeamAvailable = model.EmergencyTeamAvailable,
                    EmergencyContact1 = model.EmergencyContact1,
                    EmergencyContact2 = model.EmergencyContact2,
                    EmergencyContact3 = model.EmergencyContact3,
                    ToolsTested = model.ToolsTested,

                    // ── Insurance Copy ────────────────────────────────────────────
                    ESI = model.ESI,
                    WC = model.WC,
                    WCFilePath = model.WCFilePath,
                    ESIFilePath = model.ESIFilePath,

                    // ── Inspections ────────────────────────────────────────────
                    FireExtinguisherDetails = model.FireExtinguisherDetails,
                    FireExtinguisherChecked = model.FireExtinguisherChecked,
                    FireBlanketChecked = model.FireBlanketChecked,
                    WarningSignChecked = model.WarningSignChecked,
                    LightingChecked = model.LightingChecked,
                    SafetyBarriersChecked = model.SafetyBarriersChecked,
                    SandBucketChecked = model.SandBucketChecked,

                    // ── PPE ───────────────────────────────────────────────────
                    Helmet = model.Helmet,
                    SafetyShoes = model.SafetyShoes,
                    WeldingGloves = model.WeldingGloves,
                    FaceShield = model.FaceShield,
                    WeldingGoggles = model.WeldingGoggles,
                    Apron = model.Apron,
                    GasMask = model.GasMask,
                    EarPlugs = model.EarPlugs,
                    WeldingShield = model.WeldingShield,
                    WeldingClothes = model.WeldingClothes,
                    OtherPPE = model.OtherPPE,

                    // ── Issues & Acceptance ────────────────────────────────────────────
                    ReceiverName = model.ReceiverName,
                    ReceiverDate = model.ReceiverDate,
                    IssuerName = model.IssuerName,
                    IssuerDate = model.IssuerDate,

                    // ── Suspension ────────────────────────────────────────────
                    SuspensionName = model.SuspensionName,
                    SuspensionSignatureDate = model.SuspensionSignatureDate,

                    // ── Approver Details ────────────────────────────────────────────
                    ApproverOne = model.ApproverOne,
                    ApproverTwo = model.ApproverTwo,
                    ApproverThree = model.ApproverThree,
                    ApproverFour = model.ApproverFour,

                    // ── Meta ─────────────────────────────────────────────────
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                };


                entity.Status = "Pending";

            _context.HotWorkPermits.Add(entity);
            await _context.SaveChangesAsync();
           await sendmail("Hot Work", entity.PermitId);

                return RedirectToAction("Dashboard");
            }

            public IActionResult Hotwork()
            {
                return View();
            }

            // ELECTRICAL ISOLATION PERMIT

            [HttpPost]
            public async Task<IActionResult> ElectricalIsolationPermit(ElectricalIsolationPermit model)
            {
                if (!model.EnergizedEquipment &&
                    !model.DeEnergizedEquipment)
                {
                    ModelState.AddModelError("EnergyStatus", "Please select at least one Energy Status.");
                }

                if (!model.RiskElectrocution &&
                    !model.RiskArcFlash &&
                    !model.RiskFlyingParticles &&
                    !model.RiskNoise &&
                    !model.RiskFallingObjects &&
                    !model.RiskProtrudingParts &&
                    !model.RiskTripping &&
                    !model.RiskElectricShock &&
                    !model.RiskFire &&
                    !model.RiskManualHandling &&
                    !model.RiskElectricBurn &&
                    !model.RiskOverheadLines &&
                    string.IsNullOrWhiteSpace(model.OtherRisk))
                {
                    ModelState.AddModelError("Risk", "Please select at least one Risk Identification.");
                }

                if (!model.WC &&
                    !model.ESI &&
                    string.IsNullOrWhiteSpace(model.OtherInsurance))
                {
                    ModelState.AddModelError("Insurance", "Please select at least one Insurance.");
                }

                if (!model.FireExtinguisher &&
                    !model.AccessRoute &&
                    !model.DangerSign &&
                    !model.Lighting &&
                    !model.SafetyBarriers &&
                    string.IsNullOrWhiteSpace(model.FireExtinguisherType) &&
                    string.IsNullOrWhiteSpace(model.FireExtinguisherQuantity) &&
                    string.IsNullOrWhiteSpace(model.FireExtinguisherSize))
                {
                    ModelState.AddModelError("Inspection", "Please select at least one Inspection.");
                }

                if (!model.PPEHelmet &&
                    !model.PPEShoes &&
                    !model.PPEElectricalGloves &&
                    !model.PPEHalfMask &&
                    !model.PPEFaceShield &&
                    !model.PPEArcFlash &&
                    !model.PPEDustMask &&
                    !model.PPESafetyGoggles &&
                    !model.PPEReflectiveVest &&
                    !model.PPESafetyEar &&
                    string.IsNullOrWhiteSpace(model.OtherPPE))
                {
                    ModelState.AddModelError("PPE", "Please select at least one PPE");
                }

                if (string.IsNullOrWhiteSpace(model.ApproverOne) &&
                    string.IsNullOrWhiteSpace(model.ApproverTwo) &&
                    string.IsNullOrWhiteSpace(model.ApproverThree) &&
                    string.IsNullOrWhiteSpace(model.ApproverFour))
                {
                    ModelState.AddModelError("ApproverDetails", "Please fill at least one field in Approver Detail.");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var entity = new ElectricalIsolationPermit

                {
                    // ── Basic Details ────────────────────────────────────────────
                    Unit = model.Unit,
                    PermitDate = model.PermitDate,
                    Location = model.Location,
                    NumberOfWorkmen = model.NumberOfWorkmen,

                    // ── Date & Time ────────────────────────────────────────────
                    StartDate = model.StartDate,
                    StartTime = model.StartTime,
                    EndDate = model.EndDate,
                    EndTime = model.EndTime,

                    // ── Energy Status ────────────────────────────────────────────
                    EnergizedEquipment = model.EnergizedEquipment,
                    DeEnergizedEquipment = model.DeEnergizedEquipment,

                    // ── Work & Tools ────────────────────────────────────────────
                    WorkDescription = model.WorkDescription,
                    ToolsEquipment = model.ToolsEquipment,

                    // ── Risk ────────────────────────────────────────────
                    RiskElectrocution = model.RiskElectrocution,
                    RiskArcFlash = model.RiskArcFlash,
                    RiskFlyingParticles = model.RiskFlyingParticles,
                    RiskNoise = model.RiskNoise,
                    RiskFallingObjects = model.RiskFallingObjects,
                    RiskProtrudingParts = model.RiskProtrudingParts,
                    RiskTripping = model.RiskTripping,
                    RiskElectricShock = model.RiskElectricShock,
                    RiskFire = model.RiskFire,
                    RiskManualHandling = model.RiskManualHandling,
                    RiskElectricBurn = model.RiskElectricBurn,
                    RiskOverheadLines = model.RiskOverheadLines,
                    OtherRisk = model.OtherRisk,

                    // ── Documents ────────────────────────────────────────────
                    AttachJSA = model.AttachJSA,
                    OtherDocument = model.OtherDocument,

                    // ── Precaution ────────────────────────────────────────────
                    Precaution = model.Precaution,
                    SafeDistance = model.SafeDistance,
                    Voltage = model.Voltage,
                    Distance = model.Distance,
                    ConfinedSpace = model.ConfinedSpace,
                    ElectricalIsolation = model.ElectricalIsolation,

                    // ── LOTO / Isolation ───────────────────────────────────────
                    SwitchOut = model.SwitchOut,
                    LockoutTagout = model.LockoutTagout,
                    NumberOfLocks = model.NumberOfLocks,
                    TestConfirmed = model.TestConfirmed,
                    ToolsTested = model.ToolsTested,
                    OtherLOTO = model.OtherLOTO,

                    // ── Insurance ────────────────────────────────────────────
                    WC = model.WC,
                    ESI = model.ESI,
                    OtherInsurance = model.OtherInsurance,

                    // ── Inspection ────────────────────────────────────────────
                    FireExtinguisher = model.FireExtinguisher,
                    FireExtinguisherType = model.FireExtinguisherType,
                    FireExtinguisherQuantity = model.FireExtinguisherQuantity,
                    FireExtinguisherSize = model.FireExtinguisherSize,
                    AccessRoute = model.AccessRoute,
                    DangerSign = model.DangerSign,
                    Lighting = model.Lighting,
                    SafetyBarriers = model.SafetyBarriers,

                    // ── PPE ────────────────────────────────────────────
                    PPEHelmet = model.PPEHelmet,
                    PPEShoes = model.PPEShoes,
                    PPEElectricalGloves = model.PPEElectricalGloves,
                    PPEHalfMask = model.PPEHalfMask,
                    PPEFaceShield = model.PPEFaceShield,
                    PPEArcFlash = model.PPEArcFlash,
                    PPEDustMask = model.PPEDustMask,
                    PPESafetyGoggles = model.PPESafetyGoggles,
                    PPEReflectiveVest = model.PPEReflectiveVest,
                    PPESafetyEar = model.PPESafetyEar,
                    OtherPPE = model.OtherPPE,

                    // ── Issue & Acceptance ────────────────────────────────────────────
                    ReceiverName = model.ReceiverName,
                    ReceiverSignatureDate = model.ReceiverSignatureDate,
                    IssuerName = model.IssuerName,
                    IssuerSignatureDate = model.IssuerSignatureDate,

                    // ── Suspension ────────────────────────────────────────────
                    SuspensionName = model.SuspensionName,
                    SuspensionSignatureDate = model.SuspensionSignatureDate,

                    // ── Approver Details ────────────────────────────────────────────
                    ApproverOne = model.ApproverOne,
                    ApproverTwo = model.ApproverTwo,
                    ApproverThree = model.ApproverThree,
                    ApproverFour = model.ApproverFour,

                    // ── Meta ─────────────────────────────────────────────────
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                };

                entity.Status = "Pending";

                _context.ElectricalIsolationPermits.Add(entity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Dashboard");
            }
            
            public IActionResult ElectricalIsolationPermit()
            {
                return View();
            }

       public void insertPermitMaster(string PermitType,string Permitid, string unit, string startdate, string enddate, string location)
        {
            try
            {
                var permitMaster = new PermitMaster
                {
                    Unit = unit,
                    StartDate = Convert.ToDateTime(startdate),
                    EndDate = Convert.ToDateTime(enddate),
                    PermitType = PermitType,
                    PermitNumber = Permitid,
                    Location = location,
                    Status = "Pending",
                    FirstApproverStatus = "Pending",
                    SecondApproverStatus = "Pending",
                    ThirdApproverStatus = "Pending",
                    FourthApproverStatus = "Pending",
                    CreatedByUserId = HttpContext.Session.GetString("UserId"),
                    CreatedOn = DateTime.Now,
                };

                _context.Add(permitMaster);
                _context.SaveChanges();
                _logger.LogInformation("PermitMaster record inserted successfully for PermitType: {PermitType}, PermitId: {Permitid}", PermitType, Permitid);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting into PermitMaster.");
            }
        }

            // LIFTING OPERATION PERMIT

            [HttpPost]
            public async Task<IActionResult> Liftingoperation(LiftingOperationPermit model)

            {

                if (!model.TruckMounted &&
                    !model.HydraCrane &&
                    !model.OverheadCrane &&
                    !model.TowerCrane)

                {
                    ModelState.AddModelError("Lifting Equipment", "Please select at least one Lifting Equipment");
                }

                if (!model.WeightApprox &&
                    !model.DimensionMax &&
                    !model.Quantity)

                {
                    ModelState.AddModelError("Details of Load", "Please select at least one Details of Load");
                }

                if (!model.PPEHelmet &&
                    !model.PPEShoes &&
                    !model.PPEGloves &&
                    !model.PPEEarPlug &&
                    !model.PPESafetygoggles &&
                    !model.PPEReflectiveVest &&
                    !model.PPEDustMask &&
                    string.IsNullOrWhiteSpace(model.OtherPPE))

                {
                    ModelState.AddModelError("PPE", "Please select at least one PPE");
                }

                if (!model.WC &&
                   !model.ESI)

                {
                    ModelState.AddModelError("Insurance", "Please select at least one Insurance");
                }

                if (string.IsNullOrWhiteSpace(model.ApproverOne) &&
                    string.IsNullOrWhiteSpace(model.ApproverTwo) &&
                    string.IsNullOrWhiteSpace(model.ApproverThree) &&
                    string.IsNullOrWhiteSpace(model.ApproverFour))
                {
                    ModelState.AddModelError("ApproverDetails", "Please fill at least one field in Approver Detail.");
                }


                if (!ModelState.IsValid)
                    return View(model);

                var entity = new LiftingOperationPermit

                {
                    // ── Basic Details ────────────────────────────────────────────
                    Unit = model.Unit,
                    ContractorName = model.ContractorName,
                    Location = model.Location,
                    NoOfWorkmen = model.NoOfWorkmen,

                    // ── Date & Time ────────────────────────────────────────────-
                    StartDate = model.StartDate,
                    StartTime = model.StartTime,
                    EndDate = model.EndDate,
                    EndTime = model.EndTime,

                    // ── LIFTING EQUIPMENT ────────────────────────────────────────────
                    TruckMounted = model.TruckMounted,
                    HydraCrane = model.HydraCrane,
                    OverheadCrane = model.OverheadCrane,
                    TowerCrane = model.TowerCrane,

                    // ── Details of Load ────────────────────────────────────────────
                    WeightApprox = model.WeightApprox,
                    DimensionMax = model.DimensionMax,
                    Quantity = model.Quantity,

                    // ── Work Details ────────────────────────────────────────────
                    SerialNo = model.SerialNo,
                    InspectionDate = model.InspectionDate,
                    CapacitySWL = model.CapacitySWL,
                    WorkDescription = model.WorkDescription,
                    ToolsEquipment = model.ToolsEquipment,

                    // ── RiggerLevel ────────────────────────────────────────────
                    RiggerLevel = model.RiggerLevel,

                    // ── Risk ──────────────────────────────────────────────────
                    RiskToppling = model.RiskToppling,
                    RiskSuspendedLoad = model.RiskSuspendedLoad,
                    RiskHighWind = model.RiskHighWind,
                    RiskMovingVehicle = model.RiskMovingVehicle,
                    RiskFallingObjects = model.RiskFallingObjects,
                    RiskOverLoad = model.RiskOverLoad,
                    RiskTripping = model.RiskTripping,
                    RiskNoise = model.RiskNoise,
                    RiskCrushing = model.RiskCrushing,
                    RiskCollapse = model.RiskCollapse,
                    RiskNearOverheadLines = model.RiskNearOverheadLines,
                    RiskTraffic = model.RiskTraffic,
                    RiskAdverseWeather = model.RiskAdverseWeather,
                    OtherRisk = model.OtherRisk,

                    // ── Documents ────────────────────────────────────────────
                    AttachJSA = model.AttachJSA,
                    CombustibleMaterialsRemoved = model.CombustibleMaterialsRemoved,
                    EquipmentCertified = model.EquipmentCertified,

                    // ── Rigging Accessories ──────────────────────────────────────────────────
                    WireRope = model.WireRope,
                    WebSling = model.WebSling,
                    ChainSling = model.ChainSling,
                    Shackles = model.Shackles,
                    EyeBolt = model.EyeBolt,
                    OtherRigging = model.OtherRigging,

                    // ── Load & Wind Check ────────────────────────────────────────────
                    LoadChartChecked = model.LoadChartChecked,
                    WindAcceptable = model.WindAcceptable,

                    // ── Inspected Area ──────────────────────────────────────────────────
                    GroundCondition = model.GroundCondition,
                    DangerWarningSign = model.DangerWarningSign,
                    SignalMan = model.SignalMan,
                    SafetyBarriers = model.SafetyBarriers,
                    TagLine = model.TagLine,
                    Rigger = model.Rigger,
                    OutriggerExtended = model.OutriggerExtended,
                    Lighting = model.Lighting,
                    OutriggerPad = model.OutriggerPad,
                    SpreaderBeam = model.SpreaderBeam,
                    ManMaterialBasketCertified = model.ManMaterialBasketCertified,

                    // ── PPE ────────────────────────────────────────────
                    PPEHelmet = model.PPEHelmet,
                    PPEShoes = model.PPEShoes,
                    PPEGloves = model.PPEGloves,
                    PPEEarPlug = model.PPEEarPlug,
                    PPESafetygoggles = model.PPESafetygoggles,
                    PPEReflectiveVest = model.PPEReflectiveVest,
                    PPEDustMask = model.PPEDustMask,
                    OtherPPE = model.OtherPPE,

                    // ── Insurance ────────────────────────────────────────────
                    WC = model.WC,
                    ESI = model.ESI,

                    // ── Authorization ────────────────────────────────────────────
                    RaisedBy = model.RaisedBy,
                    DepartmentIncharge = model.DepartmentIncharge,
                    Facility = model.Facility,
                    Safety = model.Safety,

                    // ── Suspension ────────────────────────────────────────────
                    SuspensionName = model.SuspensionName,
                    SuspensionSignatureDate = model.SuspensionSignatureDate,

                    // ── Approver Details ────────────────────────────────────────────
                    ApproverOne = model.ApproverOne,
                    ApproverTwo = model.ApproverTwo,
                    ApproverThree = model.ApproverThree,
                    ApproverFour = model.ApproverFour,

                    // ── Meta ─────────────────────────────────────────────────
                    CreatedOn = DateTime.Now,
                    IsActive = true,

                };

                entity.Status = "Pending";

                _context.LiftingOperationPermits.Add(entity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Dashboard");
            }

            public IActionResult Liftingoperation()
            {
                return View();
            }


            // WORK AT HEIGHT PERMIT

            [HttpPost]
            public async Task<IActionResult> WorkAtHeightPermit(WorkAtHeightPermit model)
            {

                if (!model.Scaffolding &&
                   !model.Ladder &&
                   !model.AerialLift &&
                   !model.RoofWork &&
                   string.IsNullOrWhiteSpace(model.OtherWork))

                {
                    ModelState.AddModelError("WorkType", "Please select at least one Work Type.");
                }

                if (!model.FallfromHeight &&
                    !model.AdverseWeather &&
                    !model.FlyingParticles &&
                    !model.MovingVehicleEquipment &&
                    !model.FallingDebrisObjects &&
                    !model.ProtrudingObjectsparts &&
                    !model.TrippingSlipping &&
                    !model.FaultyEquipmentMaterial &&
                    !model.FragileSurfaceRoof &&
                    !model.WorkUnderBelow &&
                    !model.NearOverheadLines &&
                    !model.NearEnergizedEquipment &&
                    string.IsNullOrWhiteSpace(model.OtherRiskControl))
                {
                    ModelState.AddModelError("Risk", "Please select at least one Risk Identification");
                }

                if (!model.DangerWarningSign &&
                    !model.ScaffoldTagSystem &&
                    !model.Lighting &&
                    !model.SafetyBarriers &&
                    !model.BuddySystem &&
                    !model.Rescue &&
                    !model.MaterialBasket &&
                    string.IsNullOrWhiteSpace(model.OtherInspection))
                {
                    ModelState.AddModelError("Inspection", "Please select at least one Inspection");
                }

                if (!model.PPEHelmet &&
                   !model.PPEHelmetwithChinStrap &&
                   !model.PPEShoes &&
                   !model.PPEGloves &&
                   !model.PPEEarPlug &&
                   !model.PPEReflectiveVest &&
                   !model.PPEDustMask &&
                   !model.PPESafetyClothes &&
                   string.IsNullOrWhiteSpace(model.OtherPPE))
                {
                    ModelState.AddModelError("PPE", "Please select at least one PPE");
                }

                if (!model.WC &&
                    !model.ESI &&
                    string.IsNullOrWhiteSpace(model.AttachOther))

                {
                    ModelState.AddModelError("Insurance", "Please select at least one Insurance");
                }

                if (!ModelState.IsValid)
                {

                    return View(model);
                }

                var entity = new WorkAtHeightPermit
                {
                    // ── Basic Details ────────────────────────────────────────────
                    Unit = model.Unit,
                    ContractorTeam = model.ContractorTeam,
                    Location = model.Location,
                    NoOfWorkmen = model.NoOfWorkmen,

                    // ── Date & Time ────────────────────────────────────────────
                    StartDate = model.StartDate,
                    StartTime = model.StartTime,
                    EndDate = model.EndDate,
                    EndTime = model.EndTime,

                    // ── Work Type ────────────────────────────────────────────
                    Scaffolding = model.Scaffolding,
                    Ladder = model.Ladder,
                    AerialLift = model.AerialLift,
                    RoofWork = model.RoofWork,
                    OtherWork = model.OtherWork,

                    // ── Work Details ────────────────────────────────────────────
                    WorkDescription = model.WorkDescription,

                    // ── Tools ───────────────────────────────────────
                    ToolsEquipment = model.ToolsEquipment,

                    // ── Risk ──────────────────────────────────────────────────
                    FallfromHeight = model.FallfromHeight,
                    AdverseWeather = model.AdverseWeather,
                    FlyingParticles = model.FlyingParticles,
                    MovingVehicleEquipment = model.MovingVehicleEquipment,
                    FallingDebrisObjects = model.FallingDebrisObjects,
                    ProtrudingObjectsparts = model.ProtrudingObjectsparts,
                    TrippingSlipping = model.TrippingSlipping,
                    FaultyEquipmentMaterial = model.FaultyEquipmentMaterial,
                    FragileSurfaceRoof = model.FragileSurfaceRoof,
                    WorkUnderBelow = model.WorkUnderBelow,
                    NearOverheadLines = model.NearOverheadLines,
                    NearEnergizedEquipment = model.NearEnergizedEquipment,
                    OtherRiskControl = model.OtherRiskControl,

                    // ── Documents ─────────────────────────────────────────
                    AttachJSA = model.AttachJSA,
                    RiskAssessment = model.RiskAssessment,
                    AttachOther = model.AttachOther,

                    //// ── Work Safely ───────────────────────────────────────
                    //Precautionmeasures = model.Precautionmeasures,

                    //// ── risk control ───────────────────────────────────────
                    //RiskControlImplemented = model.RiskControlImplemented,

                    // ── Fall ─────────────────────────────────────
                    GuardRailsSystem = model.GuardRailsSystem,
                    SafetyNet = model.SafetyNet,
                    ToeBoard = model.ToeBoard,
                    LifeLine = model.LifeLine,
                    RetractableHarness = model.RetractableHarness,
                    HarnessShockAbsorber = model.HarnessShockAbsorber,
                    DoubleHook = model.DoubleHook,
                    AccessProvided = model.AccessProvided,
                    FloorOpeningsCovered = model.FloorOpeningsCovered,

                    // ── Inspections ────────────────────────────────────────────
                    DangerWarningSign = model.DangerWarningSign,
                    ScaffoldTagSystem = model.ScaffoldTagSystem,
                    Lighting = model.Lighting,
                    SafetyBarriers = model.SafetyBarriers,
                    BuddySystem = model.BuddySystem,
                    Rescue = model.Rescue,
                    MaterialBasket = model.MaterialBasket,
                    OtherInspection = model.OtherInspection,

                    // ── PPE ────────────────────────────────────────────

                    PPEHelmetwithChinStrap = model.PPEHelmetwithChinStrap,
                    PPEHelmet = model.PPEHelmet,
                    PPEShoes = model.PPEShoes,
                    PPEGloves = model.PPEGloves,
                    PPEEarPlug = model.PPEEarPlug,
                    PPEReflectiveVest = model.PPEReflectiveVest,
                    PPEDustMask = model.PPEDustMask,
                    PPESafetyClothes = model.PPESafetyClothes,
                    OtherPPE = model.OtherPPE,

                    // ── Insurance ───────────────────────────────────────────
                    WC = model.WC,
                    ESI = model.ESI,
                    OtherInsurance = model.OtherInsurance,

                    // ── Authorization ───────────────────────────────────────────
                    ReceiverName = model.ReceiverName,
                    IssuerName = model.IssuerName,
                    ReceiverDate = model.ReceiverDate,
                    IssuerDate = model.IssuerDate,

                    // ── SUSPENSION ───────────────────────────────────────────
                    SuspensionName = model.SuspensionName,
                    SuspensionSignatureDate = model.SuspensionSignatureDate,

                    // ── Approver Details ───────────────────────────────────────────
                    ApproverOne = model.ApproverOne,
                    ApproverTwo = model.ApproverTwo,
                    ApproverThree = model.ApproverThree,
                    ApproverFour = model.ApproverFour,

                    // ── Meta ─────────────────────────────────────────────────
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                };

            _context.WorkAtHeightPermits.Add(entity);
            await _context.SaveChangesAsync();
           await sendmail("WorkAtHeight", entity.PermitId);

                //return Content("Saved Successfully");

                return RedirectToAction("Dashboard");
            }

            public IActionResult WorkAtHeightPermit()
            {
                return View();
            }

            // CONFINED SPACE PERMIT

            [HttpPost]
            public async Task<IActionResult> ConfinedSpaceEntry(ConfinedSpacePermit model)
            {
                if (!model.RiskOxygen &&
                    !model.RiskExplosion &&
                    !model.RiskFume &&
                    !model.RiskNoise &&
                    !model.RiskHot &&
                    !model.RiskFire &&
                    !model.RiskDust &&
                    !model.RiskVibration &&
                    string.IsNullOrWhiteSpace(model.RiskOther))
                {
                    ModelState.AddModelError("Risk", "Please select at least one Risk Identification");
                }

                if (!model.WC &&
                    !model.ESI &&
                    string.IsNullOrWhiteSpace(model.OtherInsurance))
                {
                    ModelState.AddModelError("Insurance", "Please select at least one Insurance");
                }

                if (!model.FireExtinguisher &&
                    !model.DangerWarningSign &&
                    !model.Access &&
                    !model.Lighting &&
                    !model.LogBook &&
                    !model.GasDetector &&
                    string.IsNullOrWhiteSpace(model.FireExtinguisherType) &&
                    string.IsNullOrWhiteSpace(model.FireExtinguisherQty) &&
                    string.IsNullOrWhiteSpace(model.FireExtinguisherSize) &&
                    string.IsNullOrWhiteSpace(model.InspectionOther))
                {
                    ModelState.AddModelError("Inspection", "Please select at least one Inspection");
                }

                if (!model.Helmet &&
                    !model.SafetyShoes &&
                    !model.Gloves &&
                    !model.EarPlugs &&
                    !model.Goggles &&
                    !model.Vest &&
                    !model.GasMask &&
                    !model.Harness &&
                    !model.Gumboot &&
                    !model.DustMask &&
                    string.IsNullOrWhiteSpace(model.PPEOther))
                {
                    ModelState.AddModelError("PPE", "Please select at least one PPE");
                }

                if (string.IsNullOrWhiteSpace(model.ApproverOne) &&
                    string.IsNullOrWhiteSpace(model.ApproverTwo) &&
                    string.IsNullOrWhiteSpace(model.ApproverThree) &&
                    string.IsNullOrWhiteSpace(model.ApproverFour))
                {
                    ModelState.AddModelError("ApproverDetails", "Please fill at least one Approver Detail");
                }

                if (!ModelState.IsValid)
                {
                    //foreach (var item in ModelState)
                    //{
                    //    if (item.Value != null && item.Value.Errors.Count > 0)
                    //    {
                    //        return Content ($"{item.Key} : {item.Value.Errors[0].ErrorMessage}");
                    //    }
                    //}
                    //return Content ("ModelState Invalid");

                    return View(model);
                }

                var entity = new ConfinedSpacePermit
                {
                    // ─── Basic Details ───────────────────────────────────
                    Unit = model.Unit,
                    Contractor = model.Contractor,
                    Location = model.Location,
                    NoOfWorkmen = model.NoOfWorkmen,

                    // ─── Dates ───────────────────────────────────────────
                    StartDate = model.StartDate,
                    StartTime = model.StartTime,
                    EndDate = model.EndDate,
                    EndTime = model.EndTime,

                    // ─── Work & Tools ───────────────────────────────────
                    WorkDescription = model.WorkDescription,
                    ToolsEquipment = model.ToolsEquipment,

                    // ─── Risks ───────────────────────────────────
                    RiskOxygen = model.RiskOxygen,
                    RiskExplosion = model.RiskExplosion,
                    RiskFume = model.RiskFume,
                    RiskNoise = model.RiskNoise,
                    RiskHot = model.RiskHot,
                    RiskFire = model.RiskFire,
                    RiskDust = model.RiskDust,
                    RiskVibration = model.RiskVibration,
                    RiskOther = model.RiskOther,

                    // ─── Documents ───────────────────────────────────
                    JSA = model.JSA,
                    RiskAssessment = model.RiskAssessment,
                    DocumentOther = model.DocumentOther,

                    // ──── Precaution ───────────────────────────────────
                    OxygenLevel = model.OxygenLevel,
                    IsOxygenLevelchecked = model.IsOxygenLevelchecked,
                    IsExplosiveLevelChecked = model.IsExplosiveLevelChecked,
                    ExplosiveLevel = model.ExplosiveLevel,
                    IsCOLevelChecked = model.IsCOLevelChecked,
                    COLevel = model.COLevel,
                    IsH2SLevelChecked = model.IsH2SLevelChecked,
                    H2SLevel = model.H2SLevel,
                    //AtmosphereDone = model.AtmosphereDone,
                    Natural = model.Natural,
                    Mechanical = model.Mechanical,
                    StateDetails = model.StateDetails,
                    //Ventilation = model.Ventilation,
                    Communication = model.Communication,
                    EmergencyProcedure = model.EmergencyProcedure,
                    HotWorkRequired = model.HotWorkRequired,
                    Lockout = model.Lockout,

                    // ──── Emergency Team ───────────────────────────────────
                    EmergencyTeam = model.EmergencyTeam,
                    Contact1 = model.Contact1,
                    Contact2 = model.Contact2,
                    Contact3 = model.Contact3,
                    Other = model.Other,

                    // ──── Insurance ───────────────────────────────────
                    WC = model.WC,
                    ESI = model.ESI,
                    OtherInsurance = model.OtherInsurance,

                    // ──── Inspection ─────────────────────────────────── 
                    FireExtinguisher = model.FireExtinguisher,
                    FireExtinguisherType = model.FireExtinguisherType,
                    FireExtinguisherQty = model.FireExtinguisherQty,
                    FireExtinguisherSize = model.FireExtinguisherSize,
                    Access = model.Access,
                    DangerWarningSign = model.DangerWarningSign,
                    Lighting = model.Lighting,
                    LogBook = model.LogBook,
                    GasDetector = model.GasDetector,
                    InspectionOther = model.InspectionOther,

                    // ──── PPE ───────────────────────────────────
                    Helmet = model.Helmet,
                    SafetyShoes = model.SafetyShoes,
                    Gloves = model.Gloves,
                    EarPlugs = model.EarPlugs,
                    Goggles = model.Goggles,
                    Vest = model.Vest,
                    GasMask = model.GasMask,
                    Harness = model.Harness,
                    Gumboot = model.Gumboot,
                    DustMask = model.DustMask,
                    PPEOther = model.PPEOther,

                    // ──── Issue and Acceptance  ────────────────────────────
                    RaisedBy = model.RaisedBy,
                    DepartmentIncharge = model.DepartmentIncharge,
                    Facility = model.Facility,
                    Safety = model.Safety,

                    // ──── Suspension ───────────────────────────────────
                    SuspensionName = model.SuspensionName,
                    SuspensionDate = model.SuspensionDate,

                    // ──── Approver Details ───────────────────────────
                    ApproverOne = model.ApproverOne,
                    ApproverTwo = model.ApproverTwo,
                    ApproverThree = model.ApproverThree,
                    ApproverFour = model.ApproverFour,

                };

                entity.Status = "Pending";

                _context.ConfinedSpacePermits.Add(entity);

                await _context.SaveChangesAsync();

                return RedirectToAction("Dashboard");
            }

            public IActionResult ConfinedSpaceEntry()
            {
                return View();
            }

            //public IActionResult ConfinedSpaceEntry()
            //{
            //    ConfinedSpaceEntryPermitModel objConfined = new ConfinedSpaceEntryPermitModel();
            //    return View(objConfined);
            //}


            //HOME
            public IActionResult Home()
            {
                return View();
            }

            public JsonResult GetApprovalStatus(int id, string type)
            {
                var status = _context.PermitMasters;

                var result = status
                    .Where(x => x.Id == id)
                    .Select(x => new
                    {
                        x.FirstApproverStatus,
                        x.SecondApproverStatus,
                        x.ThirdApproverStatus,
                        x.FourthApproverStatus

                        //x.ApproverOne ,
                        //ApproverTwo = x.ApproverTwo ?? "EMPTY",
                        //ApproverThree = x.ApproverThree ?? "EMPTY",
                        //ApproverFour = x.ApproverFour ?? "EMPTY"
                    })
                    .FirstOrDefault();


                return Json(new
                {
                    FirstStatus = result.FirstApproverStatus,
                    SecondStatus = result.SecondApproverStatus,
                    ThirdStatus = result.ThirdApproverStatus,
                    FourthStatus = result.FourthApproverStatus,
                });
            }

            public IActionResult Dashboard()
            {
                PermitDetails objpermit = new PermitDetails();
                //PermitDashboardVM objPermitDetails = new PermitDashboardVM();
                objpermit.PermitTypes = _context.PermitTypeMasters.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.PermitTypeId.ToString(), Text = x.PermitTypeName }).ToList();
                objpermit.Departments = _context.DepartmentMasters.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.DepartmentId.ToString(), Text = x.DepartmentName }).ToList();
                objpermit.Units = _context.UnitMasters.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.UnitId.ToString(), Text = x.UnitName }).ToList();
                objpermit.Approvers = _context.ApproverMasters.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.ApproverId.ToString(), Text = x.ApproverName }).ToList();

                var dashboard = new List<PermitDashboardVM>();


                dashboard.AddRange(
                    _context.ColdWorkPermits.Where(a => a.IsActive == true).Select(x => new PermitDashboardVM
                    {
                        PermitDashBoardId = x.Id,
                        PermitType = "Cold Work",
                        Unit = x.Unit,
                        Location = x.Location,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Status = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Cold Work").Select(p => p.Status).FirstOrDefault(),

                        Count = (x.ApproverOne != null ? 4 : x.ApproverTwo != null ? 3 : x.ApproverThree != null ? 2 : x.ApproverFour != null ? 1 : 0),

                        FirstApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Cold Work").Select(p => p.FirstApproverStatus).FirstOrDefault(),
                        SecondApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Cold Work").Select(p => p.SecondApproverStatus).FirstOrDefault(),
                        ThirdApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Cold Work").Select(p => p.ThirdApproverStatus).FirstOrDefault(),
                        FourthApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Cold Work").Select(p => p.FourthApproverStatus).FirstOrDefault(),
                    })
                );
                dashboard.AddRange(
                    _context.HotWorkPermits.Where(a => a.IsActive == true).Select(x => new PermitDashboardVM
                    {
                        PermitDashBoardId = x.PermitId,
                        PermitType = "Hot Work",
                        Unit = x.Unit,
                        Location = x.Location,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        //Status = "Active",
                        Status = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Hot Work").Select(p => p.Status).FirstOrDefault(),

                        Count = (x.ApproverOne != null ? 4 : x.ApproverTwo != null ? 3 : x.ApproverThree != null ? 2 : x.ApproverFour != null ? 1 : 0),

                        FirstApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Hot Work").Select(p => p.FirstApproverStatus).FirstOrDefault(),
                        SecondApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Hot Work").Select(p => p.SecondApproverStatus).FirstOrDefault(),
                        ThirdApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Hot Work").Select(p => p.ThirdApproverStatus).FirstOrDefault(),
                        FourthApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Hot Work").Select(p => p.FourthApproverStatus).FirstOrDefault(),
                    })
                );

                dashboard.AddRange(
                    _context.ElectricalIsolationPermits.Where(a => a.IsActive == true).Select(x => new PermitDashboardVM
                    {
                        PermitDashBoardId = x.PermitId,
                        PermitType = "Electrical Isolation",
                        Unit = x.Unit,
                        Location = x.Location,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        //Status = "Active"
                        Status = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Electrical Isolation").Select(p => p.Status).FirstOrDefault(),

                        Count = (x.ApproverOne != null ? 4 : x.ApproverTwo != null ? 3 : x.ApproverThree != null ? 2 : x.ApproverFour != null ? 1 : 0),

                        FirstApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Electrical Isolation").Select(p => p.FirstApproverStatus).FirstOrDefault(),
                        SecondApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Electrical Isolation").Select(p => p.SecondApproverStatus).FirstOrDefault(),
                        ThirdApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Electrical Isolation").Select(p => p.ThirdApproverStatus).FirstOrDefault(),
                        FourthApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Electrical Isolation").Select(p => p.FourthApproverStatus).FirstOrDefault(),
                    })
                );

                dashboard.AddRange(
                    _context.WorkAtHeightPermits.Select(x => new PermitDashboardVM
                    {
                        PermitDashBoardId = x.PermitId,
                        PermitType = "Work At Height",
                        Unit = x.Unit,
                        Location = x.Location,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Status = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Work At Height").Select(p => p.Status).FirstOrDefault(),

                        Count = (x.ApproverOne != null ? 4 : x.ApproverTwo != null ? 3 : x.ApproverThree != null ? 2 : x.ApproverFour != null ? 1 : 0),

                        FirstApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Work At Height").Select(p => p.FirstApproverStatus).FirstOrDefault(),
                        SecondApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Work At Height").Select(p => p.SecondApproverStatus).FirstOrDefault(),
                        ThirdApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Work At Height").Select(p => p.ThirdApproverStatus).FirstOrDefault(),
                        FourthApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Work At Height").Select(p => p.FourthApproverStatus).FirstOrDefault(),
                    })
                );

                dashboard.AddRange(
                    _context.LiftingOperationPermits.Where(a => a.IsActive == true).Select(x => new PermitDashboardVM
                    {
                        PermitDashBoardId = x.PermitId,
                        PermitType = "Lifting Operation",
                        Unit = x.Unit,
                        Location = x.Location,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,

                        //Status = "Active"
                        Status = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Lifting Operation").Select(p => p.Status).FirstOrDefault(),

                        Count = (x.ApproverOne != null ? 4 : x.ApproverTwo != null ? 3 : x.ApproverThree != null ? 2 : x.ApproverFour != null ? 1 : 0),

                        FirstApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Lifting Operation").Select(p => p.FirstApproverStatus).FirstOrDefault(),
                        SecondApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Lifting Operation").Select(p => p.SecondApproverStatus).FirstOrDefault(),
                        ThirdApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Lifting Operation").Select(p => p.ThirdApproverStatus).FirstOrDefault(),
                        FourthApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.PermitId && p.PermitType == "Lifting Operation").Select(p => p.FourthApproverStatus).FirstOrDefault(),
                    })
                );

                dashboard.AddRange(
                    _context.ConfinedSpacePermits.Select(x => new PermitDashboardVM
                    {
                        PermitDashBoardId = x.Id,
                        PermitType = "",
                        Unit = x.Unit,
                        Location = x.Location,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        //Status = "Active"
                        Status = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Confined Space").Select(p => p.Status).FirstOrDefault(),

                        Count = (x.ApproverOne != null ? 4 : x.ApproverTwo != null ? 3 : x.ApproverThree != null ? 2 : x.ApproverFour != null ? 1 : 0),

                        FirstApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Confined Space").Select(p => p.FirstApproverStatus).FirstOrDefault(),
                        SecondApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Confined Space").Select(p => p.SecondApproverStatus).FirstOrDefault(),
                        ThirdApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Confined Space").Select(p => p.ThirdApproverStatus).FirstOrDefault(),
                        FourthApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id && p.PermitType == "Confined Space").Select(p => p.FourthApproverStatus).FirstOrDefault(),
                    })
                );




                objpermit.PermitDetailsList = dashboard.OrderByDescending(x => x.StartDate).ToList();

                objpermit.FirstApproval = _context.ApproverMasters.Where(x => x.ApproverId == 1).Select(x => x.ApproverName).FirstOrDefault();
                objpermit.SecondApproval = _context.ApproverMasters.Where(x => x.ApproverId == 2).Select(x => x.ApproverName).FirstOrDefault();
                objpermit.ThirdApproval = _context.ApproverMasters.Where(x => x.ApproverId == 3).Select(x => x.ApproverName).FirstOrDefault();
                objpermit.FourthApproval = _context.ApproverMasters.Where(x => x.ApproverId == 4).Select(x => x.ApproverName).FirstOrDefault();

                return View(objpermit);
            }

        //public JsonResult CreatePermit(PermitDetails modelvalues)
        //{
        //    string result = string.Empty;
        //    try
        //    {
        //        _context.Add(modelvalues);
        //        _context.SaveChanges();
        //        result = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        result= ex.Message;
        //    }
        //    return Json(result);
        //}

        public JsonResult getPermitdetails(string Permitid, string PermitType, string Status)
        {
            try
            {
                if (PermitType == "Cold Work")
                {
                    int count = 0;
                    var permitdetails = _context.ColdWorkPermits.Where(a => a.Id == Convert.ToInt32(Permitid)).FirstOrDefault();
                    var PermitApproveDetails =
                        _context.ColdWorkPermits
                        .Where(b => b.Id == Convert.ToInt32(Permitid))
                        .Select(a => (new ColdWorkPermit { Id = a.Id, ApproverOne = a.ApproverOne, ApproverTwo = a.ApproverTwo, ApproverThree = a.ApproverThree, ApproverFour = a.ApproverFour })).FirstOrDefault();

                    if (PermitApproveDetails.ApproverOne == null)
                        count = 0;
                    else if (PermitApproveDetails.ApproverTwo == null)
                        count = 1;
                    else if (PermitApproveDetails.ApproverThree == null)
                        count = 2;
                    else if (PermitApproveDetails.ApproverFour == null)
                        count = 3;
                    else
                        count = 4;

                    var permitcheck = _context.PermitMasters.Where(a => a.PermitNumber == Permitid && a.PermitType == PermitType).FirstOrDefault();

                    if (permitcheck != null)
                    {
                        var first = permitcheck.FirstApproverStatus;
                        if (first != "Pending")
                        {

                            var second = permitcheck.SecondApproverStatus;
                            var third = permitcheck.ThirdApproverStatus;
                            var fourth = permitcheck.FourthApproverStatus;

                            // Second Approver
                            if (count >= 2 && second == "Pending")
                            {
                                permitcheck.SecondApproverStatus = Status;
                            }

                            // Third Approver
                            else if (count >= 3 && third == "Pending")
                            {
                                permitcheck.ThirdApproverStatus = Status;
                            }

                            // Fourth Approver
                            else if (count == 4 && fourth == "Pending")
                            {
                                permitcheck.FourthApproverStatus = Status;
                            }

                            if (count == 1)
                            {

                                if (permitcheck.FirstApproverStatus == "Rejected")
                                {
                                    permitcheck.Status = "Rejected";
                                }
                                else
                                {
                                    permitcheck.Status = "Approved";
                                }
                            }

                            else if (count == 2)
                            {

                                if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected")
                                {
                                    permitcheck.Status = "Rejected";
                                }

                                else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending")
                                {

                                    if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved")
                                    {
                                        permitcheck.Status = "Approved";
                                    }

                                    else
                                        permitcheck.Status = "Partial Approved";
                                }
                            }

                            else if (count == 3)
                            {

                                if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected")
                                {
                                    permitcheck.Status = "Rejected";
                                }

                                else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending")
                                {

                                    if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved")
                                    {
                                        permitcheck.Status = "Approved";
                                    }

                                    else
                                        permitcheck.Status = "Partial Approved";
                                }
                            }

                            else if (count == 4)
                            {

                                if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected" && permitcheck.FourthApproverStatus == "Rejected")
                                {
                                    permitcheck.Status = "Rejected";
                                }

                                else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending" && permitcheck.FourthApproverStatus != "Pending")
                                {

                                    if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved" && permitcheck.FourthApproverStatus == "Approved")
                                    {
                                        permitcheck.Status = "Approved";
                                    }

                                    else
                                        permitcheck.Status = "Partial Approved";
                                }
                            }

                            _context.PermitMasters.Update(permitcheck);
                            sendmail(PermitType, Convert.ToInt32(Permitid));
                        }
                    }

                    else
                    {
                        var permitMaster = new PermitMaster
                        {
                            Unit = permitdetails.Unit,
                            StartDate = permitdetails.StartDate,
                            EndDate = permitdetails.EndDate,
                            PermitType = PermitType,
                            PermitNumber = Permitid,
                            Location = permitdetails.Location,
                            Status = count > 1 ? "Partial Approved" : count == 1 && Status != "Rejected" ? "Approved" : "Rejected",
                            //Status = "Partial Approved",
                            FirstApproverStatus = Status,
                            SecondApproverStatus = "Pending",
                            ThirdApproverStatus = "Pending",
                            FourthApproverStatus = "Pending",
                            CreatedByUserId = HttpContext.Session.GetString("UserId"),
                            CreatedOn = DateTime.Now,
                        };

                        _context.PermitMasters.Update(permitMaster);
                    }

                    _context.SaveChanges();
                    sendmail(PermitType, Convert.ToInt32(Permitid));
                }

                else if (PermitType == "Hot Work")
                {
                    int count = 0;
                    var permitdetails = _context.HotWorkPermits.Where(a => a.PermitId == Convert.ToInt32(Permitid)).FirstOrDefault();
                    var PermitApproveDetails =
                        _context.HotWorkPermits
                        .Where(b => b.PermitId == Convert.ToInt32(Permitid))
                        .Select(a => (new HotWorkPermit { PermitId = a.PermitId, ApproverOne = a.ApproverOne, ApproverTwo = a.ApproverTwo, ApproverThree = a.ApproverThree, ApproverFour = a.ApproverFour })).FirstOrDefault();

                    if (PermitApproveDetails.ApproverOne == null)
                        count = 0;
                    else if (PermitApproveDetails.ApproverTwo == null)
                        count = 1;
                    else if (PermitApproveDetails.ApproverThree == null)
                        count = 2;
                    else if (PermitApproveDetails.ApproverFour == null)
                        count = 3;
                    else
                        count = 4;

                    var permitcheck = _context.PermitMasters.Where(a => a.PermitNumber == Permitid && a.PermitType == PermitType).FirstOrDefault();

                    if (permitcheck != null)
                    {
                        var first = permitcheck.FirstApproverStatus;
                        var second = permitcheck.SecondApproverStatus;
                        var third = permitcheck.ThirdApproverStatus;
                        var fourth = permitcheck.FourthApproverStatus;

                        // Second Approver
                        if (count >= 2 && second == "Pending")
                        {
                            permitcheck.SecondApproverStatus = Status;
                        }

                        // Third Approver
                        else if (count >= 3 && third == "Pending")
                        {
                            permitcheck.ThirdApproverStatus = Status;
                        }

                        // Fourth Approver
                        else if (count == 4 && fourth == "Pending")
                        {
                            permitcheck.FourthApproverStatus = Status;
                        }

                        if (count == 1)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }
                            else
                            {
                                permitcheck.Status = "Approved";
                            }
                        }

                        else if (count == 2)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 3)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 4)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected" && permitcheck.FourthApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending" && permitcheck.FourthApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved" && permitcheck.FourthApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        _context.PermitMasters.Update(permitcheck);
                        sendmail(PermitType, Convert.ToInt32(Permitid));
                    }

                    else
                    {

                        var permitMaster = new PermitMaster
                        {
                            Unit = permitdetails.Unit,
                            StartDate = permitdetails.StartDate,
                            EndDate = permitdetails.EndDate,
                            PermitType = PermitType,
                            PermitNumber = Permitid,
                            Location = permitdetails.Location,
                            Status = count > 1 ? "Partial Approved" : count == 1 && Status != "Rejected" ? "Approved" : "Rejected",
                            //Status = "Partial Approved",
                            FirstApproverStatus = Status,
                            SecondApproverStatus = "Pending",
                            ThirdApproverStatus = "Pending",
                            FourthApproverStatus = "Pending",
                            CreatedByUserId = HttpContext.Session.GetString("UserId"),
                            CreatedOn = DateTime.Now,
                        };

                        _context.Add(permitMaster);
                    }

                    _context.SaveChanges();
                    sendmail(PermitType, Convert.ToInt32(Permitid));
                }

                else if (PermitType == "Work At Height")
                {
                    int count = 0;
                    var permitdetails = _context.WorkAtHeightPermits.Where(a => a.PermitId == Convert.ToInt32(Permitid)).FirstOrDefault();
                    var PermitApproveDetails =
                        _context.WorkAtHeightPermits
                        .Where(b => b.PermitId == Convert.ToInt32(Permitid))
                        .Select(a => (new WorkAtHeightPermit { PermitId = a.PermitId, ApproverOne = a.ApproverOne, ApproverTwo = a.ApproverTwo, ApproverThree = a.ApproverThree, ApproverFour = a.ApproverFour })).FirstOrDefault();

                    if (PermitApproveDetails.ApproverOne == null)
                        count = 0;
                    else if (PermitApproveDetails.ApproverTwo == null)
                        count = 1;
                    else if (PermitApproveDetails.ApproverThree == null)
                        count = 2;
                    else if (PermitApproveDetails.ApproverFour == null)
                        count = 3;
                    else
                        count = 4;

                    var permitcheck = _context.PermitMasters.Where(a => a.PermitNumber == Permitid && a.PermitType == PermitType).FirstOrDefault();

                    if (permitcheck != null)
                    {
                        var first = permitcheck.FirstApproverStatus;
                        var second = permitcheck.SecondApproverStatus;
                        var third = permitcheck.ThirdApproverStatus;
                        var fourth = permitcheck.FourthApproverStatus;

                        // Second Approver
                        if (count >= 2 && second == "Pending")
                        {
                            permitcheck.SecondApproverStatus = Status;
                        }

                        // Third Approver
                        else if (count >= 3 && third == "Pending")
                        {
                            permitcheck.ThirdApproverStatus = Status;
                        }

                        // Fourth Approver
                        else if (count == 4 && fourth == "Pending")
                        {
                            permitcheck.FourthApproverStatus = Status;
                        }

                        if (count == 1)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }
                            else
                            {
                                permitcheck.Status = "Approved";
                            }
                        }

                        else if (count == 2)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 3)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 4)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected" && permitcheck.FourthApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending" && permitcheck.FourthApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved" && permitcheck.FourthApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        _context.PermitMasters.Update(permitcheck);
                    }

                    else
                    {

                        var permitMaster = new PermitMaster
                        {
                            Unit = permitdetails.Unit,
                            StartDate = permitdetails.StartDate,
                            EndDate = permitdetails.EndDate,
                            PermitType = PermitType,
                            PermitNumber = Permitid,
                            Location = permitdetails.Location,
                            Status = count > 1 ? "Partial Approved" : count == 1 && Status != "Rejected" ? "Approved" : "Rejected",
                            //Status = "Partial Approved",
                            FirstApproverStatus = Status,
                            SecondApproverStatus = "Pending",
                            ThirdApproverStatus = "Pending",
                            FourthApproverStatus = "Pending",
                            CreatedByUserId = HttpContext.Session.GetString("UserId"),
                            CreatedOn = DateTime.Now,
                        };

                        _context.Add(permitMaster);
                    }

                    _context.SaveChanges();
                }

                else if (PermitType == "Lifting Operation")
                {
                    int count = 0;
                    var permitdetails = _context.LiftingOperationPermits.Where(a => a.PermitId == Convert.ToInt32(Permitid)).FirstOrDefault();
                    var PermitApproveDetails =
                        _context.LiftingOperationPermits
                        .Where(b => b.PermitId == Convert.ToInt32(Permitid))
                        .Select(a => new LiftingOperationPermit { PermitId = a.PermitId, ApproverOne = a.ApproverOne, ApproverTwo = a.ApproverTwo, ApproverThree = a.ApproverThree, ApproverFour = a.ApproverFour }).FirstOrDefault();

                    if (PermitApproveDetails.ApproverOne == null)
                        count = 0;
                    else if (PermitApproveDetails.ApproverTwo == null)
                        count = 1;
                    else if (PermitApproveDetails.ApproverThree == null)
                        count = 2;
                    else if (PermitApproveDetails.ApproverFour == null)
                        count = 3;
                    else
                        count = 4;

                    var permitcheck = _context.PermitMasters.Where(a => a.PermitNumber == Permitid && a.PermitType == PermitType).FirstOrDefault();

                    if (permitcheck != null)
                    {
                        var first = permitcheck.FirstApproverStatus;
                        var second = permitcheck.SecondApproverStatus;
                        var third = permitcheck.ThirdApproverStatus;
                        var fourth = permitcheck.FourthApproverStatus;

                        // Second Approver
                        if (count >= 2 && second == "Pending")
                        {
                            permitcheck.SecondApproverStatus = Status;
                        }

                        // Third Approver
                        else if (count >= 3 && third == "Pending")
                        {
                            permitcheck.ThirdApproverStatus = Status;
                        }

                        // Fourth Approver
                        else if (count == 4 && fourth == "Pending")
                        {
                            permitcheck.FourthApproverStatus = Status;
                        }

                        if (count == 1)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }
                            else
                            {
                                permitcheck.Status = "Approved";
                            }
                        }

                        else if (count == 2)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 3)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 4)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected" && permitcheck.FourthApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending" && permitcheck.FourthApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved" && permitcheck.FourthApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        _context.PermitMasters.Update(permitcheck);
                        sendmail(PermitType, Convert.ToInt32(Permitid));
                    }

                    else
                    {

                        var permitMaster = new PermitMaster
                        {
                            Unit = permitdetails.Unit,
                            StartDate = permitdetails.StartDate,
                            EndDate = permitdetails.EndDate,
                            PermitType = PermitType,
                            PermitNumber = Permitid,
                            Location = permitdetails.Location,
                            Status = count > 1 ? "Partial Approved" : count == 1 && Status != "Rejected" ? "Approved" : "Rejected",
                            //Status = "Partial Approved",
                            FirstApproverStatus = Status,
                            SecondApproverStatus = "Pending",
                            ThirdApproverStatus = "Pending",
                            FourthApproverStatus = "Pending",
                            CreatedByUserId = HttpContext.Session.GetString("UserId"),
                            CreatedOn = DateTime.Now,
                        };

                        _context.Add(permitMaster);
                    }

                    _context.SaveChanges();
                    sendmail(PermitType, Convert.ToInt32(Permitid));
                }

                else if (PermitType == "Electrical Isolation")
                {
                    int count = 0;
                    var permitdetails = _context.ElectricalIsolationPermits.Where(a => a.PermitId == Convert.ToInt32(Permitid)).FirstOrDefault();
                    var PermitApproveDetails =
                        _context.ElectricalIsolationPermits
                        .Where(b => b.PermitId == Convert.ToInt32(Permitid))
                        .Select(a => (new ElectricalIsolationPermit { PermitId = a.PermitId, ApproverOne = a.ApproverOne, ApproverTwo = a.ApproverTwo, ApproverThree = a.ApproverThree, ApproverFour = a.ApproverFour })).FirstOrDefault();

                    if (PermitApproveDetails.ApproverOne == null)
                        count = 0;
                    else if (PermitApproveDetails.ApproverTwo == null)
                        count = 1;
                    else if (PermitApproveDetails.ApproverThree == null)
                        count = 2;
                    else if (PermitApproveDetails.ApproverFour == null)
                        count = 3;
                    else
                        count = 4;

                    var permitcheck = _context.PermitMasters.Where(a => a.PermitNumber == Permitid && a.PermitType == PermitType).FirstOrDefault();

                    if (permitcheck != null)
                    {
                        var first = permitcheck.FirstApproverStatus;
                        var second = permitcheck.SecondApproverStatus;
                        var third = permitcheck.ThirdApproverStatus;
                        var fourth = permitcheck.FourthApproverStatus;

                        // Second Approver
                        if (count >= 2 && second == "Pending")
                        {
                            permitcheck.SecondApproverStatus = Status;
                        }

                        // Third Approver
                        else if (count >= 3 && third == "Pending")
                        {
                            permitcheck.ThirdApproverStatus = Status;
                        }

                        // Fourth Approver
                        else if (count == 4 && fourth == "Pending")
                        {
                            permitcheck.FourthApproverStatus = Status;
                        }

                        if (count == 1)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }
                            else
                            {
                                permitcheck.Status = "Approved";
                            }
                        }

                        else if (count == 2)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 3)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 4)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected" && permitcheck.FourthApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending" && permitcheck.FourthApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved" && permitcheck.FourthApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        _context.PermitMasters.Update(permitcheck);
                    }

                    else
                    {

                        var permitMaster = new PermitMaster
                        {
                            Unit = permitdetails.Unit,
                            StartDate = permitdetails.StartDate,
                            EndDate = permitdetails.EndDate,
                            PermitType = PermitType,
                            PermitNumber = Permitid,
                            Location = permitdetails.Location,
                            Status = count > 1 ? "Partial Approved" : count == 1 && Status != "Rejected" ? "Approved" : "Rejected",
                            //Status = "Partial Approved",
                            FirstApproverStatus = Status,
                            SecondApproverStatus = "Pending",
                            ThirdApproverStatus = "Pending",
                            FourthApproverStatus = "Pending",
                            CreatedByUserId = HttpContext.Session.GetString("UserId"),
                            CreatedOn = DateTime.Now,
                        };

                        _context.Add(permitMaster);
                    }

                    _context.SaveChanges();
                }

                else if (PermitType == "Confined Space")
                {
                    int count = 0;
                    var permitdetails = _context.ConfinedSpacePermits.Where(a => a.Id == Convert.ToInt32(Permitid)).FirstOrDefault();
                    var PermitApproveDetails = _context.ConfinedSpacePermits.Where(b => b.Id == Convert.ToInt32(Permitid))
                       .Select(a => (new ConfinedSpacePermit { Id = a.Id, ApproverOne = a.ApproverOne, ApproverTwo = a.ApproverTwo, ApproverThree = a.ApproverThree, ApproverFour = a.ApproverFour })).FirstOrDefault();

                    if (PermitApproveDetails.ApproverOne == null)
                        count = 0;
                    else if (PermitApproveDetails.ApproverTwo == null)
                        count = 1;
                    else if (PermitApproveDetails.ApproverThree == null)
                        count = 2;
                    else if (PermitApproveDetails.ApproverFour == null)
                        count = 3;
                    else
                        count = 4;

                    var permitcheck = _context.PermitMasters.Where(a => a.PermitNumber == Permitid && a.PermitType == PermitType).FirstOrDefault();

                    if (permitcheck != null)
                    {
                        var first = permitcheck.FirstApproverStatus;
                        var second = permitcheck.SecondApproverStatus;
                        var third = permitcheck.ThirdApproverStatus;
                        var fourth = permitcheck.FourthApproverStatus;

                        // Second Approver
                        if (count >= 2 && second == "Pending")
                        {
                            permitcheck.SecondApproverStatus = Status;
                        }

                        // Third Approver
                        else if (count >= 3 && third == "Pending")
                        {
                            permitcheck.ThirdApproverStatus = Status;
                        }

                        // Fourth Approver
                        else if (count == 4 && fourth == "Pending")
                        {
                            permitcheck.FourthApproverStatus = Status;
                        }

                        if (count == 1)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }
                            else
                            {
                                permitcheck.Status = "Approved";
                            }
                        }

                        else if (count == 2)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 3)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        else if (count == 4)
                        {

                            if (permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected" && permitcheck.ThirdApproverStatus == "Rejected" && permitcheck.FourthApproverStatus == "Rejected")
                            {
                                permitcheck.Status = "Rejected";
                            }

                            else if (permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending" && permitcheck.ThirdApproverStatus != "Pending" && permitcheck.FourthApproverStatus != "Pending")
                            {

                                if (permitcheck.FirstApproverStatus == "Approved" && permitcheck.SecondApproverStatus == "Approved" && permitcheck.ThirdApproverStatus == "Approved" && permitcheck.FourthApproverStatus == "Approved")
                                {
                                    permitcheck.Status = "Approved";
                                }

                                else
                                    permitcheck.Status = "Partial Approved";
                            }
                        }

                        _context.PermitMasters.Update(permitcheck);
                    }

                    else
                    {

                        var permitMaster = new PermitMaster
                        {
                            Unit = permitdetails.Unit,
                            StartDate = permitdetails.StartDate,
                            EndDate = permitdetails.EndDate,
                            PermitType = PermitType,
                            PermitNumber = Permitid,
                            Location = permitdetails.Location,
                            Status = count > 1 ? "Partial Approved" : count == 1 && Status != "Rejected" ? "Approved" : "Rejected",
                            //Status = "Partial Approved",
                            FirstApproverStatus = Status,
                            SecondApproverStatus = "Pending",
                            ThirdApproverStatus = "Pending",
                            FourthApproverStatus = "Pending",
                            CreatedByUserId = HttpContext.Session.GetString("UserId"),
                            CreatedOn = DateTime.Now,
                        };

                        _context.Add(permitMaster);
                    }

                    _context.SaveChanges();
                }

                if (Status == "Approved")
                    return Json("Approved Successfully");
                else
                    return Json("Rejected Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex.Message.ToString());
                return Json(ex.Message);
            }
        }
            

            [HttpPost]
            public JsonResult Delete(string type, int id)
            {
                if (type == "Cold Work")
                {
                    var permit = _context.ColdWorkPermits.FirstOrDefault(x => x.Id == id && x.IsActive == true);

                    if (permit != null)
                    {
                        permit.IsActive = false;
                        _context.SaveChanges();

                        return Json(new { success = true });
                    }
                }

                else if (type == "Hot Work")
                {
                    var permit = _context.HotWorkPermits.FirstOrDefault(x => x.PermitId == id && x.IsActive == true);

                    if (permit != null)
                    {
                        permit.IsActive = false;
                        _context.SaveChanges();

                        return Json(new { success = true });
                    }
                }

                else if (type == "Work At Height")
                {
                    var permit = _context.WorkAtHeightPermits.FirstOrDefault(x => x.PermitId == id && x.IsActive == true);

                    if (permit != null)
                    {
                        permit.IsActive = false;
                        _context.SaveChanges();

                        return Json(new { success = true });
                    }
                }

                else if (type == "Lifting Operation")
                {
                    var permit = _context.LiftingOperationPermits.FirstOrDefault(x => x.PermitId == id && x.IsActive == true);

                    if (permit != null)
                    {
                        permit.IsActive = false;
                        _context.SaveChanges();

                        return Json(new { success = true });
                    }
                }

                else if (type == "Electrical Isolation")
                {
                    var permit = _context.ElectricalIsolationPermits.FirstOrDefault(x => x.PermitId == id && x.IsActive == true);

                    if (permit != null)
                    {
                        permit.IsActive = false;
                        _context.SaveChanges();

                        return Json(new { success = true });
                    }
                }

                else if (type == "Confined Space")
                {
                    var permit = _context.ConfinedSpacePermits.FirstOrDefault(x => x.Id == id);

                    if (permit != null)
                    {
                        permit.IsActive = false;
                        _context.SaveChanges();

                        return Json(new { success = true });
                    }
                }

                return Json(new
                {
                    success = false,
                    message = "Permit not Found."
                });
            }

            //public IActionResult Delete(string type, int id)
            //{
            //    // handle delete based on type
            //    return RedirectToAction("Dashboard");
            //}


            public IActionResult Extend(string type, int id)
            {
                return RedirectToAction("Dashboard");
            }
            public IActionResult Success()
            {
                return View();
            }
            public IActionResult LoadJSA(string type)
            {
                if (type == "cutting")
                    return PartialView("_JSA_Cutting");

                return Content("No data found");
            }

            public IActionResult LoadRA(string type)
            {
                if (type == "excavation")
                    return PartialView("_RA_Excavation");

                return Content("No data found");
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            //[HttpPost]
            //public IActionResult ExtendPermit(int PermitId, DateTime NewEndDate)
            //{
            //    var permit = _context.Permits.Find(PermitId);
            //    permit.EndDate = NewEndDate;
            //    permit.Status = "Extended";
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
        }

    }

