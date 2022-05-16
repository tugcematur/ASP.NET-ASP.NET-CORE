using Framework;
using MVCProject.Models.Classes;
using MVCProject.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class UnvanController : Controller
    {
        // GET: Unvan
        BaseRepository<Unvan> repUnvan = new BaseRepository<Unvan>();
        public ActionResult List()
        {
           //var x = repUnvan.List();
            return View(repUnvan.List());
        }

        [HttpGet]
        public ActionResult Create()
        {
            UnvanModel model = new UnvanModel();
            model.Unvan = new Unvan();
            model.Baslik = "Yeni Giriş";
            model.BtnClass = "btn btn-primary";
            model.BtnVal = "Ekle";
            return View("Crud",model);
        }

        [HttpPost]


        //public ActionResult Create(UnvanModel model)  Name = Unvan.UnvanAd olsaydı parametre -> (UnvanModel model ) olurdu                 --> GEREKSİZ!
        //{
        //     repUnvan.Create(model.Unvan);//arka plan sql kou çalışır , insert into Unvan(UnvanAd)VALUES(UnvanAd)
        //    return View(model);
        //}

        public ActionResult Create(Unvan  model)
        {
            repUnvan.Create(model,true);//arka plan sql kou çalışır , insert into Unvan(UnvanAd)VALUES(UnvanAd)
            return RedirectToAction("List");// return View(model) tekrar View e gider ve hata verir!!! 
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            UnvanModel model = new UnvanModel();
           
            model.Baslik = "Güncelleme işlemi";
            model.BtnClass = "btn btn-success";
            model.BtnVal = "Güncelle";
            model.Unvan = repUnvan.Find(id);
            return View("Crud", model);
        }

        [HttpPost]


        //public ActionResult Create(UnvanModel model)  Name = Unvan.UnvanAd olsaydı parametre -> (UnvanModel model ) olurdu                 --> GEREKSİZ!
        //{
        //     repUnvan.Create(model.Unvan);//arka plan sql kou çalışır , insert into Unvan(UnvanAd)VALUES(UnvanAd)
        //    return View(model);
        //}

        public ActionResult Update(Unvan model)
        {
            repUnvan.Update(model,model.UnvanId);
            return RedirectToAction("List");// return View(model) tekrar View e gider ve hata verir!!! 
        }


        [HttpGet]

        public ActionResult Delete(int id)
        {
            UnvanModel model = new UnvanModel();

            model.Baslik = "Silme işlemi";
            model.BtnClass = "btn btn-danger";
            model.BtnVal = "Sil";
            model.Unvan = repUnvan.Find(id);
            return View("Crud", model);
        }

        [HttpPost]


        public ActionResult Delete(Unvan model) 
        {
            repUnvan.Delete(model.UnvanId);   // Bu kodları sadece HttpGet ile gönderirsek direkt siler!
            return RedirectToAction("List");
        }
    }
}
