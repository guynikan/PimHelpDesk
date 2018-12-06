using System.Collections.Generic;

namespace UNIP.PIM.HelpDesk.DTO.Usuario
{
	public class Usuario
	{
        public Usuario()
        {
            Perfis = new List<Perfil.Perfil>();
            Grupos = new List<Grupo.Grupo>();
        }

		public long IdUsuario { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public bool Ativo { get; set; }
		public int IdPerfil { get; set; }
		public int IdCliente { get; set; }
		public string Cliente { get; set; }
        public List<Perfil.Perfil> Perfis { get; set; }
        public List<Grupo.Grupo> Grupos { get; set; }
    }
}