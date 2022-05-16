using BasicRepository.Models.Classes;
using BasicRepository.Models.Repos;
using BasicRepository.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository.Controllers
{
    public class CityController : Controller
    {
        // BaseRepository<City> repCity = new BaseRepository<City>();   Eski tanımlama, Serviste tanımlıyoruz artık -->startup.cs e git

        IBaseRepository<City> _repCity;
        CityModel _model;

        public CityController(IBaseRepository<City> repCity, CityModel model)
        {
            _repCity = repCity;
            _model = model;
        }
        public IActionResult List()
        {
            var clist =_repCity.List();
            return View(clist);
        }

        [HttpGet]

        public IActionResult Create()
        {

            _model.BtnClass = "btn btn-primary";
            _model.BtnVal = "Ekle";
            _model.Header = "Yen Kayıt İşlemi";
            
            

            return View("Crud",_model);
        }

        [HttpPost]

        public IActionResult Create(CityModel model)
        {
            _repCity.Create(model.City);
            _repCity.Save();




            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            _model.BtnClass = "btn btn-success";
            _model.BtnVal = "Güncelle";
            _model.Header = "Güncelleme İşlemi";
            _model.City = _repCity.Find(id);



            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(CityModel model)
        {
            _repCity.Update(model.City);
            _repCity.Save();




            return RedirectToAction("List");
        }

       
        public IActionResult Delete(int id)
        {
            var silinecekCity = _repCity.Find(id);
           _repCity.Delete(silinecekCity);
          _repCity.Save();
       //     _repCity.Delete(_repCity.Find(id));   //kısa yol
            return RedirectToAction("List");
        }
    }
}
