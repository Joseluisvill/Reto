using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reto.Data.Models;
using Reto.Data.VM;
using Reto.Services.Interfaces;
using Reto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Reto.Services.Services
{
	public class VehiculoService : IVehiculoService
	{
		private readonly RetoContext _context;
		private readonly IObjRespuesta _objRespuesta;
		private readonly IMapper _mapper;
		public VehiculoService(RetoContext retoContext,IObjRespuesta objRespuesta,
			IMapper mapper)
        {
            _objRespuesta = objRespuesta;
			_context = retoContext;
			_mapper = mapper;
		}

        public async Task<RespuestaVM> Create(VehiculoDTO vehiculo)
		{
			if (!vehiculo.Equals(null))
			{
				try
				{
					var obj = _mapper.Map<Vehiculo>(vehiculo);

					_context.Vehiculos.Add(obj);
					await _context.SaveChangesAsync();
					return _objRespuesta.Success();
				}
				catch (Exception ex)
				{
					return _objRespuesta.Exception(ex);
				}
			}
			return _objRespuesta.Error("Datos vacios");
		}

		public async Task<RespuestaVM> Delete(int id)
		{
			if (!id.Equals(null))
			{
				try
				{
					Vehiculo? obj = _context.Vehiculos.Find(id);
					if (obj == null)
					{
						return _objRespuesta.Error("No existe el vehiculo para eliminar");
					}
					else
					{
						_context.Vehiculos.Remove(obj);
						await _context.SaveChangesAsync();
						return _objRespuesta.Delete();
					}
				}
				catch (Exception ex)
				{
					return _objRespuesta.Exception(ex);
				}
			}
			return _objRespuesta.Error("Id Nulo");
		}

		public async Task<VehiculoDTO> Get(int id)
		{
			var obj = await _context.Vehiculos.Where(x => x.Id == id)
			   .FirstOrDefaultAsync();
			return _mapper.Map<VehiculoDTO>(obj);
		}

		public async Task<List<VehiculoDTO>> GetAll()
		{
			var list = await _context.Vehiculos
			  .AsSplitQuery()
			  .ToListAsync();
			return _mapper.Map<List<VehiculoDTO>>(list);
		}

		public async Task<RespuestaVM> Update(VehiculoDTO vehiculo)
		{
			if (!vehiculo.Equals(null))
			{
				try
				{
					var objOriginal = _context.Vehiculos.Where(x => x.Id == vehiculo.Id)
						.AsNoTracking().FirstOrDefault();
					if (objOriginal == null)
					{
						return _objRespuesta.Error("No existe el vehiculo que desea actualizar");
					}
					else
					{
						var obj = _mapper.Map<Vehiculo>(vehiculo);

						_context.Vehiculos.Update(obj);
						_context.Entry<Vehiculo>(obj).State = EntityState.Modified;

						await _context.SaveChangesAsync();
						return _objRespuesta.Success();
					}
				}
				catch (Exception ex)
				{
					return _objRespuesta.Exception(ex);
				}
			}
			return _objRespuesta.Error("Id Nulo");
		}
	}
}
