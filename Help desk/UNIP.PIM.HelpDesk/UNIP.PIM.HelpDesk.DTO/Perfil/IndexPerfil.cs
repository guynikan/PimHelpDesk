using System.Collections.Generic;

namespace UNIP.PIM.HelpDesk.DTO.Perfil
{
	public class IndexPerfil
	{
		public IndexPerfil()
		{
			Perfis = new List<Perfil>();
		}
		public List<Perfil> Perfis { get; set; }
	}
}