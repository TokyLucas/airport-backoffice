using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using airport_backoffice.Data;
using airport_backoffice.Models;

namespace airport_backoffice.Pages.Maintenances
{
    public class IndexModel : PageModel
    {
        private readonly airport_backoffice.Data.airport_backofficeContext _context;

        public IndexModel(airport_backoffice.Data.airport_backofficeContext context)
        {
            _context = context;
        }

        public IList<Maintenance> Maintenance { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Maintenance = await _context.Maintenance.ToListAsync();
        }
    }
}
