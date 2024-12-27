using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using airport_backoffice.Data;
using airport_backoffice.Models;

namespace airport_backoffice.Pages.Avions
{
    public class CreateModel : PageModel
    {
        private readonly airport_backoffice.Data.airport_backofficeContext _context;

        public CreateModel(airport_backoffice.Data.airport_backofficeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Avion Avion { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Avion.Add(Avion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
