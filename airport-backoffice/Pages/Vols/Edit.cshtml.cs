using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using airport_backoffice.Data;
using airport_backoffice.Models;

namespace airport_backoffice.Pages.Vols
{
    public class EditModel : PageModel
    {
        private readonly airport_backoffice.Data.airport_backofficeContext _context;

        public EditModel(airport_backoffice.Data.airport_backofficeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vol Vol { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var vol =  await _context.Vol.FirstOrDefaultAsync(m => m.Vol_id == id);

            ViewData["Avions"] = new SelectList(_context.Set<Avion>(), "Avion_id", "Immatriculation");
            ViewData["Airport"] = new SelectList(_context.Set<Airport>(), "Airport_id", "Ville");

            if (vol == null)
            {
                return NotFound();
            }
            Vol = vol;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(Vol.Vol_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VolExists(int id)
        {
            return _context.Vol.Any(e => e.Vol_id == id);
        }
    }
}
