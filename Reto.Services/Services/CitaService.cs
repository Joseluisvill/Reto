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

namespace Reto.Services.Services
{
	public class CitaService : ICitaService
	{
		private readonly RetoContext _context;
		private readonly IObjRespuesta _objRespuesta;
		private readonly IMapper _mapper;
        public CitaService(RetoContext retoContext, IObjRespuesta objRespuesta,
			IMapper mapper)
		{
			_objRespuesta = objRespuesta;
			_context = retoContext;
			_mapper = mapper;
		}
		public async Task<RespuestaVM> Create(CitaDTO cita)
		{
			if (!cita.Equals(null))
			{
				try
				{
					var obj = _mapper.Map<Cita>(cita);

					_context.Citas.Add(obj);
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
					Cita? obj = _context.Citas.Find(id);
					if (obj == null)
					{
						return _objRespuesta.Error("No existe la cita para eliminar");
					}
					else
					{
						_context.Citas.Remove(obj);
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

		public async Task<CitaDTO> Get(int id)
		{
			var obj = await _context.Citas.Where(x => x.Id == id)
			   .FirstOrDefaultAsync();
			return _mapper.Map<CitaDTO>(obj);
		}

		public async Task<List<CitaDTO>> GetAll()
		{
			var list = await _context.Citas
			  .AsSplitQuery()
			  .ToListAsync();
			return _mapper.Map<List<CitaDTO>>(list);
		}

		public async Task<List<CitaDTO>> GetAllCitasbyPlaca(string Placa)
		{
			//busco el id placa por su nombre
			var idPlaca=await _context.Vehiculos.Where(x=>x.Placa.ToUpper()==Placa.ToUpper()).FirstOrDefaultAsync();
			if (idPlaca == null)
				return new List<CitaDTO>();
			var citas = await _context.Citas.Where(x => x.IdVehiculo == idPlaca.Id).ToListAsync();
			citas.ForEach(x =>x.Fecha.ToString("dd-MMM-yyyy"));
			return _mapper.Map<List<CitaDTO>>(citas);
		}

		public async Task<RespuestaVM> Update(CitaDTO cita)
		{
			if (!cita.Equals(null))
			{
				try
				{
					var objOriginal = _context.Citas.Where(x => x.Id == cita.Id)
						.AsNoTracking().FirstOrDefault();
					if (objOriginal == null)
					{
						return _objRespuesta.Error("No existe la cita que desea actualizar");
					}
					else
					{
						var obj = _mapper.Map<Cita>(cita);

						_context.Citas.Update(obj);
						_context.Entry<Cita>(obj).State = EntityState.Modified;

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
