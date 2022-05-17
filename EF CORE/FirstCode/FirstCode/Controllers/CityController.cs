using FirstCode.Models.Data;
using FirstCode.Models.Data.Classes;
using FirstCode.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCode.Controllers
{
    public class CityController : Controller
    { //Global Değişkenler
        PerContext _db; //new lemedik
        CityModel _model;

        //Constructor
        public CityController(PerContext db,CityModel model) //ctor  , kullanacağımız değişkenler tanımlanıyor.
        {
            _db = db;
            _model = model;
        }
        public IActionResult List() //->Razor View seç -> List / List / City class / PerContext Datası son iki kutucuğu işaretle  (Layout u seçmeyi unutma)
        {

         var clist =_db.Set<City>().ToList();  // Performans kaybı olmasın diye default null gelir
           // var clist = _db.Set<City>().Include(x => x.Personels).ToList();
            return View(clist);
        }


        public IActionResult Create()
        {
            //City'i newlemesek de Core da sorun olmuyor
            _model.Header = "Yeni Kayıt Ekleme İşlemi";
            _model.BtnVal = "Ekle";
            _model.BtnClass = "btn btn-primary";
            return View("Crud",_model);
        }

        [HttpPost]
        public IActionResult Create(CityModel model)
        {   
            _db.Set<City>().Add(model.City);
            _db.SaveChanges();
            
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //City'i newlemesek de Core da sorun olmuyor
            _model.Header = "Güncelleme İşlemi";
            _model.BtnVal = "Güncelle";
            _model.BtnClass = "btn btn-success";
            //_model.City = _db.Set<City>().Find(id);
            _model.City = _db.Set<City>().Find(id);
            //       var p = _model.City.Personels; // Performansı kötü etkiler,çalışmıyor
            var p = _model.City.Personels;
        

            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Edit(CityModel model)
        {

            _db.Set<City>().Update(model.City);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            _model.Header = "Silmeİşlemi";
            _model.BtnVal = "Sil";
            _model.BtnClass = "btn btn-danger";
            _model.City = _db.Set<City>().Find(id);
            return View("Crud", _model);
            
        }

        [HttpPost]

        public IActionResult Delete(CityModel model)
        {

            _db.Set<City>().Remove(model.City);
            _db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
