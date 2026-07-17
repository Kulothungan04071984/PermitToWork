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
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
            return View(new ColdWorkPermitVM());
        }

        [HttpPost]
        public IActionResult workpermitform(ColdWorkPermitVM vm)
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

            var entity = new ColdWorkPermitVM
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

                // ── Tools Tested ───────────────────────────
                ToolsTested = vm.ToolsTested,

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

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("employeetraining@syrmasgs.com");
            mail.To.Add("kulothungan.k@syrmasgs.com");
            mail.Subject = "Request to Reschedule";
            mail.Body = @"Hi,

                    I will not be available on May 8. Could you please reschedule for another date?

                    Thank you.";

            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
            smtp.Credentials = new NetworkCredential("employeetraining@syrmasgs.com", "Permit@123");
            smtp.EnableSsl = true;

            smtp.Send(mail);

            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> Hotwork(HotWorkPermit model)
        {
            if (!model.Welding &&
                !model.ChippingCuttingGrinding)
            {
                ModelState.AddModelError("WorkType", "Please select at least one Work Type.");
            }

            else if (!model.Electrocution &&
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
                string.IsNullOrWhiteSpace (model.AttachOther))
            {
                ModelState.AddModelError("Risk", "Please select at least one Risk.");
            }

            else if (string.IsNullOrWhiteSpace(model.EmergencyTeamAvailable) &&
                string.IsNullOrWhiteSpace(model.EmergencyContact1) &&
                string.IsNullOrWhiteSpace(model.EmergencyContact2) &&
                string.IsNullOrWhiteSpace(model.EmergencyContact3) &&
                string.IsNullOrWhiteSpace(model.ToolsTested))
            {
                ModelState.AddModelError("EmergencyTeam", "Please select at least one Emergency Team.");
            }

            else if (!model.WC &&
                !model.ESI)
            {
                ModelState.AddModelError("Insurance", "Please select at least one Insurance.");
            }

            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState)
                {
                    if (item.Value.Errors.Count > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"Field: {item.Key}");

                        foreach (var err in item.Value.Errors)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error: {err.ErrorMessage}");
                        }
                    }
                }

                return View(model);
            }

            var entity = new HotWorkPermit
            {
                // ── Basic Details ────────────────────────────────────────
                Unit = model.Unit,
                ContractorName = model.ContractorName,
                Location = model.Location,
                NoOfWorkmen = model.NoOfWorkmen,

                // ── Dates & Times ────────────────────────────────────────
                StartDate = model.StartDate,
                StartTime = model.StartTime,
                EndDate = model.EndDate,
                EndTime = model.EndTime,

                // ── Work Type ─────────────────────────────────────────
                Welding = model.Welding,
                ChippingCuttingGrinding = model.ChippingCuttingGrinding,

                // ── Work Details ─────────────────────────────────────────
                WorkDescription = model.WorkDescription,
                ToolsEquipment = model.ToolsEquipment,

                // ── Risk ─────────────────────────────────────────
                Electrocution = model.Electrocution,
                ArcFlash = model.ArcFlash,
                FlyingParticles = model.FlyingParticles,
                Noise = model.Noise,
                ProtrudingObjects = model.ProtrudingObjects,
                TrippingSlipping = model.TrippingSlipping,
                ElectricShock = model.ElectricShock,
                FireSpark = model.FireSpark,
                ManualHandling = model.ManualHandling,
                HotBurn = model.HotBurn,
                Explosion = model.Explosion,
                HealthHazard = model.HealthHazard,
                FumeSmoke = model.FumeSmoke,
                AttachOther = model.AttachOther,

                // ── Documents ────────────────────────────────────────────
                AttachJSA = model.AttachJSA,

                // ── Certification & Safety ────────────────────────────────────────────
                CombustibleRemoved = model.CombustibleRemoved,

                // ── Regulators ────────────────────────────────────────────
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

                // ── PPE ────────────────────────────────────────────
                Helmet = model.Helmet,
                SafetyShoes = model.SafetyShoes,
                WeldingGloves = model.WeldingGloves,
                FaceShield = model.FaceShield,
                WeldingGoggles = model.WeldingGoggles,
                Apron = model.Apron,
                GasMask = model.GasMask,
                EarPlugs = model.EarPlugs,
                WeldingShield  = model.WeldingShield,
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
                ApproverThree = model. ApproverThree,
                ApproverFour = model.ApproverFour,

                // ── Meta ─────────────────────────────────────────────────
                CreatedOn = DateTime.Now,
                
            };

            entity.Status = "Pending";

            _context.HotWorkPermits.Add(entity);
            await _context.SaveChangesAsync();

            return RedirectToAction("Hotwork");
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
        public IActionResult ElectricalIsolationPermit()
        {
            return View();
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

   
        [HttpPost]
        public async Task<IActionResult> ElectricalIsolationPermit(ElectricalIsolationPermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.ElectricalIsolationPermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }
       
        public IActionResult ConfinedSpace()
        {
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> ConfinedSpace(ConfinedSpacePermit model)
        {
            if (!ModelState.IsValid)
                return View(model);

          

            _context.ConfinedSpacePermits.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("ConfinedSpace");
        }


        public IActionResult Home()
        {
            return View();
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
