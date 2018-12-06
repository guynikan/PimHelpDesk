namespace UNIP.PIM.HelpDesk.DTO.SolicitacaoChamado
{
	public class Solicitacao
	{
		public int IdSolicitacao { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }
		public int? IdGrupo { get; set; }
		public string Grupo { get; set; }
		public decimal Sla { get; set; }
		public bool Ativo { get; set; }
	}
}