using System.ComponentModel.DataAnnotations;

namespace airport_backoffice.Models
{
    public class Avion
    {
        [Key]
        public int Avion_id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Immatriculation { get; set; }
        [Range(0,999)]
        public int Nb_place_economique { get; set; }
        [Range(0, 999)]
        public int Nb_place_affaire { get; set; }
        [Range(0, 999)]
        public int Nb_place_premiere { get; set; }
    }
}
