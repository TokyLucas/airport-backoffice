using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace airport_backoffice.Models
{
    public class Vol
    {
        [Key]
        public int Vol_id {  get; set; }
        public int Avion_id { get; set; }
        public DateTime Date_depart { get; set; }
        public int Airport_depart { get; set; }
        public int Airport_arrive { get; set; }
        public decimal Prix_de_base_economique { get; set; }
        public decimal Prix_de_base_affaire { get; set; }
        public decimal Prix_de_base_premiere { get; set; }
    }
}
