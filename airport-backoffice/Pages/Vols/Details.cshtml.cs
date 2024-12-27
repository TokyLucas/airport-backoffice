using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using airport_backoffice.Data;
using airport_backoffice.Models;
using Ganss.Excel;

namespace airport_backoffice.Pages.Vols
{
    public class DetailsModel : PageModel
    {
        private readonly airport_backoffice.Data.airport_backofficeContext _context;

        public DetailsModel(airport_backoffice.Data.airport_backofficeContext context)
        {
            _context = context;
        }

        public VolDetails Vol { get; set; } = default!;
        public IList<ClientAyantReserve> ClientAyantReserve { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vol = await _context.VolDetails.FirstOrDefaultAsync(m => m.Vol_id == id);
            var clients = await _context.ClientAyantReserve.Where(m => m.Vol_id == id).ToListAsync();

            if (vol is not null)
            {
                Vol = vol;
                ClientAyantReserve = clients;

                return Page();
            }

            return NotFound();
        }
    }
}
