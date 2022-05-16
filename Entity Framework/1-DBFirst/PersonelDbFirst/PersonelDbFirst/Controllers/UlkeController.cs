using PersonelDbFirst.Connection;
using PersonelDbFirst.Models.Data;
using PersonelDbFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelDbFirst.Controllers
{
    public class UlkeController : Controller
    {
        // GET: Ulke

        // perdb2Entities db = new perdb2Entities();
        static perdb2Entities db = DbSingleTone.GetConnection();
        public ActionResult List()
        {
            var ulkelist = db.Set<Ulke>().ToList();


            return View(ulkelist);
        }

        [HttpGet]


        public ActionResult Create()
        {
            Session["cls"] = "alert-light";
            Session["mesaj"] = $"";

            UlkeModel model = new UlkeModel();
            

            model.Baslik = " Yeni Kayıt İşlemi";
            model.BtnClass = "btn btn-success";
            model.BtnVal = "Ekle";
            model.InputType = "Text";
            model.Ulke = new Ulke();

            return View("Crud",model);
        }

        [HttpPost]

        public ActionResult Create(Ulke model)
        {
            db.Entry(model).State = EntityState.Added;

            db.SaveChanges();
            Session["cls"] = "alert-success";
            Session["mesaj"] = $"Kayıt işlemi başarılı ";

            return RedirectToAction("List");
        }

        [HttpGet]


        public ActionResult Delete(string id)
        {
            Session["cls"] = "alert-light";
            Session["mesaj"] = $"";

            UlkeModel model = new UlkeModel();

            model.Baslik = "Silme İşlemi";
            model.BtnClass = "btn btn-danger";
            model.BtnVal = "Sil";
            model.InputType = "hidden";
            model.Ulke = db.Set<Ulke>().Find(id);

            return View("Crud", model);


        }

        [HttpPost]

        public ActionResult Delete(Ulke model)
        {
            try
            {
                Ulke ul =  db.Set<Ulke>().Find(model.UlkeId);
               
                db.Ulke.Remove(ul);
                Session["cls"] = "alert-success";
                Session["mesaj"] = "Silme İşlemi Başarılı";
                db.SaveChanges();

            }
            catch (Exception)
            {

                Session["cls"] = "alert-danger";
                Session["mesaj"] = $"{model.UlkeId} kaydının başka bir tabloyla bağlantısı var silinemez! ";
            }

            return RedirectToAction("List");
        }

        [HttpGet]

        public ActionResult Update(string id)
        {
            UlkeModel model = new UlkeModel();

            model.Baslik = "Güncelleme İşlemi";
            model.BtnClass = "btn btn-success";
            model.BtnVal = "Güncelle";
            model.InputType = "hidden";
            model.Ulke = db.Set<Ulke>().Find(id);

            return View("Crud", model);
        }


        [HttpPost]

        public ActionResult Update(Ulke model)
        {
            Ulke ul = db.Set<Ulke>().Find(model.UlkeId);
            ul.UlkeId = model.UlkeId;
            ul.UlkeAd = model.UlkeAd;
            Session["cls"] = "alert-success";
            Session["mesaj"] = "Güncelleme İşlemi Başarılı";

           // db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }

    }
}