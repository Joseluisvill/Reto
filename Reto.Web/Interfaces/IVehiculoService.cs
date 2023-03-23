using Reto.Utils;
using Reto.Web.Models;

namespace Reto.Web.Interfaces
{
	public interface IVehiculoService
	{
		Task<RespuestaVM> Crear(VehiculoVM vehiculo);
		Task<List<VehiculoVM>> GetAll();
	}
}
