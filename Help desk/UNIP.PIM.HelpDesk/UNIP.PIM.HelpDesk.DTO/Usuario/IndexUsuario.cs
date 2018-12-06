using System.Collections.Generic;

namespace UNIP.PIM.HelpDesk.DTO.Usuario
{
	public class IndexUsuario
	{
		public IndexUsuario()
		{
			ListaUsuario = new List<Usuario>();
		}
		public List<Usuario> ListaUsuario { get; set; }
	}
}