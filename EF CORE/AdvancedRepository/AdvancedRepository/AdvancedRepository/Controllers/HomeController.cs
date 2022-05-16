using AdvancedRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdvancedRepository.Extensions;
using AdvancedRepository.DTOs;

namespace AdvancedRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var baskets= HttpContext.Session.Get<List<Basket>>("Basket");
          
            if (baskets != null)
            {
                ViewBag.Count = baskets.Count;
            }

            
            else
                ViewBag.Count = "";


            ViewBag.UserName = HttpContext.Session.Get<string>("UserName"); // Get Session  , Keyleri tanımladık.
            var Role = HttpContext.Session.Get<string>("Role");


            if (Role == "Admin")
            {
                return RedirectToAction("Index" , "Admin");
            }

            else
            return View();
        }

        public IActionResult Privacy()
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
