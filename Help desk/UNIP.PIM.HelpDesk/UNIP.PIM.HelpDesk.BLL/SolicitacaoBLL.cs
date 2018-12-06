using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.SolicitacaoChamado;

namespace UNIP.PIM.HelpDesk.BLL
{
    public class SolicitacaoBLL : ISolicitacaoBLL
    {
		private readonly ISolicitacaoDAL _solicitacaoDAL;

		public SolicitacaoBLL(ISolicitacaoDAL solicitacaoDAL)
		{
			_solicitacaoDAL = solicitacaoDAL;
		}

		public void AlterarStatus(int idSolicitacao, bool status)
		{
            _solicitacaoDAL.AlterarStatus(idSolicitacao, status);
		}

		public void Incluir(Solicitacao Solicitacao)
		{
			if(Solicitacao.IdSolicitacao > 0)
			{
				_solicitacaoDAL.Editar(Solicitacao);
			}
			else
			{
				_solicitacaoDAL.Incluir(Solicitacao);
			}
		}

		public List<Solicitacao> ListarSolicitacoes()
        {
			var retorno = _solicitacaoDAL.ListarSolicitacoes();

			return retorno;
        }

        public Solicitacao ProcurarSolicitacaoPorId(int idSolicitacao)
        {
			var retorno = _solicitacaoDAL.ProcurarSolicitacaoPorId(idSolicitacao);

			return retorno;
		}
	}
}
