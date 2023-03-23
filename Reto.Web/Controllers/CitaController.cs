using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Reto.Web.Interfaces;
using Reto.Web.Models;

namespace Reto.Web.Controllers
{
	public class CitaController : Controller
	{
		private readonly ICitaService _citaService;
        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }
        public async Task<IActionResult> Index()
		{
			var placas= await _citaService.ObtienePlacaVehiculos();
			ViewBag.GeneraListaPlacas = placas.ToList();
			ViewBag.GeneraListaHoras = _citaService.ObtieneHoras().ToList();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(CitaVM cita)
		{
			cita.Estado = "PROGRAMADA";
			var resp = await _citaService.Crear(cita);
			if (resp.CodResp != "E000")
				TempData["error"] = resp.MensajeResp;
			else
				TempData["succes"] = resp.MensajeResp;
			return Redirect("Index");
		}
		[HttpGet]
		public async Task<IActionResult> GetCitasByPlaca(string placa)
		{
			return ViewComponent("ListaCitas", new { placaV = placa });
		}
	}
}
