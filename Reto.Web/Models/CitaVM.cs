using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Reto.Web.Models
{
	public class CitaVM
	{
		public int? Id { get; set; }
		[Display(Name = "Vehiculo")]
		[Required(ErrorMessage = "Seleccione la Placa delVehiculo")]
		public int IdVehiculo { get; set; }
		[Display(Name = "Fecha")]
		[Required(ErrorMessage = "Seleccione la Fecha")]
		public string Fecha { get; set; }
		[Display(Name = "Hora")]
		[Required(ErrorMessage = "Seleccione la Hora")]
		public string Hora { get; set; } = null!;
		[Display(Name = "Estado")]
		[Required(ErrorMessage = "Seleccione el Estado")]
		public string Estado { get; set; } = null!;
	}
}
