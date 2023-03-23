
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Data.VM
{
	public class CitaDTO
	{
		public int? Id { get; set; }
		public int IdVehiculo { get; set; }
		public string Fecha { get; set; }
		public string Hora { get; set; } = null!;
		public string Estado { get; set; } = null!;
	}
}
