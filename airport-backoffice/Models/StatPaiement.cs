using Microsoft.EntityFrameworkCore;

namespace airport_backoffice.Models
{
    [Keyless]
    public class StatPaiement
    {
        public DateTime Date_depart { get; set; }
        public int Vol_id { get; set; }
        public int Nb_place_economique { get; set; }
        public int Nb_place_affaire { get; set; }
        public int Nb_place_premiere { get; set; }
        public decimal Total_economique { get; set; }
        public decimal Total_affaire { get; set; }
        public decimal Total_premiere { get; set; }

    }
}
