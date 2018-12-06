using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DTO.SolicitacaoChamado;

namespace UNIP.PIM.HelpDesk.DAO.Interfaces
{
    public interface ISolicitacaoDAL
    {
        List<Solicitacao> ListarSolicitacoes();
        Solicitacao ProcurarSolicitacaoPorId(int idSolicitacao);
		void Incluir(Solicitacao Solicitacao);
		void AlterarStatus(int idSolicitacao, bool status);
		void Editar(Solicitacao solicitacao);
	}
}
