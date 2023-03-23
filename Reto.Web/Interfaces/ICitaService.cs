using Microsoft.AspNetCore.Mvc.Rendering;
using Reto.Utils;
using Reto.Web.Models;

namespace Reto.Web.Interfaces
{
	public interface ICitaService
	{
		Task<SelectList> ObtienePlacaVehiculos();
		Task<List<CitaVM>> ObtieneCitasByPlaca(string placa);
		SelectList ObtieneHoras();
		Task<RespuestaVM> Crear(CitaVM cita);
	}
}
