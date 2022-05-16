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
    public class FatMasterController : Controller
    {
        IUnitOfWork _uofWork;
        FatMasterModel _model;
        public FatMasterController(IUnitOfWork uofWork, FatMasterModel model)
        {
            _uofWork = uofWork;
            _model = model;
        }
        public IActionResult List()
        {

            return View(_uofWork._fatmRepos.GetFatMasterList());

        }

        [HttpGet]
        public IActionResult Create()
        {
            _model.BtnClass = "btn btn-primary";
            _model.BtnVal = "Create";
            _model.Head = "Create";
            _model.Customers = _uofWork._cusRepos.GetCustomerSelect();

            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Create(FatMasterModel model)
        {
            _uofWork._fatmRepos.Create(model.FatMaster); // session in BaseRepository

            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("Create", "FatDetail", new { id = model.FatMaster.Id }); // FatDetail in Create metoduna gidecek.

            //
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            FatMaster fm = _uofWork._fatmRepos.Find(id);
            _uofWork._fatmRepos.Set().Remove(fm);
            _uofWork.Commit();
            _uofWork.Dispose();



            return RedirectToAction("List");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            _model.BtnClass = "btn btn-primary";
            _model.BtnVal = "Update";
            _model.Head = "Update";
            _model.FatMaster = _uofWork._fatmRepos.Find(id);
            _model.Customers = _uofWork._cusRepos.GetCustomerSelect();
            return View("Crud", _model);
        }

        [HttpPost]

        public IActionResult Edit(int id,FatMasterModel model)
        {
            _uofWork._fatmRepos.Update(model.FatMaster);
            _uofWork.Commit();
            _uofWork.Dispose();

            return RedirectToAction("Create", "FatDetail", new { id = id});

        }
    }


}
