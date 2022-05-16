using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCModel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Contact2()
        {
            //1.Yol a)
            Webmaster wm = new Webmaster();

            wm.Ad = "Şamil";                                //Bu bilgiler normalde veritabanından gelecek
            wm.Mail = "samil@abc.com";
            wm.Tel = 532;

            ViewBag.Ad = wm.Ad;
            ViewBag.Mail = wm.Mail;
            ViewBag.Tel = wm.Tel;



            // 1.Yol b)

            ViewBag.Webmaster = wm;   // ViewBag 'in tipi Webmaster oldu.

            return View();
        }


        public ActionResult Contact3()
        {
            //2.Yol Model
            Webmaster wm = new Webmaster();

            wm.Ad = "Şamil";                                
            wm.Mail = "samil@abc.com";              
            wm.Tel = 532;

         


            return View(wm);  //Değişken direkt View'e gönderilir.(Model göderilir.)  wm bir model data,veri,değişken 
        }
    }
}