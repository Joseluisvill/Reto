using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Utils
{
	public interface IWebClient
	{
		Task<List<T>> GetAll<T>( string url);
		Task<T> GetbyId<T>(string url, string id);
		Task<T> Get<T>(string url);
		Task<RespuestaVM> Post<T>(string url, T entidad);
		Task<RespuestaVM> Put<T>(string url, T entidad);
		Task<RespuestaVM> Delete<T>(string url, string id);
	}
}
