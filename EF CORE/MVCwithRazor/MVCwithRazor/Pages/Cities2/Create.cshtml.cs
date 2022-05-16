#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCwithRazor.Data;

namespace MVCwithRazor.Pages.Cities2
{
    public class CreateModel : PageModel
    {
        private readonly MVCwithRazor.Data.Context _context;

        public CreateModel(MVCwithRazor.Data.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()                                                                                      //[HttpGet] 
        {
            return Page();
        }

        [BindProperty]
        public City City { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() // IActionResult ve OnPost olacak                                    //[HttpPost]
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cities.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
