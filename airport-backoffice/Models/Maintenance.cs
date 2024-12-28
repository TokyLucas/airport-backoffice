using System.ComponentModel.DataAnnotations;

namespace airport_backoffice.Models
{
    public class Maintenance
    {
        [Key]
        public int Maintenance_id { get; set; }
        public int Avion_id { get; set; }
        public string Description { get; set; }
        public DateOnly Date_debut { get; set; }
        public DateOnly Date_fin { get; set; }
        public decimal Montant { get; set; }
    }
}
