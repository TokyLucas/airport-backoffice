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
    public class IndexModel : PageModel
    {
        private readonly airport_backoffice.Data.airport_backofficeContext _context;

        public IndexModel(airport_backoffice.Data.airport_backofficeContext context)
        {
            _context = context;
        }

        //public IList<Vol> Vol { get;set; } = default!;
        public IList<VolDetails> Vol { get; set; } = default!;

        public async Task OnGetAsync(int currentPage = 1)
        {

            ViewData["CurrentPage"] = currentPage;
            //Vol = await _context.Vol.ToListAsync();
            int limit = 10;
            Vol = await _context.VolDetails
                .Skip((currentPage - 1) * limit)
                .Take(limit)
                .ToListAsync();
            //Vol = _context.Set<VolDetails>().ToList<VolDetails>();
        }
    }
}
