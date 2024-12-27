using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace airport_backoffice.Models
{
    [Keyless]
    public class ClientAyantReserve
    {
        public int Vol_id { get; set; }
        public int Client_id { get; set; }
        [Range(0, 999)]
        public int Nb_place_economique { get; set; }
        [Range(0, 999)]
        public int Nb_place_affaire { get; set; }
        [Range(0, 999)]
        public int Nb_place_premiere { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
    }
}
