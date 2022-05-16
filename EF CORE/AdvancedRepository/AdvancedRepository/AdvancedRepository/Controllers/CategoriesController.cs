using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.Repository.Interfaces;
using AdvancedRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class CategoriesController : Controller
    {
        //IProductsRepos _proRepos;
        //ICategoriesRepos _catRepos;
        IUnitOfWork _uofWork;
        CategoriesModel _model;


        public CategoriesController(CategoriesModel model, IUnitOfWork uofWork)
        {
            //_catRepos = catRepos;
            _model = model;
            //_proRepos = proRepos;
            _uofWork = uofWork;
        }
        public IActionResult List()
        {
            //var clist = _catRepos.GetCategoriesName();
            var clist = _uofWork._catRepos.GetCategoriesName();
            return View(clist);
        }
  
        public IActionResult Products(int id)
        {
            //var plist = _proRepos.GetProductsName(id);

            //return View(plist);

            var x = _uofWork._proRepos.Set().Where(x => x.CategoryId == id).Include(x => x.Categories ).ToList();
            return View(x);
        }


        [HttpGet]
        public IActionResult Create()
        {
            _model.Header = "Kayıt Ekleme İşlemi";
            _model.BtnClass = "btn btn-primary";
            _model.BtnVal = "Ekle";
            _model.CatList = _uofWork._catRepos.GetCategoriesName();
           

            return View("Crud",_model);
        }
        
        [HttpPost]


        public IActionResult Create(CategoriesModel model)
        {
            _uofWork._catRepos.Set().Add(model.Categories);
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
            _model.Categories = _uofWork._catRepos.Set().Find(id);
            return View("Crud",_model);
        }

        [HttpPost]

        public IActionResult Edit(CategoriesModel model)
        {
            _uofWork._catRepos.Set().Update(model.Categories);
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
            _model.Categories = _uofWork._catRepos.Set().Find(id);

            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Delete(CategoriesModel model)
        {
            _uofWork._catRepos.Set().Remove(model.Categories);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }
    }
}
