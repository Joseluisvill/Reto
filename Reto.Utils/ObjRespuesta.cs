using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Utils
{
	public class ObjRespuesta : IObjRespuesta
	{
		public RespuestaVM NoRecords()
		{
			return new RespuestaVM
			{
				CodResp = "E000",
				TituloResp = "Información",
				MensajeResp = "No han registrado datos..."
			};
		}
		public RespuestaVM WithRecords(string mensaje)
		{
			return new RespuestaVM
			{
				CodResp = "E003",
				TituloResp = "Información",
				MensajeResp = mensaje
			};
		}
		public RespuestaVM Success()
		{
			return new RespuestaVM
			{
				CodResp = "E000",
				TituloResp = "Información Almacenada",
				MensajeResp = "Información almacenada satisfactoriamente..."
			};
		}
		public RespuestaVM Success(string mensaje)
		{
			return new RespuestaVM
			{
				CodResp = "E000",
				TituloResp = "Información Almacenada",
				MensajeResp = mensaje
			};
		}
		public RespuestaVM Delete()
		{
			return new RespuestaVM
			{
				CodResp = "E000",
				TituloResp = "Registro Eliminado",
				MensajeResp = "El registro fue eliminado satisfactoriamente."
			};
		}

		public RespuestaVM Error(string error)
		{
			return new RespuestaVM
			{
				CodResp = "E004",
				TituloResp = "Error...",
				MensajeResp = $"Error... {error}"
			};
		}

		public RespuestaVM Exception(Exception ex)
		{
			return new RespuestaVM
			{
				CodResp = "E001",
				TituloResp = "Error...",
				MensajeResp = $"Excepción. {ex.GetBaseException().Message ?? ex.Message}"
			};
		}
	}
}
