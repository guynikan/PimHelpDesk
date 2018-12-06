using System.Collections.Generic;

namespace UNIP.PIM.HelpDesk.DTO.Grupo
{
	public class IndexGrupo
	{
		public IndexGrupo()
		{
			ListaGrupo = new List<Grupo>();
		}

		public List<Grupo> ListaGrupo { get; set; }
	}
}