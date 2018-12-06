using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DTO.SolicitacaoChamado;

namespace UNIP.PIM.HelpDesk.Controllers
{
    public class SolicitacaoController : Controller
    {
		private readonly ISolicitacaoBLL _solicitacaoBLL;
        private readonly IGrupoBLL _grupoBLL;

        public SolicitacaoController(ISolicitacaoBLL solicitacaoBLL, IGrupoBLL grupoBLL)
		{
			_solicitacaoBLL = solicitacaoBLL;
            _grupoBLL = grupoBLL;
		}

		public ActionResult Index()
        {
			var model = new IndexSolicitacao();
			model.ListaSolicitacao = _solicitacaoBLL.ListarSolicitacoes();

            return View(model);
        }

        public ActionResult Editar(int? id)
        {
            CarregarCombos();

			var model = new Solicitacao();

			if (id.HasValue && id.Value > 0)
			{
				model = _solicitacaoBLL.ProcurarSolicitacaoPorId(id.Value);
			}

			return View(model);
		}

		public ActionResult Incluir(Solicitacao solicitacao)
        {
			_solicitacaoBLL.Incluir(solicitacao);

			return RedirectToAction("Index");
		}

		public ActionResult AlterarStatus(int idSolicitacao, bool status)
        {
			_solicitacaoBLL.AlterarStatus(idSolicitacao, status);

			return RedirectToAction("Index");
		}

        private void CarregarCombos()
        {
            var grupos = _grupoBLL.ListarGrupos(null).Where(x => x.Ativo == true).ToList();

            ViewBag.Grupo = new SelectList(grupos, "IdGrupo", "Descricao");
        }

    }
}