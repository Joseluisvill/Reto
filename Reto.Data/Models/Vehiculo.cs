using System;
using System.Collections.Generic;

namespace Reto.Data.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Cita = new HashSet<Cita>();
        }

        public int Id { get; set; }
        public string Placa { get; set; } = null!;

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
