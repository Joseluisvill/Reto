using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Utils
{
	public interface IObjRespuesta
	{
		RespuestaVM Success();
		RespuestaVM Success(string mensaje);
		RespuestaVM Delete();
		RespuestaVM Error(string error);
		RespuestaVM Exception(Exception ex);
		RespuestaVM NoRecords();
		RespuestaVM WithRecords(string mensaje);
	}
}
