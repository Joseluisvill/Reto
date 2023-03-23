using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Reto.Data.Models;
using Reto.Utils;
using Reto.Web.Interfaces;
using Reto.Web.Models;

namespace Reto.Web.Services
{
	public class CitaService : ICitaService
	{
		private readonly IWebClient _webClient;
		private readonly string _urlAPI;
        public CitaService(IWebClient webClient, IConfiguration configuration)
		{
			_webClient = webClient;
			_urlAPI = configuration["URL_API"] ?? "";
		}

		public async Task<RespuestaVM> Crear(CitaVM cita)
		{
			return await _webClient.Post<CitaVM>(_urlAPI + "Cita", cita);
		}

		public async Task<List<CitaVM>> ObtieneCitasByPlaca(string placa)
		{
			return await _webClient.GetAll<CitaVM>(_urlAPI + "Cita/Placa/" + placa);
		}

		public SelectList ObtieneHoras()
		{
			var objListaHoras = new List<ListaGeneralVM>();
			objListaHoras.Add(new ListaGeneralVM() { sId = "8:00", Name = "8:00" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "8:30", Name = "8:30" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "9:00", Name = "9:00" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "9:30", Name = "9:30" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "10:00", Name = "10:00" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "10:30", Name = "10:30" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "11:00", Name = "11:00" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "11:30", Name = "11:30" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "12:00", Name = "12:00" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "12:30", Name = "12:30" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "13:00", Name = "13:00" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "13:30", Name = "13:30" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "14:00", Name = "14:00" });
			objListaHoras.Add(new ListaGeneralVM() { sId = "14:30", Name = "14:30" });

			return new SelectList(objListaHoras, "sId", "Name");
		}

		public async Task<SelectList> ObtienePlacaVehiculos()
		{
			var listaGeneral = new List<ListaGeneralVM>();
			string RutaParametro = _urlAPI + "Vehiculo";
			var objCatalogo = await _webClient.GetAll<VehiculoVM>(RutaParametro);
			if (objCatalogo.Count() >0)
			{
				foreach (var p in objCatalogo)
					listaGeneral.Add(new ListaGeneralVM { iId = p.Id, Name = p.Placa });

				return listaGeneral[0].iId != 0 ?
					new SelectList(listaGeneral, "iId", "Name") : new SelectList(listaGeneral, "sId", "Name");
			}
			return new SelectList(Enumerable.Empty<SelectListItem>());
		}
	}
}
