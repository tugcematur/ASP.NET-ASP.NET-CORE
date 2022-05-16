using KatmanliMimari.Dal.Users;
using KatmanliMimari.UI.Models;
using KatmanliMimari.Uow;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliMimari.UI.Controllers
{
    public class RoleController : Controller
    {
        IUnitOfWork _uofWork;
        AspNetRoleModel _model;
        public RoleController(IUnitOfWork uofWork, AspNetRoleModel model)
        {
            _uofWork = uofWork;
            _model = model;

         }
        public IActionResult List()
        {
            return View(_uofWork._roleRepos.GetRole());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(_model);
        }

        [HttpPost]
        public IActionResult Create(AspNetRoleModel model)
        {
            
            _uofWork._roleRepos.Create(model.AspNetRole);
            _uofWork.Commit();

            return RedirectToAction("List");
        }

        [HttpGet]
       
        public IActionResult Delete(string id)
        {
            AspNetRole role = _uofWork._roleRepos.Find(id);

           

            return View(role);
        }

        [HttpPost]


        public IActionResult Delete(AspNetRoleModel model)
        {
         
            _uofWork._roleRepos.Delete(model.AspNetRole);
            _uofWork.Commit();
            return RedirectToAction("List");
        }


        [HttpGet]


        public IActionResult Update(string id)
        {
            AspNetRole role = _uofWork._roleRepos.Find(id);

            return View(role);
        }
        [HttpPost]
        public IActionResult Update(AspNetRoleModel model)
        {
            _uofWork._roleRepos.Update(model.AspNetRole);
            _uofWork.Commit();
            return RedirectToAction( "List");
        }

    }
}
