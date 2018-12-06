using System.Collections.Generic;
using UNIP.PIM.HelpDesk.DTO.SolicitacaoChamado;

namespace UNIP.PIM.HelpDesk.BLL.Interfaces
{
    public interface ISolicitacaoBLL
    {
        List<Solicitacao> ListarSolicitacoes();
        Solicitacao ProcurarSolicitacaoPorId(int idSolicitacao);
		void Incluir(Solicitacao Solicitacao);
		void AlterarStatus(int idSolicitacao, bool status);
	}
}
