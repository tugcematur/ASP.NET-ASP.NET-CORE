using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedRepository.Extensions;
using Microsoft.AspNetCore.Http;

namespace AdvancedRepository.Controllers
{
    public class BasketController : Controller
    {
        //List<Basket> _baskets;
      
        BasketModel _model;
        IUnitOfWork _uofWork;
        Basket _basket;

        static List<Basket> _baskets = new List<Basket>(); //static yaparsak newlemez ve boş gelmez içi böylelikle 

        public BasketController(/*List<Basket> baskets,*/ BasketModel model,IUnitOfWork uofWork,Basket basket)
        {
            //_baskets = baskets;
            _model = model;
            _uofWork = uofWork;
            _basket = basket;
        }
        
        public IActionResult List()
        {
            var z = _basket;
            return View(_baskets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            _model.Products = _uofWork._proRepos.GetProductsSelect();

            return View(_model);
        }


        [HttpPost]

        public IActionResult Add(BasketModel model)
        {
            Products product = _uofWork._proRepos.Find(model.Id);

            _basket.Id = product.Id;
            _basket.ProductName = product.ProductName;
            _basket.UnitPrice = product.UnitPrice;
            _basket.Amount = model.Amount;

            _baskets.Add(_basket); // Sepete bir ürün eklendi 
            HttpContext.Session.Set("Basket", _baskets); //Session oluşturuluyor ,Session Tipini kendisi tanıyor hatta diğerlerinde de yazmasak olur // Json nesnesi List türünü stringe dönüştürüyor clear işlemi yapmadığımız için üstüne kendşsşnş ve stringe dönüştürülmüş haliekleniyor. Bu yüzden Conut =2 tolarak 2 tane ürün geliyor 
          //  _baskets = HttpContext.Session.Get<List<Basket>>("Basket"); // Parametreyi Gette yazmak zorundayız.,üstteki Keyworden   "Basket" geliyor

           // ViewBag.Count = _baskets.Count; // Sessiona eklicez 

            return RedirectToAction("Index","Home");
        }
    }
}
