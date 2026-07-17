using Microsoft.AspNetCore.Mvc;
using Permit_to_work.Data;
using Permit_to_work.Models;

namespace Permit_to_work.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public LoginController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
               var result=_context.Logins.Any(a=>a.Username == model.Username && a.Password == model.Password && a.isActive == true);
                if(result)
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password. Please try again.");
                }
                   
            }
            return View(model);
        }
    }
}
