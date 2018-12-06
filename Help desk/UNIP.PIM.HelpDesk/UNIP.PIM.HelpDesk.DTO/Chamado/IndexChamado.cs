using System.Collections.Generic;

namespace UNIP.PIM.HelpDesk.DTO.Chamado
{
	public class IndexChamado
	{
		public IndexChamado()
		{
			ListaChamado = new List<Chamado>();
		}
		public List<Chamado> ListaChamado { get; set; }
	}
}