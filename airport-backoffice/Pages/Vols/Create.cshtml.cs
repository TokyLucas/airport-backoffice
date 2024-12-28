using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using airport_backoffice.Data;
using airport_backoffice.Models;
using airport_backoffice.Services;

namespace airport_backoffice.Pages.Vols
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
            ViewData["Airport"] = new SelectList(_context.Set<Airport>(), "Airport_id", "Ville");
            return Page();
        }

        [BindProperty]
        public Vol Vol { get; set; } = default!;


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var checkVol = _context.Vol
                            .Where(m => m.Avion_id == Vol.Avion_id)
                            .Where(m => DateOnly.FromDateTime(m.Date_depart) == DateOnly.FromDateTime(Vol.Date_depart))
                            .ToList();
            var checkMaintenance = _context.Maintenance
                                .Where(m => m.Avion_id == Vol.Avion_id)
                                .Where(
                                    m => m.Date_debut <= DateOnly.FromDateTime(Vol.Date_depart) && m.Date_fin >= DateOnly.FromDateTime(Vol.Date_depart)
                                )
                                .ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (checkVol.Count > 0)
            {
                ViewData["Erreur"] = "Avion deja affecté a un vol ce jour";
                return Page();
            }
            else if (checkMaintenance.Count > 0)
            {
                ViewData["Erreur"] = "Avion en maintenance ce jour";
                return Page();
            }

            _context.Vol.Add(Vol);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
