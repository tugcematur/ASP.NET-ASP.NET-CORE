using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithLayout.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult List()
        {
            return View();
        }
    }
}