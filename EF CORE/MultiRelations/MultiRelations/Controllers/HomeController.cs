using Microsoft.AspNetCore.Mvc;
using MultiRelations.Models;
using MultiRelations.Models.Data;
using System.Diagnostics;
using static MultiRelations.Models.Data.Context;

namespace MultiRelations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Context _db;
        public HomeController(ILogger<HomeController> logger,Context db)
        {
            _logger = logger;
            _db = db;   
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EgitmenEkle()
        {
            Egitmen ?egt = _db.Set<Egitmen>().Find(1);
            egt.Ogrenciler.Add(_db.Set<Ogrenci>().Find(1));
           // egt.Ogrenciler.Add(new Ogrenci { Id = 4, Name = "Nida" });
            _db.SaveChanges();
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