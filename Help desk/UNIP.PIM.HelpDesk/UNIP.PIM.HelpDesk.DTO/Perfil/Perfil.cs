namespace UNIP.PIM.HelpDesk.DTO.Perfil
{
	public class Perfil
	{
		public int IdPerfil { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }
		public bool Ativo { get; set; }
        public bool Selecionado { get; set; }
    }
}