using KatmanliMimari.Dal.Users;
using KatmanliMimari.UI.Models;
using KatmanliMimari.Uow;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliMimari.UI.Controllers
{
    public class UserController : Controller
    {
        IUnitOfWork _uofWork;
        AspNetUserModel _model;

        public UserController(IUnitOfWork uofWork, AspNetUserModel model)
        {
            _uofWork = uofWork;
            _model = model;
           

         }
        public IActionResult List()
        {
            return View(_uofWork._userRepos.GetUserList());
        }

        [HttpGet]
        public IActionResult AddRole(string id)
        {
            AspNetUser user = _uofWork._userRepos.Find(id);
            _model.Id = user.Id;
            _model.RoleList = _uofWork._roleRepos.GetRole();

            return View(_model);
        }

        [HttpGet]

        public IActionResult Update(string id)
        {

            return View();
        }
    }
}
