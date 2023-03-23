using Microsoft.AspNetCore.Mvc;
using Reto.Web.Interfaces;
using System.Xml.Linq;

namespace Reto.Web.ViewComponents
{
	[ViewComponent(Name = "ListaVehiculos")]
	public class ListaVehiculosViewComponent: ViewComponent
	{
		private readonly IVehiculoService _vehiculoService;
        public ListaVehiculosViewComponent(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var vehiculos = await _vehiculoService.GetAll();
			return View("_ListaVehiculos", vehiculos);
		}
	}
}
