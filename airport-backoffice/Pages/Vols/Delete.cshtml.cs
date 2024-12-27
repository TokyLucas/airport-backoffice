using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using airport_backoffice.Data;
using airport_backoffice.Models;

namespace airport_backoffice.Pages.Vols
{
    public class DeleteModel : PageModel
    {
        private readonly airport_backoffice.Data.airport_backofficeContext _context;

        public DeleteModel(airport_backoffice.Data.airport_backofficeContext context)
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

            var vol = await _context.Vol.FirstOrDefaultAsync(m => m.Vol_id == id);

            if (vol is not null)
            {
                Vol = vol;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vol = await _context.Vol.FindAsync(id);
            if (vol != null)
            {
                Vol = vol;
                _context.Vol.Remove(Vol);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
