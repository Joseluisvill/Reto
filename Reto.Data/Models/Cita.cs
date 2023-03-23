using System;
using System.Collections.Generic;

namespace Reto.Data.Models
{
    public partial class Cita
    {
        public int Id { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
