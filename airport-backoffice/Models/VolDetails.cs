using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airport_backoffice.Models
{
    [Keyless]
    public class VolDetails: Vol
    {
        //[ForeignKey("avion_id")]
        //public virtual Avion? Avion { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Immatriculation { get; set; }
        [Range(0, 999)]
        public int Nb_place_economique { get; set; }
        [Range(0, 999)]
        public int Nb_place_affaire { get; set; }
        [Range(0, 999)]
        public int Nb_place_premiere { get; set; }

        public string Depart_nom { get; set; }
        public string Depart_ville { get; set; }
        public string Depart_pays { get; set; }
        public string Depart_IATA { get; set; }
        public string Depart_latitude { get; set; }
        public string Depart_longitude { get; set; }
        public string Dest_nom { get; set; }
        public string Dest_ville { get; set; }
        public string Dest_pays { get; set; }
        public string Dest_IATA { get; set; }
        public string Dest_latitude { get; set; }
        public string Dest_longitude { get; set; }

        public int Nb_place_economique_reserve { get; set; }
        public int Nb_place_affaire_reserve { get; set; }
        public int Nb_place_premiere_reserve { get; set; }
    }
}
