using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.Repository.Classes;
using AdvancedRepository.Repository.Interfaces;
using AdvancedRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class ProductsController : Controller
    {
        //IProductsRepos _proRepos;
        //IUnitsRepos _unitRepos;
        //ICategoriesRepos _catRepos;
        //ISuppliersRepos _suppRepos;
        IUnitOfWork _uofWork;
        ProductsModel _model;
        public ProductsController(ProductsModel model,IUnitOfWork uofWork) // 
        {
       
            _model = model;
            _uofWork = uofWork;
          
        }
        public IActionResult List()
        {
            var plist = _uofWork._proRepos.GetProductList();//Base dekiler de geliyor
            
            return View(plist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _model.Header = "Yeni Kayıt İşlemi";
            _model.BtnClass = "btn btn-primary";
            _model.BtnVal = "Ekle";
            _model.Unitlist = _uofWork._unitRepos.GetUnitsList();
            _model.Products = new Products(); // City gibi bir class olsaydı yani foreign key i olmasaydı eklememize gerek yoktu
            _model.CatList = _uofWork._catRepos.GetCategoriesName();
            _model.SuppList = _uofWork._suppRepos.GetSuppliersList();

            return View("Crud", _model);
        }

        
        [HttpPost]
        public IActionResult Create(ProductsModel model)
        {
            _uofWork._proRepos.Set().Add(model.Products);
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
            _model.Products = _uofWork._proRepos.Set().Find(id);
            _model.Unitlist = _uofWork._unitRepos.GetUnitsList();
            _model.CatList = _uofWork._catRepos.GetCategoriesName();
            _model.SuppList = _uofWork._suppRepos.GetSuppliersList();


            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(ProductsModel model)
        {
            _uofWork._proRepos.Set().Update(model.Products);
            _uofWork.Commit();
            _uofWork.Dispose();


            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //_model.Header = "Silme İşlemi";
            //_model.BtnClass = "btn btn-danger";
            //_model.BtnVal = "Sil";
            //_model.Products = _uofWork._proRepos.Set().Find(id);
            //_model.Unitlist = _uofWork._unitRepos.GetUnitsList();
            //_model.CatList = _uofWork._catRepos.GetCategoriesName();
            //_model.SuppList = _uofWork._suppRepos.GetSuppliersList();


            //return View("Crud", _model);

            Products product = _uofWork._proRepos.Find(id);
            _uofWork._proRepos.Set().Remove(product);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }

        //[HttpPost]

        //public IActionResult Delete(ProductsModel model)
        //{
        //    _uofWork._proRepos.Set().Remove(model.Products);
        //    _uofWork.Commit();
        //    _uofWork.Dispose();

        //    return RedirectToAction("List");
        //}
    }
}
