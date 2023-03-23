using Microsoft.AspNetCore.Mvc;
using Reto.Data.VM;
using Reto.Services.Interfaces;
using Reto.Utils;

namespace Reto.API.Controllers
{
	[ApiController]
	[Route("Cita/")]
	public class CitaController : Controller
	{
		private readonly IObjRespuesta _objRespuesta;
		private readonly ICitaService _citaService;

        public CitaController(ICitaService citaService, IObjRespuesta objRespuesta)
        {
            _objRespuesta=objRespuesta;
			_citaService=citaService;
        }
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _citaService.GetAll());
		}
		[HttpGet]
		[Route("Placa/{placa}")]
		public async Task<IActionResult> GetAll(string placa)
		{
			return Ok(await _citaService.GetAllCitasbyPlaca(placa));
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetbyId(int id)
		{
			var r = await _citaService.Get(id);
			return r != null ? Ok(r) : NotFound(_objRespuesta.Error("Dato no encontrado"));
		}
		[HttpPost]
		public async Task<IActionResult> Create(CitaDTO cita)
		{
			return Ok(await _citaService.Create(cita));
		}
		[HttpPut]
		public async Task<IActionResult> Update(CitaDTO cita)
		{
			return Ok(await _citaService.Update(cita));
		}
		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await _citaService.Delete(id));
		}
	}
}
