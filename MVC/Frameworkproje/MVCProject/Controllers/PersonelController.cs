using Framework;
using MVCProject.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        BaseRepository<Personel> repPersonel = new BaseRepository<Personel>();
        public ActionResult List()
        {
            
            return View(repPersonel.List("Personel"));
        }

     

    }
}