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
    public class UlkeController : Controller
    {
        // GET: Ulke

        BaseRepository<Ulke> repUlke = new BaseRepository<Ulke>();
        public ActionResult List()
        {
            
            return View(repUlke.List());
        }

        [HttpGet]

        public ActionResult Create()
        {
            UlkeModel model = new UlkeModel();
            model.Ulke = new Ulke();
            model.Baslik = "Yeni Giriş";
            model.BtnClass = "btn btn-primary";
            model.BtnVal = "Ekle";
            model.Type = "text";
            model.Label = "Id:";
            return View("Crud", model);
        }

        [HttpPost]

        public ActionResult Create(Ulke model)    //Ülkeleri Alfabetik ekliyor ,neden ?
        {
            repUlke.Create(model, false);
            return RedirectToAction("List");
        }


        [HttpGet]

        public ActionResult Update(string id)
        {
            UlkeModel model = new UlkeModel();

            model.Baslik = "Güncelleme işlemi";
            model.BtnClass = "btn btn-success";
            model.BtnVal = "Güncelle";
            model.Ulke = repUlke.Find(id);
            model.Type = "hidden";
            model.Label = "Ad:";
            return View("Crud", model);
        }

        
        [HttpPost]


        public ActionResult Update(Ulke model)
        {
            repUlke.Update(model, model.UlkeId);
            return RedirectToAction("List");

        }


        [HttpGet]


        public ActionResult Delete(string id)
        {
            UlkeModel model = new  UlkeModel();
            model.Baslik = "Silme işlemi";
            model.BtnClass = "btn btn-danger";
            model.BtnVal = "Sil";
            model.Ulke = repUlke.Find(id);
            model.Type = "hidden";
            model.Label = "Ad:";
            return View("Crud", model);


        }


        [HttpPost]

        public ActionResult Delete(Ulke model)
        {
            repUlke.Delete(model.UlkeId);
            return RedirectToAction("List");
        }
    }
}