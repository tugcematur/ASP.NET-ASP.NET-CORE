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
    public class EmployeesController : Controller
    {
        IUnitOfWork _uofWork;
        EmployeesModel _model;
        public EmployeesController(IUnitOfWork uofWork,EmployeesModel model)
        {
            _uofWork = uofWork;
            _model = model;
        }
       
        public IActionResult List()
        {
                var elist = _uofWork._empRepos.GetEmployeesList();
            return View(elist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _model.Header = "Yeni Kayıt İşlemi";
            _model.BtnVal = "Ekle";
            _model.BtnClass = "btn btn-primary";
            _model.Employees = new Employees();
            _model.Managers = _uofWork._empRepos.GetManagersList();
            _model.Counties = _uofWork._countRepos.GetCounties();
          
            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Create(EmployeesModel model)
        {
            _uofWork._empRepos.Create(model.Employees);
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
            _model.Employees = _uofWork._empRepos.Set().Find(id);
            _model.Managers = _uofWork._empRepos.GetManagersList();
            _model.Counties = _uofWork._countRepos.GetCounties();
            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(EmployeesModel model)
        {
            _uofWork._empRepos.Set().Update(model.Employees);
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
            //_model.Employees = _uofWork._empRepos.Set().Find(id);
            //_model.Managers = _uofWork._empRepos.GetManagersList();
            //_model.Counties = _uofWork._countRepos.GetCounties();
            //return View("Crud", _model);
            Employees employee = _uofWork._empRepos.Find(id);
            _uofWork._empRepos.Set().Remove(employee);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("List");

        }

        //[HttpPost]

        //public IActionResult Delete(EmployeesModel model)
        //{
        //    _uofWork._empRepos.Set().Remove(model.Employees);
        //    _uofWork.Commit();
        //    _uofWork.Dispose();

        //    return RedirectToAction("List");
        //}


        public IActionResult Details (int id)
        {

            var emp = _uofWork._empRepos.GetEmployeeDetails(id);
            return View(emp);
        }
    }
}
