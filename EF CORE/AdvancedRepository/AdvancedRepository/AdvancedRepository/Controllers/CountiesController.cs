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
    public class CountiesController : Controller
    {
        IUnitOfWork _uofWork;
        CountiesModel _model;
        public CountiesController(IUnitOfWork uofWork, CountiesModel model)
        {
            _uofWork = uofWork;
            _model = model;
        }


        public IActionResult List()
        {
            var clist = _uofWork._countRepos.GetCounties();
            return View(clist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _model.Header = "Kayıt Ekleme İşlemi";
            _model.BtnClass = "btn btn-primary";
            _model.BtnVal = "Ekle";
            _model.Counties = new Counties();
            _model.Cities = _uofWork._cityRepos.GetCities();


            return View("Crud", _model);
        }

        [HttpPost]


        public IActionResult Create(CountiesModel model)
        {
            _uofWork._countRepos.Create(model.Counties);
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
            _model.Counties = _uofWork._countRepos.Set().Find(id);
            _model.Cities = _uofWork._cityRepos.GetCities();
            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(CountiesModel model)
        {
            _uofWork._countRepos.Set().Update(model.Counties);
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
            _model.Counties = _uofWork._countRepos.Set().Find(id);
            _model.Cities = _uofWork._cityRepos.GetCities();

            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Delete(CountiesModel model)
        {
            _uofWork._countRepos.Set().Remove(model.Counties);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }
    }
}
