using KatmanliMimari.Uow;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliMimari.UI.Controllers
{
    public class CategoryController : Controller
    {
        IUnitOfWork _uofWork;
        public CategoryController(IUnitOfWork uofWork)
        {
            _uofWork = uofWork;
        }
        public IActionResult List()
        {

            return View(_uofWork._catRepos.GetCategory()); ;
        }
    }
}
