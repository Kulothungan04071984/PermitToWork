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


        public IActionResult Hotwork()
        {
            return View(); 
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
