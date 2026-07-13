using Registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Permit_to_work.Data;
using Permit_to_work.Models;
using Permit_to_work.ViewModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var isExistUser=_context.Logins.Any(a=>a.Username == emp.Username);
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
                ModelState.AddModelError("","Username already exits. Please enter another username.");
                return View("Registration",emp);
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
        public IActionResult workpermitform(ColdWorkPermit vm)
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
                     string.IsNullOrWhiteSpace(vm.InspectOther)&&
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

                // ── Associated Permits ────────────────────────────────
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

            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    mail.From = new MailAddress(_configuration["SmtpSettings:User"]);
            //    mail.To.Add("kulothungan.k@syrmasgs.com");
            //    mail.Subject = "Request to Reschedule";
            //    mail.Body = "Test Mail";

            //    using (SmtpClient smtp = new SmtpClient(
            //        _configuration["SmtpSettings:Host"],
            //        int.Parse(_configuration["SmtpSettings:Port"])))
            //    {
            //        smtp.EnableSsl = true;
            //        smtp.UseDefaultCredentials = false;
            //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //        smtp.Credentials = new NetworkCredential(
            //            _configuration["SmtpSettings:User"],
            //            _configuration["SmtpSettings:Password"]);
            //        // smtp.Send(mail); Testing purpose, comment out to avoid actual email sending
            //    }
            //}
            //catch (Exception ex)

            return RedirectToAction("Dashboard");
        }

        // HOT WORK PERMIT

        [HttpPost]
        public async Task<IActionResult> Hotwork(HotWorkPermit model)
        {

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    Console.WriteLine(error.Key);

                    foreach (var e in error.Value.Errors)
                    {
                        Console.WriteLine(e.ErrorMessage);
                    }
                }
                return View(model);
            }

            model.Status = "Pending";

            _context.HotWorkPermits.Add(model);
            await _context.SaveChangesAsync();

            var entity = new HotWorkPermit
            {
                // ── Basic Details ──────────────────────────────────────
                Unit = model.Unit,
                ContractorName = model.ContractorName,
                Location = model.Location,
                NoOfWorkmen = model.NoOfWorkmen,

                // ── Dates & Times ──────────────────────────────────────
                StartDate = model.StartDate,
                StartTime = model.StartTime,
                EndDate = model.EndDate,
                EndTime = model.EndTime,

                // ── Work Type ────────────────────────────────────
                Welding = model.Welding,
                ChippingCuttingGrinding = model.ChippingCuttingGrinding,

                // ── Work ───────────────────────────────────────
                WorkDescription = model.WorkDescription,

                // ── Tools ───────────────────────────────────────
                ToolsEquipment = model.ToolsEquipment,

                // ── Risk Identification ────────────────────────────────
                AttachOther = model.AttachOther,

                // ── Documents to Attach ─────────────────────────────────────────
                AttachJSA = model.AttachJSA,
                AttachRiskAssessment = model.AttachRiskAssessment,

                // ── Certification & Safety Checks ──────────────────────────
                CombustibleRemoved = model.CombustibleRemoved,

                // ── Regulators & Gauges ────────────────────────────────
                FlashbackArrestors = model.FlashbackArrestors,
                CylindersProvided = model.CylindersProvided,

                // ── Emergency Team ─────────────────────────────────────────
                EmergencyTeamAvailable = model.EmergencyTeamAvailable,
                //ESI = vm.ESI,

                // ── Inspected Areas ───────────────────────────────────
                //InspectAccess = vm.InspectAccess,
                //InspectDangerSign = vm.InspectDangerSign,
                //InspectLighting = vm.InspectLighting,
                //InspectSafetyBarriers = vm.InspectSafetyBarriers,
                //InspectHandTools = vm.InspectHandTools,
                //InspectOther = vm.InspectOther,
                //InspectedNA = vm.InspectedNA,

                // ── PPE Required ──────────────────────────────────────
                //PPEHelmet = vm.PPEHelmet,
                //PPEShoes = vm.PPEShoes,
                //PPEGloves = vm.PPEGloves,
                //PPEGoggles = vm.PPEGoggles,
                //PPEDustMask = vm.PPEDustMask,
                //PPEEarPlugs = vm.PPEEarPlugs,
                //PPEReflectiveVest = vm.PPEReflectiveVest,
                //PPEHarness = vm.PPEHarness,
                //PPEOther = vm.PPEOther,
                //PPENA = vm.PPENA,

                // ── Authorization ─────────────────────────────────────
                //ReceiverName = vm.ReceiverName,
                //ReceiverDate = vm.ReceiverDate,
                //IssuerName = vm.IssuerName,
                //IssuerDate = vm.IssuerDate,

                // ── Suspension / Clearance ────────────────────────────
                //Name = vm.Name,
                //SuspensionDate = vm.SuspensionDate,

                //── Approver Details ───────────────────────────────────

                //ApproverOne = vm.ApproverOne,
                //ApproverTwo = vm.ApproverTwo,
                //ApproverThree = vm.ApproverThree,
                //ApproverFour = vm.ApproverFour,

                // ── Meta ──────────────────────────────────────────────
                CreatedOn = DateTime.Now,
                //IsActive = true
            };

            return RedirectToAction("Success");


        }

        public IActionResult Hotwork()
        {
            return View(); 
        }

       

        // LIFTING OPERATION PERMIT

        [HttpPost]
        public async Task<IActionResult> Liftingoperation(LiftingOperationPermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.LiftingOperationPermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        public IActionResult Liftingoperation()
        {
            return View();
        }


       // WORK AT HEIGHT PERMIT

        [HttpPost]
        public async Task<IActionResult> WorkAtHeightPermit(WorkAtHeightPermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.WorkAtHeightPermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        public IActionResult WorkAtHeightPermit()
        {
            return View();
        }

        // ELECTRICAL ISOLATION PERMIT 
        [HttpPost]
        public async Task<IActionResult> ElectricalIsolationPermit(ElectricalIsolationPermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.ElectricalIsolationPermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        public IActionResult ElectricalIsolationPermit()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public JsonResult GetApprovalStatus(int id, string type)
        {
            var status = _context.ColdWorkPermits; 
            //if (type == "ColdWork")
            //    status = _context.ColdWorkPermits;
            //else if (type == "HotWork")
            //    status = _context.HotWorkPermits;
            //else if (type == "LiftingOperation")
            //    status = _context.LiftingOperationPermits;
            //else if (type == "WorkAtHeight")
            //    status = _context.WorkAtHeightPermits;
            //else if (type == "ElectricalIsolation")
            //    status = _context.ElectricalIsolationPermits;


            var result = status
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    x.ApproverOne ,
                    ApproverTwo = x.ApproverTwo ?? "EMPTY",
                    ApproverThree = x.ApproverThree ?? "EMPTY",
                    ApproverFour = x.ApproverFour ?? "EMPTY"
                })
                .FirstOrDefault();

            return Json(result);
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
                _context.ColdWorkPermits.Where(x => x.IsActive).Select(x => new PermitDashboardVM
                {
                    PermitDashBoardId = x.Id,
                    PermitType = "Cold Work",
                    Unit = x.Unit,
                    Location = x.Location,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id).Select(p => p.Status).FirstOrDefault(),

                    Count = (x.ApproverOne != null ? 4 : x.ApproverTwo != null ? 3 : x.ApproverThree != null ? 2 : x.ApproverFour != null ? 1 : 0),

                    FirstApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id).Select(p => p.FirstApproverStatus).FirstOrDefault(),
                    SecondApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id).Select(p => p.SecondApproverStatus).FirstOrDefault(),
                    ThirdApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id).Select(p => p.ThirdApproverStatus).FirstOrDefault(),
                    FourthApprovalStatus = _context.PermitMasters.Where(p => Convert.ToInt32(p.PermitNumber) == x.Id).Select(p => p.FourthApproverStatus).FirstOrDefault(),
                })
            );
            dashboard.AddRange(
                _context.HotWorkPermits.Select(x => new PermitDashboardVM
                {
                    PermitDashBoardId = x.PermitId,
                    PermitType = "Hot Work",
                    Unit = x.Unit,
                    Location = x.Location,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = "Active",
                })
            );

            dashboard.AddRange(
                _context.LiftingOperationPermits.Select(x => new PermitDashboardVM
                {
                    PermitDashBoardId = x.PermitId,
                    PermitType = "Lifting Operation",
                    Unit = x.Unit,
                    Location = x.Location,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = "Active"
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
                    Status = "Active"
                })
            );

            dashboard.AddRange(
                _context.ElectricalIsolationPermits.Select(x => new PermitDashboardVM
                {
                    PermitDashBoardId = x.PermitId,
                    PermitType = "Electrical Isolation",
                    Unit = x.Unit,
                    Location = x.Location,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = "Active"
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

            if (PermitType == "Cold Work")
            {
                int count = 0;
                var permitdetails = _context.ColdWorkPermits.Where(a => a.Id == Convert.ToInt32(Permitid)).FirstOrDefault();
                var PermitApproveDetails =
                    _context.ColdWorkPermits
                    .Where(b => b.Id == Convert.ToInt32(Permitid))
                    .Select(a => (new ColdWorkPermitVM { Id = a.Id, ApproverOne = a.ApproverOne, ApproverTwo = a.ApproverTwo, ApproverThree = a.ApproverThree, ApproverFour = a.ApproverFour })).FirstOrDefault();

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
                    if(count >= 2 && second == "Pending")
                    {
                        permitcheck.SecondApproverStatus = Status;
                    }

                    // Third Approver
                    else if(count >= 3 && third == "Pending")
                    {
                        permitcheck.ThirdApproverStatus = Status;
                    }

                    // Fourth Approver
                    else if (count == 4 && fourth == "Pending")
                    {
                        permitcheck.FourthApproverStatus = Status;
                    }

                    if(count == 1)
                    {

                        if(permitcheck.FirstApproverStatus == "Rejected")
                        {
                            permitcheck.Status = "Rejected";
                        }
                        else
                        {
                            permitcheck.Status = "Approved";
                        }
                    }

                    else if(count == 2)
                    {

                        if(permitcheck.FirstApproverStatus == "Rejected" && permitcheck.SecondApproverStatus == "Rejected")
                        {
                            permitcheck.Status = "Rejected";
                        }
                        
                        else if(permitcheck.FirstApproverStatus != "Pending" && permitcheck.SecondApproverStatus != "Pending")
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
                        Status = count == 1 && Status != "Rejected" ? "Approved" : "Rejected",
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

        [HttpPost]
        public JsonResult Delete (string type, int id)
        {
            if(type == "Cold Work")
            {
                var permit = _context.ColdWorkPermits.FirstOrDefault(x => x.Id == id);

                if(permit != null)
                {
                    permit.IsActive = false;
                    _context.SaveChanges();

                    return Json(new {success = true});
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
