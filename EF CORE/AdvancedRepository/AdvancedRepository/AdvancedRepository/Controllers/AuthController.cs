using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitofWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedRepository.Extensions;

namespace AdvancedRepository.Controllers
{
    public class AuthController : Controller
    {
        LoginModel _model;
        IUnitOfWork _uofWork;
        public AuthController(LoginModel model, IUnitOfWork uofWork)
        {
            _model = model;
            _uofWork = uofWork;
        }

        [HttpGet]
        public IActionResult Register()
        {
         
            return View(_model); 

           
        }

        [HttpPost]


        public IActionResult Register(LoginModel model)
        {

            _uofWork._authRepos.Register(model.UserName, model.Password);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {



            return View("Register",_model);


        }

        [HttpPost]


        public IActionResult Login(LoginModel model)
        {

          var user =_uofWork._authRepos.Login(model.UserName,model.Password); // Users tipinde

            if (user != null)
            {              
                HttpContext.Session.Set<string>("UserName", user.UserName); // Saklamak istediğim değer ilk etapta boş olacak çünkü login olmadı ilk etapta      // set Session // Burası saçma oldu biraz string stringe çevirdik using AdvancedRepository.Extensions;  elle ekledik
                HttpContext.Session.Set<string>("Role",user.Role);
                return RedirectToAction("Index", "Home");
            }

            else

                return RedirectToAction("Login");

        }


        [HttpGet]
        public IActionResult Logout()
        {

           // HttpContext.Session.Clear(); // Hepsini temizler

            HttpContext.Session.Set("UserName", ""); // Sepet hariç silersek 
            HttpContext.Session.Set("Role", "");
            return RedirectToAction("Index","Home");


        }
    }
}
