using System.Collections.Generic;

namespace UNIP.PIM.HelpDesk.DTO.SolicitacaoChamado
{
	public class IndexSolicitacao
	{
		public IndexSolicitacao()
		{
            ListaSolicitacao = new List<Solicitacao>();
		}
		public List<Solicitacao> ListaSolicitacao { get; set; }
	}
}