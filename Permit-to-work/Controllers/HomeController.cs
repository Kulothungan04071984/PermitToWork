using Microsoft.AspNetCore.Mvc;
using Permit_to_work.Data;
using Permit_to_work.Models;
using System.Diagnostics;

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

        public IActionResult workpermitform()
        {
            return View(new ColdWorkPermitVM());
        }

        [HttpPost]
        public IActionResult workpermitform(ColdWorkPermitVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var entity = new ColdWorkPermitVM
            {
                Unit = vm.Unit,
                ContractorTeam = vm.ContractorTeam,
                Location = vm.Location,
                NoOfWorkmen = vm.NoOfWorkmen,
                StartDate = vm.StartDate,
                StartTime = vm.StartTime,
                EndDate = vm.EndDate,
                EndTime = vm.EndTime,
                WorkDescription = vm.WorkDescription,
                ToolsEquipment = vm.ToolsEquipment,
                RiskFallHeight = vm.RiskFallHeight,
                RiskWeather = vm.RiskWeather,
                RiskFlying = vm.RiskFlying,
                PPEHelmet = vm.PPEHelmet,
                PPEShoes = vm.PPEShoes,
                PPEGloves = vm.PPEGloves,
                ReceiverName = vm.ReceiverName,
                IssuerName = vm.IssuerName,
                InsuranceAvailable = true
            };

            _context.ColdWorkPermits.Add(entity);
            _context.SaveChanges();
            return RedirectToAction("Success");
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
        public IActionResult Dashboard()
        {
            var dashboard = new List<PermitDashboardVM>();

            dashboard.AddRange(
                _context.HotWorkPermits.Select(x => new PermitDashboardVM
                {
                    PermitId = x.PermitId,
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
                    PermitId = x.PermitId,
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
                    PermitId = x.PermitId,
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
                    PermitId = x.PermitId,
                    PermitType = "Electrical Isolation",
                    Unit = x.Unit,
                    Location = x.Location,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = "Active"
                })
            );

            return View(dashboard.OrderByDescending(x => x.StartDate));
        }

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
    }
}
