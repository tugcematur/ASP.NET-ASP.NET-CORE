using PersonelDbFirst.Connection;
using PersonelDbFirst.Models.Data;
using PersonelDbFirst.Models.DTO;
using PersonelDbFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelDbFirst.Controllers
{                                                                     //Tip korumalı diller hatayı gösterir.
    public class PersonelController : Controller
    {
        // GET: Personel

      //  perdb2Entities db = new perdb2Entities();
        static perdb2Entities db = DbSingleTone.GetConnection();


        public ActionResult List() 
        {
              var plist = db.Set<Personel>().Select(x => new PersonelDTO   // Tipi: List <PersonelDTO >
                {
                    Ad = x.Ad,
                    Ikamet = x.Ulke.UlkeAd,
                    Id = x.PersonelId,
                    Soyad = x.Soyad,
                    UnvanAd = x.Unvan.UnvanAd,
                    Yonetici = x.Personel2.Ad + " " + x.Personel2.Soyad,
                    Maas = (decimal) x.Maas,
                    Uyruk= x.Ulke1.UlkeAd


             

                }).ToList();



            return View(plist);
           

        }



        public ActionResult ListByUnvanId(int id)  //Unvan Listinde ilgili personel kısmında çalışan metot
        {
            var plist = db.Set<Personel>().Select(x => new PersonelDTO   // Tipi: List <PersonelDTO >
            {
                Ad = x.Ad,
                Ikamet = x.Ulke.UlkeAd,
                Id = x.PersonelId,
                Soyad = x.Soyad,                                                //Sql sorgusu kullanmadık(Dapper da kullanıyorduk ve bunu İnner join ile yapmıştık)
                UnvanAd = x.Unvan.UnvanAd,                                     //x.Ad ile veritabanından gelen veri DTO daki Ad ile eşleşiyor
                Yonetici = x.Personel2.Ad + " " + x.Personel2.Soyad,
                UnvanId = (int)(x.UnvanId) //UnvanId null    database de  null olmasına izin veridğimizden dolayı int e çevirdik 
               
            }).Where(x=>x.UnvanId==id).ToList(); 



            return View("List",plist);


        }



        [HttpGet]
        public ActionResult Create()
        {
            PersonelModel model = new PersonelModel();

            model.Baslik = "Yeni Kayıt";
            model.BtnClass = "btn btn-primary";
            model.BtnVal = "Ekle";
            model.InputType = "text";
            model.Personel = new Personel();
            model.UnvanList = GetUnvanList();
            model.UlkeList = GetUlkeList();
            model.YoneticiList = GetYoneticiList();

            
       

            return View("Crud", model);
        }

      

        [HttpPost]


        public ActionResult Create(PersonelModel model)
        {
            db.Entry(model.Personel).State = EntityState.Added;
            Session["cls"] = "alert-success";
            Session["mesaj"] = $"Kayıt işlemi başarılı";
            db.SaveChanges();
            return RedirectToAction("List");
        }





        private List<PersonelSelect> GetYoneticiList()
        {
            return db.Set<Personel>().Select(x => new PersonelSelect
            {
                YoneticiId = x.YoneticiId ?? 0,                 // x.YoneticiId ?? 0   :  null değilse işlemi yap  null ise 0 yerleştir 
                Adsoy = x.Personel2.Ad + " " + x.Personel2.Soyad                        // inner join 

            }).Where(x=>x.YoneticiId !=0).Distinct().ToList();                    //Distinct tekrar eden kolonları engeller. 
        }


        private List<UlkeDTO> GetUlkeList()
        {
            return db.Set<Ulke>().Select(x => new UlkeDTO

            {
                UlkeId = x.UlkeId,
                UlkeAd = x.UlkeAd
           
            }).ToList();
          
        }

                                                                                                                                                        // DTO =   DATA  TRANSFER  OBJECT
        //Potential fix ten oluşturduğumuz da private  olur.
        private List<UnvanDTO> GetUnvanList()
        {
            return db.Set<Unvan>().Select(x => new UnvanDTO

            {
                UnvanId = x.UnvanId,
                UnvanAd = x.UnvanAd

            }).ToList();

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            PersonelModel model = new PersonelModel();
            model.Baslik = "Güncelleme İşlemi";
            model.BtnClass = "btn btn-success";
            model.BtnVal = "Güncelle";
            model.InputType = "hidden";
            model.Personel = db.Set<Personel>().Find(id);
            model.UnvanList = GetUnvanList();
            model.UlkeList = GetUlkeList();
            model.YoneticiList = GetYoneticiList();



            return View("Crud", model);
        }
        //YöneticiId boş olan kayıt boş geliyor yonetici selectinde


        [HttpPost]


        public ActionResult Update(PersonelModel model)
        {
            // db.Entry(model.Personel).State = EntityState.Modified;
            Personel p = db.Set<Personel>().Find(model.Personel.PersonelId);   //Core da buna gerek yok  , (SingleTone.cs )
            p.Ad = model.Personel.Ad;
            p.Soyad = model.Personel.Soyad;
            p.Maas = model.Personel.Maas;
            p.UnvanId = model.Personel.UnvanId;
            Session["mesaj"] = $"Güncelleme İşlemi Başarılı";
            Session["cls"] = "alert-success";
            db.SaveChanges();


            return RedirectToAction("List");
        }


        [HttpGet]


        public ActionResult Delete(int id)
        {
            PersonelModel model = new PersonelModel();
            model.Baslik = "Silme İşlemi";
            model.BtnClass = "btn btn-danger";
            model.BtnVal = "Sil";
            model.InputType = "hidden";
            model.Personel = db.Set<Personel>().Find(id);
            model.UnvanList = GetUnvanList();
            model.UlkeList = GetUlkeList();
            model.YoneticiList = GetYoneticiList();

            return View("Crud", model);
        }


        [HttpPost]

        public ActionResult Delete(PersonelModel model)
        {
            
                Personel p = db.Set<Personel>().Find(model.Personel.PersonelId);
                db.Personel.Remove(p);
                Session["mesaj"] = $"Silme İşlemi Başarılı";
                Session["cls"] = "alert-success";
        

            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}