using FirstCode.Models.Data;
using FirstCode.Models.Data.Classes;
using FirstCode.Models.DTOs;
using FirstCode.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCode.Controllers
{
    public class PersonelController : Controller
    {
        PerContext _db;
        PersonelModel _model;
        public PersonelController(PerContext db, PersonelModel model)
        {
            _db = db;
            _model = model;
        }
        public IActionResult List()
        {
            var plist =_db.Set<Personel>().Select(x => new PersonelDTO
            {
                PersonelId = x.PersonelId,
                Name = x.Name,
                Surname = x.Surname,
                City= x.City.CityName

            }).ToList();
            return View(plist);
        }

        [HttpGet]

        public IActionResult Create()
        {
            _model.Header = "Yeni Kayıt Ekleme İşlemi";
            _model.BtnVal = "Ekle";
            _model.BtnClass = "btn btn-primary";
            _model.CityList = GetCityList();
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Create(PersonelModel model)
        {
            _db.Set<Personel>().Add(model.Personel);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        private List<CityDTO> GetCityList()
        {
            return _db.Set<City>().Select(x => new CityDTO

            {
                CityId = x.CityId,
                CityName = x.CityName

            }).ToList();

         
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            _model.Header = "Güncelleme işlemi";
            _model.BtnVal = "Güncelle";
            _model.BtnClass = "btn btn-success";
            _model.CityList = GetCityList();
            _model.Personel = _db.Set<Personel>().Find(id);
            return RedirectToAction("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(PersonelModel model)
        {
            _db.Set<Personel>().Update(model.Personel);
            return RedirectToAction("List");
        }


        [HttpGet]

        public IActionResult Delete(int id)
        {
            _model.Header = "Silme işlemi";
            _model.BtnVal = "Sil";
            _model.BtnClass = "btn btn-danger";
            _model.CityList = GetCityList();
            _model.Personel = _db.Set<Personel>().Find(id);
            return RedirectToAction("Crud", _model);
        }

        [HttpPost]

        public IActionResult Delete(PersonelModel model)
        {
            _db.Set<Personel>().Remove(model.Personel);
            return RedirectToAction("List");
        }
    }
}
