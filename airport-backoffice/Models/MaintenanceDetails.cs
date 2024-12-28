using Microsoft.EntityFrameworkCore;

namespace airport_backoffice.Models
{
    [Keyless]
    public class MaintenanceDetails : Avion
    {
        public DateOnly? Dernier_maintenance { get; set; }
        public int Difference_dernier_maintenance { get; set; }
    }
}
