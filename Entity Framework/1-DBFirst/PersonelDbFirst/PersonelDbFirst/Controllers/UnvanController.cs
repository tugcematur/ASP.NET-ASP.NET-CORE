using System;
using System.Collections.Generic;
using System.Data.Entity; //EntityState den dolayı eklendi.
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelDbFirst.Connection;
using PersonelDbFirst.Models.Data;
using PersonelDbFirst.Models.ViewModels;

namespace PersonelDbFirst.Controllers
{

    public class UnvanController : Controller
    {
        // perdb2Entities db = new perdb2Entities();
        static perdb2Entities db = DbSingleTone.GetConnection();

        // GET: Unvan
        public ActionResult List()
        {
            //1.yol   var plist = DB.Unvan.ToList();
            //2.yol  daha mantıklı 

            var ulist =db.Set<Unvan>().ToList();
            // ilk ünvan daki personeller gelir
            var personeller = db.Set<Unvan>().FirstOrDefault().Personel;
            //  var personeller = DB.Set<Unvan>(). Where(x=>x.UnvanId==2).FirstOrDefault().Personel;
            return View(ulist);
        }

        [HttpGet]
        public ActionResult Create() //Add View de 
        {
            Session["Mesaj"] = $"";
           Session["cls"] = "alert-light";
            //1.yol
            UnvanModel model = new UnvanModel();

            model.Baslik = "Yeni Kayıt";
            model.BtnClass = "btn btn-primary";
            model.BtnVal = "Ekle";
            model.InputType = "hidden";
            model.Unvan = new Unvan(); // Boş Unvan

            return View("Crud", model);
        }



        [HttpPost]
        public ActionResult Create(Unvan model) //Add View de 
        {
            //1.Yol
            //db.Unvan.Add(model);
            //2.yol
            //db.Set<Unvan>().Add(model);
            //3.yol
            db.Entry(model).State = EntityState.Added;

            db.SaveChanges();
            Session["Mesaj"] = $"Kayıt işlemi başarılı";
              Session["cls"] = "alert-success";
            return RedirectToAction("List");
        }

        [HttpGet]


        public ActionResult Delete(int id) //Add View de 
        {
            Session["Mesaj"] = $"";
              Session["cls"] = "alert-light";
            //1.yol
            UnvanModel model = new UnvanModel();

            model.Baslik = "Silme İşlemi";
            model.BtnClass = "btn btn-danger";
            model.BtnVal = "Sil";
            model.InputType = "hidden";
            model.Unvan = db.Set<Unvan>().Find(id);

            return View("Crud", model);
        }



        [HttpPost]
        public ActionResult Delete(Unvan model) //Add View de 
        {
            //1.Yol
            //db.Unvan.Remove(model);
            //2.yol
            //db.Set<Unvan>().Remove(model);
            try
            {
               Session["Mesaj"] = $"Silme işlemi başarılı ";
                   Session["cls"] = "alert-success";
                //3.yol
                //db.Entry(model).State = EntityState.Deleted;
                Unvan un = db.Set<Unvan>().Find(model.UnvanId);
                db.Unvan.Remove(un);
              
            }
            catch (Exception )
            {

                // ViewBag.Error = ex.Message;
                   Session["cls"] = "alert-danger";
                Session["Mesaj"] = $"{model.UnvanId} kaydının başka bir tabloyla bağlantısı var silinemez!";
               

            }
            db.SaveChanges();

            return RedirectToAction("List");

        }

        //ViewBag , ViewData ve TempData ; Bu üç asp.net mvc nesnesi belirgin özelliği küçük boyutlardaki verilerimizi Controller dan View kısmına aktarmak için kullanırız.
        //MVC projelerinde Model yapısını kullanmadan View içerisine veri göndermek istediğimiz durumlarda ViewBag,ViewData veya TempData kullanarak veri gönderme işlemlerini sağlayabiliriz.

        [HttpGet]
        public ActionResult Update(int id) //Add View de 
        {
            UnvanModel model = new UnvanModel();

            Session["Mesaj"] = $"";
                Session["cls"] = "alert-light";
            model.Baslik = "Güncelleme İşlemi";
            model.BtnClass = "btn btn-success";
            model.BtnVal = "Güncelle";
            model.InputType = "hidden";
            model.Unvan = db.Set<Unvan>().Find(id);

            return View("Crud", model);
        }



        [HttpPost]
        public ActionResult Update(Unvan model) //Add View de 
        {
            Unvan un = db.Set<Unvan>().Find(model.UnvanId);
            un.UnvanId = model.UnvanId;
            un.UnvanAd = model.UnvanAd;

            //db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            Session["Mesaj"] = $"Güncelleme işlemi başarılı";
            Session["cls"] = "alert-success";
            return RedirectToAction("List");
        }

    }
}