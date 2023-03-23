using Microsoft.AspNetCore.Mvc;
using Reto.Data.Models;
using Reto.Web.Interfaces;
using Reto.Web.Models;

namespace Reto.Web.Controllers
{
	public class VehiculoController : Controller
	{
		private readonly IVehiculoService _vehiculoService;
        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(VehiculoVM vehiculoVM)
		{
			var resp = await _vehiculoService.Crear(vehiculoVM);
			if (resp.CodResp != "E000")
				TempData["error"] = resp.MensajeResp;
			else
				TempData["succes"] = resp.MensajeResp;
			return Redirect("Index");
		}
	}
}
