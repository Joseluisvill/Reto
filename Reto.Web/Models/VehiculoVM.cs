using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Reto.Web.Models
{
	public class VehiculoVM
	{
		public int Id { get; set; }
		[Display(Name = "Placa")]
		[Required(ErrorMessage = "Introduzca un nombre de Placa")]
		public string Placa { get; set; } = null!;
	}
}
