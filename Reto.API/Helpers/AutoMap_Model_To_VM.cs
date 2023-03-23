using AutoMapper;
using Reto.Data.Models;
using Reto.Data.VM;

namespace Reto.API
{
	public class AutoMap_Model_To_VM : Profile
	{
		public AutoMap_Model_To_VM()
		{
			CreateMap<Cita, CitaDTO>();
			CreateMap<Vehiculo, VehiculoDTO>();
		}
	}
}
