#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVCwithRazor.Data;

namespace MVCwithRazor.Pages.Cities2
{
    public class IndexModel : PageModel
    {
        private readonly MVCwithRazor.Data.Context _context;

        public IndexModel(MVCwithRazor.Data.Context context)
        {
            _context = context;
        }

        public IList<City> City { get;set; }

        public async Task OnGetAsync()
        {
            City = await _context.Cities.ToListAsync();
        }
    }
}
