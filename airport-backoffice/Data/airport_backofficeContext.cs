using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using airport_backoffice.Models;

namespace airport_backoffice.Data
{
    public class airport_backofficeContext : DbContext
    {
        public airport_backofficeContext (DbContextOptions<airport_backofficeContext> options)
            : base(options)
        {
        }

        public DbSet<airport_backoffice.Models.Avion> Avion { get; set; } = default!;
        public DbSet<airport_backoffice.Models.Airport> Airport { get; set; } = default!;
        public DbSet<airport_backoffice.Models.Vol> Vol { get; set; } = default!;
        public DbSet<airport_backoffice.Models.VolDetails> VolDetails { get; set; } = default!;
        public DbSet<airport_backoffice.Models.ClientAyantReserve> ClientAyantReserve { get; set; } = default!;
        public DbSet<airport_backoffice.Models.StatPaiement> StatPaiement { get; set; } = default!;
        public DbSet<airport_backoffice.Models.Maintenance> Maintenance { get; set; } = default!;
        public DbSet<airport_backoffice.Models.MaintenanceDetails> MaintenanceDetails { get; set; } = default!;
    }
}
