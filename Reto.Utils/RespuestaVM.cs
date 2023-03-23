namespace Reto.Utils
{
	public class RespuestaVM
	{
		public string? CodResp { set; get; }
		public string? TituloResp { set; get; }
		public string? MensajeResp { set; get; }
		public int? IdResp { set; get; }
		public object? Objeto { set; get; }
		public Exception? ErrorExeption { set; get; }
	}
}