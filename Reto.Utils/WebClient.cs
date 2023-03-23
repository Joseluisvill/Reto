using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Utils
{
	public class WebClient : IWebClient
	{
		public async Task<RespuestaVM> Delete<T>(string url, string id)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				using (var response = await client.DeleteAsync(url + "/" + id))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<RespuestaVM>(apiResponse);
				}
			}
		}

		public async Task<T> Get<T>(string url)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				using (var response = await client.GetAsync(url))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<T>(apiResponse);
				}
			}
		}

		public async Task<List<T>> GetAll<T>(string url)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				using (var response = await client.GetAsync(url))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<List<T>>(apiResponse);
				}
			}
		}

		public async Task<T> GetbyId<T>(string url, string id)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				using (var response = await client.GetAsync(url + "/" + id))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<T>(apiResponse);
				}
			}
		}

		public async Task<RespuestaVM> Post<T>(string url, T entidad)
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, "application/json");
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				using (var response = await client.PostAsync(url, content))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<RespuestaVM>(apiResponse);
				}
			}
		}

		public async Task<RespuestaVM> Put<T>(string url, T entidad)
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, "application/json");
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				using (var response = await client.PutAsync(url, content))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<RespuestaVM>(apiResponse);
				}
			}
		}
	}
}
