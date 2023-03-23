using Newtonsoft.Json.Linq;
using Reto.Utils;
using Reto.Web.Interfaces;
using Reto.Web.Models;
using System;

namespace Reto.Web.Services
{
	public class VehiculoService : IVehiculoService
	{
		private readonly IWebClient _webClient;
		private readonly string _urlAPI;
        public VehiculoService(IWebClient webClient, IConfiguration configuration)
		{
			_webClient = webClient;
			_urlAPI = configuration["URL_API"] ?? "";
		}
		public async Task<RespuestaVM> Crear(VehiculoVM vehiculo)
		{
			return await _webClient.Post<VehiculoVM>(_urlAPI + "Vehiculo", vehiculo);
		}

		public async Task<List<VehiculoVM>> GetAll()
		{
			return await _webClient.GetAll<VehiculoVM>(_urlAPI + "Vehiculo" );
		}
	}
}
