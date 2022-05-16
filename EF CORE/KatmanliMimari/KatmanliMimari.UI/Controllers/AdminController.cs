using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliMimari.UI.Controllers
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class AdminController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }



        public IActionResult Role()
        {
            return View();
        }
    }
}
