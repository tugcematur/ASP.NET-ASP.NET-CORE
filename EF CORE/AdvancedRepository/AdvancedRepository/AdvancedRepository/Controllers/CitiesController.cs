using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class CitiesController : Controller
    {
        IUnitOfWork _uofWork;
        CitiesModel _model;
        public CitiesController(IUnitOfWork uofWork,CitiesModel model)
        {
            _uofWork = uofWork;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uofWork._cityRepos.GetCities();
            return View(clist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            _model.Header = "Kayıt Ekleme İşlemi";
            _model.BtnClass = "btn btn-primary";
            _model.BtnVal = "Ekle";
            _model.Cities = new Cities();


            return View("Crud", _model);
        }

        [HttpPost]


        public IActionResult Create(CitiesModel model)
        {
            _uofWork._cityRepos.Set().Add(model.Cities);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            _model.Header = "Güncelleme İşlemi";
            _model.BtnClass = "btn btn-success";
            _model.BtnVal = "Güncelle";
            _model.Cities= _uofWork._cityRepos.Set().Find(id);
            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(CitiesModel model)
        {
            _uofWork._cityRepos.Set().Update(model.Cities);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            _model.Header = "Silme İşlemi";
            _model.BtnClass = "btn btn-danger";
            _model.BtnVal = "Sil";
            _model.Cities= _uofWork._cityRepos.Set().Find(id);

            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Delete(CitiesModel model)
        {
            _uofWork._cityRepos.Set().Remove(model.Cities);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }

    }
}
