using Microsoft.AspNetCore.Mvc;
using Permit_to_work.Data;

namespace Permit_to_work.Controllers
{
  
    public class ColdWorkController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ColdWorkController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Edit(int id)
        {
            var Coldpermit = _context.ColdWorkPermits.FirstOrDefault(x => x.Id == id);
            return View("~/Views/Home/workpermitform.cshtml", Coldpermit);
        }
    }
}
