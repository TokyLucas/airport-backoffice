using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using airport_backoffice.Data;
using airport_backoffice.Models;

namespace airport_backoffice.Pages.Maintenances
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
            ViewData["Avions"] = new SelectList(_context.Set<Avion>(), "Avion_id", "Immatriculation");
            return Page();
        }

        [BindProperty]
        public Maintenance Maintenance { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Maintenance.Add(Maintenance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
