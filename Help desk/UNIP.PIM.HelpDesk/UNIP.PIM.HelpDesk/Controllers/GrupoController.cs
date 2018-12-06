using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Grupo;

namespace UNIP.PIM.HelpDesk.Controllers
{
    public class GrupoController : Controller
    {
		private readonly IGrupoBLL _grupoBLL;

		public GrupoController(IGrupoBLL grupoBLL)
		{
			_grupoBLL = grupoBLL;
		}

		public ActionResult Index()
		{
			var model = new IndexGrupo();

			model.ListaGrupo = _grupoBLL.ListarGrupos(null);

			return View(model);
		}

		public ActionResult Editar(int? id)
		{
			var model = new Grupo();

			if (id.HasValue && id.Value > 0)
			{
				model = _grupoBLL.ProcurarGrupoPorId(id.Value);
			}

			return View(model);
		}

        public ActionResult Incluir(Grupo grupo)
        {
			_grupoBLL.Incluir(grupo);

			return RedirectToAction("Index");
        }

        public ActionResult AlterarStatus(int idGrupo, bool status)
        {
			_grupoBLL.AlterarStatus(idGrupo, status);

			return RedirectToAction("Index");
		}
	}
}