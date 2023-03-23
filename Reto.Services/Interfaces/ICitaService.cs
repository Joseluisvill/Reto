using Reto.Data.VM;
using Reto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Services.Interfaces
{
	public interface ICitaService
	{
		Task<List<CitaDTO>> GetAll();
		Task<CitaDTO> Get(int id);
		Task<List<CitaDTO>> GetAllCitasbyPlaca(string Placa);
		Task<RespuestaVM> Create(CitaDTO cita);
		Task<RespuestaVM> Update(CitaDTO cita);
		Task<RespuestaVM> Delete(int id);
	}
}
