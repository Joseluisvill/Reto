using AutoMapper;
using Reto.Data.Models;
using Reto.Data.VM;

namespace Reto.API
{
	public class AutoMap_VM_To_Model : Profile
	{
		public AutoMap_VM_To_Model()
		{
			CreateMap<CitaDTO, Cita>()
				.ForMember(d => d.Fecha, opt => opt.MapFrom(src =>
				src.Fecha.Split('-', StringSplitOptions.None)[0] + "-" +
					 src.Fecha.Split('-', StringSplitOptions.None)[1] + "-" + src.Fecha.Split('-', StringSplitOptions.None)[2]));
			CreateMap<VehiculoDTO, Vehiculo>();
		}
	}
}
