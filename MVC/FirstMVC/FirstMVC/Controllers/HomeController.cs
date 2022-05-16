using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers                                                    ///adlanrıırken Controllerdan öncesini baz alır.
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()  // ActionResult geri dönüş değeri olara view ister.
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}