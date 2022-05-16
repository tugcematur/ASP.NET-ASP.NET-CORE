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
    public class CustomersController : Controller
    {
        IUnitOfWork _uofWork;
        CustomersModel _model;
        public CustomersController(IUnitOfWork uofWork, CustomersModel model)
        {
            _uofWork = uofWork;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uofWork._cusRepos.GetCustomersList();
            return View(clist);
        }



        [HttpGet]
        public IActionResult Create()
        {
            _model.Header = "Yeni Kayıt İşlemi";
            _model.BtnVal = "Ekle";
            _model.BtnClass = "btn btn-primary";
            _model.Customers = new Customers();
            _model.Counties = _uofWork._countRepos.GetCounties();
            _model.Cities = _uofWork._cityRepos.GetCities();

            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Create(CustomersModel model)
        {
            _uofWork._cusRepos.Create(model.Customers);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _model.Header = "Güncelleme İşlemi";
            _model.BtnVal = "Güncelle";
            _model.BtnClass = "btn btn-success";
            _model.Customers = _uofWork._cusRepos.Set().Find(id);
            _model.Counties = _uofWork._countRepos.GetCounties();
            _model.Cities = _uofWork._cityRepos.GetCities();
            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(CustomersModel model)
        {
            _uofWork._cusRepos.Set().Update(model.Customers);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //_model.Header = "Slme İşlemi";
            //_model.BtnVal = "Sil";
            //_model.BtnClass = "btn btn-danger";
            //_model.Customers = _uofWork._cusRepos.Set().Find(id);
            //_model.Counties = _uofWork._countRepos.GetCounties();
            //_model.Cities = _uofWork._cityRepos.GetCities();
            //return View("Crud", _model);

            Customers customer = _uofWork._cusRepos.Find(id);
            _uofWork._cusRepos.Set().Remove(customer);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");
        }

        //[HttpPost]

        //public IActionResult Delete(CustomersModel model)
        //{
        //    _uofWork._cusRepos.Set().Remove(model.Customers);
        //    _uofWork.Commit();
        //    _uofWork.Dispose();

        //    return RedirectToAction("List");
        //}
    }
}
