using OgrenciProjeCodeFirst.Models.Data;
using OgrenciProjeCodeFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciProjeCodeFirst.Controllers
{
    public class CityController : Controller
    {
        // GET: City

        OgrenciContext db = new OgrenciContext();
        public ActionResult List()
        {
            var clist = db.Set<City>().ToList();
            return View(clist);
        }

        [HttpGet]

        public ActionResult Create()
        {
            CityModel model = new CityModel();
            model.Baslik = "Yeni Kayıt İşlemi";
            model.BtnVal = "Ekle";
            model.BtnClass = "btn btn-primary";
            model.InputType = "text";
            model.City = new City();

            return View("Crud", model);
        }

        [HttpPost]

        public ActionResult Create(CityModel model)
        {
            db.Entry(model.City).State = EntityState.Added;
            db.SaveChanges();
            Session["cls"] = "alert-success";
            Session["mesaj"] = $"Kayıt işlemi Başarılı";
            return RedirectToAction("List");
        }


        [HttpGet]


        public ActionResult Update (int id)
        {
            CityModel model = new CityModel();
            model.Baslik = "Güncelleme İşlemi";
            model.BtnVal = "Güncelle";
            model.BtnClass = "btn btn-success";
            model.InputType = "hidden";
            model.City = db.Set<City>().Find(id);
           

            return View("Crud", model);
        }

        public ActionResult Update(CityModel model)
        {
            db.Entry(model.City).State = EntityState.Modified;
            db.SaveChanges();
            Session["cls"] = "alert-success";
            Session["mesaj"] = $"Güncelleme işlemi Başarılı";

            return RedirectToAction("List");
        }

        [HttpGet]

        public ActionResult Delete (int id)
        {

            CityModel model = new CityModel();
            model.Baslik = "Silme İşlemi";
            model.BtnVal = "Sil";
            model.BtnClass = "btn btn-danger";
            model.InputType = "hidden";
            model.City = db.Set<City>().Find(id);

            return View("Crud", model);
        }


        [HttpPost]

        public ActionResult Delete(CityModel model)
        {
            try
            {
                db.Entry(model.City).State = EntityState.Deleted;
                db.SaveChanges();
                Session["cls"] = "alert-success";
                Session["mesaj"] = $"Kayıt Silme İşlemi Başarılı";


            }
            catch (Exception)
            {
                Session["cls"] = "alert-danger";
                Session["mesaj"] = $"{model.City.CityId} kaydının başka tablosuyla bağlantısı var bu yüzden silinemez";

            }
            return RedirectToAction("List");
        }
    }
}