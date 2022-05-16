using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCwithRazor.Data;

namespace MVCwithRazor.Pages.Cities
{
    public class CityModel : PageModel   //Controller sayılır burası 
    {
        Context _db;

        [BindProperty] // propertyi Modele bağlıyor 
        public List<City> clist { get; set; }
        public CityModel(Context db) 
        {
            _db = db;
        }
        public void OnGet() // [HttpGet] yerine geçiyor 
        {
           clist = _db.Set<City>().ToList();
            
           
        }
    }
}
