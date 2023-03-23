using Reto.Data.VM;
using Reto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Services.Interfaces
{
	public interface IVehiculoService
	{
		Task<List<VehiculoDTO>> GetAll();
		Task<VehiculoDTO> Get(int id);
		Task<RespuestaVM> Create(VehiculoDTO vehiculo);
		Task<RespuestaVM> Update(VehiculoDTO vehiculo);
		Task<RespuestaVM> Delete(int id);
	}
}
