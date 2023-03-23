using Microsoft.AspNetCore.Mvc;
using Reto.Web.Interfaces;
using System.Xml.Linq;

namespace Reto.Web.ViewComponents
{
	[ViewComponent(Name = "ListaCitas")]
	public class ListaCitasViewComponent : ViewComponent
	{
		private readonly ICitaService _citaService;
        public ListaCitasViewComponent(ICitaService citaService)
        {
			_citaService = citaService;
        }
		public async Task<IViewComponentResult> InvokeAsync(string placaV)
		{
			var citas = await _citaService.ObtieneCitasByPlaca(placaV);
			return View("_ListaCitas", citas);
		}
	}
}
