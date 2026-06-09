using Microsoft.AspNetCore.Mvc;
using Permit_to_work.Data;

namespace Permit_to_work.Controllers
{
<<<<<<< HEAD
=======
  
>>>>>>> faccccd7e844f04b57a176035fe543f761ff19d4
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
<<<<<<< HEAD
}
=======
}
>>>>>>> faccccd7e844f04b57a176035fe543f761ff19d4
