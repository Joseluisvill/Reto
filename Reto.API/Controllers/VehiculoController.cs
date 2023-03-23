using Microsoft.AspNetCore.Mvc;
using Reto.Data.VM;
using Reto.Services.Interfaces;
using Reto.Services.Services;
using Reto.Utils;

namespace Reto.API.Controllers
{
	[ApiController]
	[Route("Vehiculo/")]
	public class VehiculoController : Controller
	{
		private readonly IObjRespuesta _objRespuesta;
		private readonly IVehiculoService _vehiculoService;
		public VehiculoController(IVehiculoService vehiculoService,
			IObjRespuesta objRespuesta)
        {
            _objRespuesta = objRespuesta;
			_vehiculoService=vehiculoService;
        }
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _vehiculoService.GetAll());
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetbyId(int id)
		{
			var r = await _vehiculoService.Get(id);
			return r != null ? Ok(r) : NotFound(_objRespuesta.Error("Dato no encontrado"));
		}
		[HttpPost]
		public async Task<IActionResult> Create(VehiculoDTO vehiculo)
		{
			return Ok(await _vehiculoService.Create(vehiculo));
		}
		[HttpPut]
		public async Task<IActionResult> Update(VehiculoDTO vehiculo)
		{
			return Ok(await _vehiculoService.Update(vehiculo));
		}
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await _vehiculoService.Delete(id));
		}
	}
}
