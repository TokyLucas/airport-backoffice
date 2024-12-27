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

namespace airport_backoffice.Pages.Avions
{
    public class EditModel : PageModel
    {
        private readonly airport_backoffice.Data.airport_backofficeContext _context;

        public EditModel(airport_backoffice.Data.airport_backofficeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Avion Avion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avion =  await _context.Avion.FirstOrDefaultAsync(m => m.Avion_id == id);
            if (avion == null)
            {
                return NotFound();
            }
            Avion = avion;
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

            _context.Attach(Avion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvionExists(Avion.Avion_id))
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

        private bool AvionExists(int id)
        {
            return _context.Avion.Any(e => e.Avion_id == id);
        }
    }
}
