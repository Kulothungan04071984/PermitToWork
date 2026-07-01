using Microsoft.AspNetCore.Mvc;
using Permit_to_work.Data;
using Permit_to_work.Models;
using Permit_to_work.ViewModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

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

        //public IActionResult workpermitform()
        //{
        //    return View(new ColdWorkPermitVM());
        //}

        //[HttpPost]
        //public IActionResult workpermitform(ColdWorkPermitVM vm)
        //{
        //    if (!ModelState.IsValid)
        //        return View(vm);

        //    var entity = new ColdWorkPermitVM
        //    {              
        //        Unit = vm.Unit,
        //        ContractorTeam = vm.ContractorTeam,
        //        Location = vm.Location,
        //        NoOfWorkmen = vm.NoOfWorkmen,
        //        StartDate = vm.StartDate,
        //        StartTime = vm.StartTime,
        //        EndDate = vm.EndDate,
        //        EndTime = vm.EndTime,
        //        WorkDescription = vm.WorkDescription,
        //        ToolsEquipment = vm.ToolsEquipment,
        //        RiskFallHeight = vm.RiskFallHeight,
        //        RiskWeather = vm.RiskWeather,
        //        RiskFlying = vm.RiskFlying,
        //        PPEHelmet = vm.PPEHelmet,
        //        PPEShoes = vm.PPEShoes,
        //        PPEGloves = vm.PPEGloves,
        //        ReceiverName = vm.ReceiverName,
        //        IssuerName = vm.IssuerName               
        //    };

        //    if (vm.Id > 0)
        //    {
        //        entity.Id = vm.Id;
        //        _context.ColdWorkPermits.Update(entity);
        //    }
        //    else
        //        _context.ColdWorkPermits.Add(entity);

        //    _context.SaveChanges();

        //    return RedirectToAction("Dashboard");
        //    //return View();

        //    //return RedirectToAction("Success");
        //    //test
        //   // return View();

        //}

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
                // ── Basic Details ────────────────────────────────────────
                Unit = vm.Unit,
                ContractorTeam = vm.ContractorTeam,
                Location = vm.Location,
                NoOfWorkmen = vm.NoOfWorkmen,

                // ── Dates & Times ────────────────────────────────────────
                StartDate = vm.StartDate,
                StartTime = vm.StartTime,
                EndDate = vm.EndDate,
                EndTime = vm.EndTime,

                // ── Work & Tools ─────────────────────────────────────────
                WorkDescription = vm.WorkDescription,
                ToolsEquipment = vm.ToolsEquipment,

                // ── Risk Identification ──────────────────────────────────
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
                RiskOther = vm.RiskOther,

                // ── Documents ────────────────────────────────────────────
                DocJSA = vm.DocJSA,
                DocRiskAssessment = vm.DocRiskAssessment,
                DocOther = vm.DocOther,

                // ── Precaution & Tools Tested ────────────────────────────
                Precaution = vm.Precaution,
                ToolsTested = vm.ToolsTested,

                // ── Hazards Identified ───────────────────────────────────
                HazardWorkAtHeight = vm.HazardWorkAtHeight,
                HazardScaffolding = vm.HazardScaffolding,
                HazardToolEquipment = vm.HazardToolEquipment,
                HazardChemical = vm.HazardChemical,
                HazardElectrical = vm.HazardElectrical,
                HazardLifting = vm.HazardLifting,
                HazardHotSurface = vm.HazardHotSurface,
                HazardDust = vm.HazardDust,
                HazardNA = vm.HazardNA,

                // ── Associated Permits ───────────────────────────────────
                PermitHotWork = vm.PermitHotWork,
                PermitWorkAtHeight = vm.PermitWorkAtHeight,
                PermitExcavation = vm.PermitExcavation,
                PermitElectrical = vm.PermitElectrical,
                PermitConfinedSpace = vm.PermitConfinedSpace,
                PermitOther = vm.PermitOther,
                PermitAssociated = vm.PermitAssociated,

                // ── Insurance ────────────────────────────────────────────
                WC = vm.WC,
                ESI = vm.ESI,

                // ── Inspected Areas ──────────────────────────────────────
                InspectAccess = vm.InspectAccess,
                InspectDangerSign = vm.InspectDangerSign,
                InspectLighting = vm.InspectLighting,
                InspectSafetyBarriers = vm.InspectSafetyBarriers,
                InspectHandTools = vm.InspectHandTools,
                InspectOther = vm.InspectOther,
                InspectedNA = vm.InspectedNA,

                // ── PPE Required ─────────────────────────────────────────
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

                // ── Authorization ────────────────────────────────────────
                ReceiverName = vm.ReceiverName,
                ReceiverDate = vm.ReceiverDate,
                IssuerName = vm.IssuerName,
                IssuerDate = vm.IssuerDate,

                // ── Suspension / Clearance ───────────────────────────────
                Name = vm.Name,
                SuspensionDate = vm.SuspensionDate,

                //--Approver Details -------------------------------------

                ApproverOne=vm.ApproverOne,
                ApproverTwo=vm.ApproverTwo,
                ApproverThree=vm.ApproverThree,
                ApproverFour=vm.ApproverFour,

                // ── Meta ─────────────────────────────────────────────────
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
            //{
            //    Console.WriteLine($"Mail send failed: {ex.Message}");
            //}

            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> Hotwork(HotWorkPermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Status = "Pending";

            _context.HotWorkPermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        public IActionResult Hotwork()
        {
            return View(); 
        }


        public IActionResult Liftingoperation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Liftingoperation(LiftingOperationPermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.LiftingOperationPermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        public IActionResult WorkAtHeightPermit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkAtHeightPermit(WorkAtHeightPermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.WorkAtHeightPermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        public IActionResult ElectricalIsolationPermit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ElectricalIsolationPermit(ElectricalIsolationPermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.ElectricalIsolationPermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
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
           // PermitDashboardVM objPermitDetails = new PermitDashboardVM();
            objpermit.PermitTypes = _context.PermitTypeMasters.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.PermitTypeId.ToString(), Text = x.PermitTypeName }).ToList();
            objpermit.Departments = _context.DepartmentMasters.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.DepartmentId.ToString(), Text = x.DepartmentName }).ToList();
            objpermit.Units = _context.UnitMasters.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.UnitId.ToString(), Text = x.UnitName }).ToList();
            objpermit.Approvers = _context.ApproverMasters.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = x.ApproverId.ToString(), Text = x.ApproverName }).ToList();

            var dashboard = new List<PermitDashboardVM>();


            dashboard.AddRange(
                _context.ColdWorkPermits.Select(x => new PermitDashboardVM
                {
                    PermitDashBoardId = x.Id,
                    PermitType = "Cold Work",
                    Unit = x.Unit,
                    Location = x.Location,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = "Active"
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
                    Status = "Active"
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
            // return View(dashboard.OrderByDescending(x => x.StartDate));
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
        public IActionResult Delete(string type, int id)
        {
            // handle delete based on type
            return RedirectToAction("Dashboard");
        }

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
