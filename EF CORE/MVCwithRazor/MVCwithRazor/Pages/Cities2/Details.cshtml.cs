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
    public class DetailsModel : PageModel
    {
        private readonly MVCwithRazor.Data.Context _context;

        public DetailsModel(MVCwithRazor.Data.Context context)
        {
            _context = context;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.Cities.FirstOrDefaultAsync(m => m.CityId == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
