using AdvancedRepository.Models.Data;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class UnitsController : Controller
    {
        SirketContext _db;
        IUnitOfWork _uofWork;
        UnitsModel _model;
        public UnitsController(SirketContext db,IUnitOfWork uofWork,UnitsModel model)
        {
            _db = db;
            _uofWork = uofWork;
            _model = model;
        }
        public IActionResult List()
        {
            var ulist = _uofWork._unitRepos.Query();
            return View(ulist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _model.Header = "Yeni Kayıt İşlemi";
            _model.BtnClass = "btn btn-primary";
            _model.BtnVal = "Ekle";


            return View("Crud",_model);
        }

        [HttpPost]

        public IActionResult Create(UnitsModel model)
        {
            _uofWork._unitRepos.Set().Add(model.Units);
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
            _model.Units = _uofWork._unitRepos.Set().Find(id);


            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(UnitsModel model)
        {
            _uofWork._unitRepos.Set().Update(model.Units);
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
            _model.Units = _uofWork._unitRepos.Set().Find(id);


            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Delete(UnitsModel model)
        {
            _uofWork._unitRepos.Set().Remove(model.Units);
            _uofWork.Commit();
            _uofWork.Dispose();
            return RedirectToAction("List");
        }
    }
}
