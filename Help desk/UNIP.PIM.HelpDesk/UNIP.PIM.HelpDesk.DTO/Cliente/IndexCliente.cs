using System.Collections.Generic;

namespace UNIP.PIM.HelpDesk.DTO.Cliente
{
	public class IndexCliente
	{
		public IndexCliente()
		{
			ListaCliente = new List<Cliente>();
		}
		public List<Cliente> ListaCliente { get; set; }
	}
}