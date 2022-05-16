using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
           ViewBag.UserName = HttpContext.Session.GetString("UserName");
          
            //if (ViewBag.UserName==null)
            //{
            //    return RedirectToAction("Index","Home");

            //}
            return View();
        }
    }
}
