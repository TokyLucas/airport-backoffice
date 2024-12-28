﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly airport_backoffice.Data.airport_backofficeContext _context;

        public DetailsModel(airport_backoffice.Data.airport_backofficeContext context)
        {
            _context = context;
        }

        public Maintenance Maintenance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance = await _context.Maintenance.FirstOrDefaultAsync(m => m.Maintenance_id == id);

            if (maintenance is not null)
            {
                Maintenance = maintenance;

                return Page();
            }

            return NotFound();
        }
    }
}
