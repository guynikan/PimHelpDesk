using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Usuario;

namespace UNIP.PIM.HelpDesk.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioBLL _usuario;
		private readonly IClienteBLL _cliente;
        private readonly IGrupoBLL _grupo;

        public UsuarioController(IUsuarioBLL usuario, IClienteBLL cliente, IGrupoBLL grupo)
        {
            _usuario = usuario;
			_cliente = cliente;
            _grupo = grupo;
        }

        public ActionResult Index()
        {
			var model = new IndexUsuario();

            model.ListaUsuario = _usuario.Listar();

            return View(model);
        }

		public ActionResult Editar(int? id)
		{
			CarregarCombos();
			var model = new Usuario();

			if (id.HasValue && id.Value > 0)
			{
				model = _usuario.ProcurarPorId(id.Value);
			}

            model.Grupos = _grupo.ListarGrupos(id);
            model.Perfis = _usuario.ListarPerfis(id);

			return View(model);
		}

        public ActionResult Incluir(Usuario usuario)
        {
			_usuario.Incluir(usuario);

			return RedirectToAction("Index");
		}

		public ActionResult AlterarStatus(int idUsuario, bool status)
        {
			_usuario.AlterarStatus(idUsuario, status);

			return RedirectToAction("Index");
		}

		private void CarregarCombos()
		{
			var clientes = _cliente.ListarClientes().Where(x => x.Ativo == true).ToList();

			ViewBag.Cliente = new SelectList(clientes, "IdCliente", "NomeFantasia");
		}
	}
}