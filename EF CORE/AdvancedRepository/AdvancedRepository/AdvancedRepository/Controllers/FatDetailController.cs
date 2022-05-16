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
    public class FatDetailController : Controller
    {
        IUnitOfWork _uofWork;
        FatDetailModel _model;
        public FatDetailController(IUnitOfWork uofWork,FatDetailModel model)
        {
            _uofWork = uofWork;
            _model = model;
        }
        public IActionResult List()
        {
            return View(_uofWork._fatdRepos.Query());
        }

        [HttpGet]
        public IActionResult Create(int id )
        {
            
               _model.FatMaster = _uofWork._fatmRepos.Find(id);
            _model.Products = _uofWork._proRepos.GetProductsSelect();
            _model.Customers = _uofWork._cusRepos.GetCustomerSelect();
            _model.FatDetailList = _uofWork._fatdRepos.GetFatDetailList(id);
            _model.Total = _uofWork._fatdRepos.Total(_model.FatDetailList);
          
            return View(_model);
        }

        [HttpPost]
        public IActionResult Create(int id,FatDetailModel model,int pid )
        {
              model.FatDetail.Id = id;
            _uofWork._fatdRepos.Create(model.FatDetail);
            _uofWork.Commit();


            model.FatMaster = _uofWork._fatmRepos.Find(id);
            model.Products = _uofWork._proRepos.GetProductsSelect();
            model.Customers = _uofWork._cusRepos.GetCustomerSelect();
            model.FatDetailList = _uofWork._fatdRepos.GetFatDetailList(id);
            model.Total = _uofWork._fatdRepos.Total(model.FatDetailList);





            // return RedirectToAction("Create", "FatDetail", new { id });

            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int id, int pid) //Findmetodunu overload edicez
        {

            FatDetail fd = _uofWork._fatdRepos.Find(id,pid);

            
            return View();
        }


        [HttpPost]
        public IActionResult Update(FatDetail model,int id, int pid) //Findmetodunu overload edicez
        {

            FatDetail fd = _uofWork._fatdRepos.Find(id, pid);

            fd.Id = id;
            fd.ProductId = pid;
            fd.Amount = model.Amount;
            _uofWork._fatdRepos.Update(fd);
            _uofWork.Commit();

            return RedirectToAction("Create" ,"FatDetail",new {id,pid });

        }

        [HttpGet]

        public IActionResult Delete(int id,int pid)
        {
            FatDetail fd = _uofWork._fatdRepos.Find(id,pid);
          


            return View(fd);

        }


        [HttpPost]

        public IActionResult Delete(int id, int pid,FatDetail model)
        {
            model.Id = id;
            model.ProductId=pid;

            _uofWork._fatdRepos.Delete(model);
            _uofWork.Commit();
            _uofWork.Dispose();



            return RedirectToAction("Create","FatDetail",new {id });

        }




    }
}
