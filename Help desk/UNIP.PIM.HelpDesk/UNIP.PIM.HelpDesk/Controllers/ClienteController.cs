using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Cliente;

namespace UNIP.PIM.HelpDesk.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteBLL _cliente;

        public ClienteController(IClienteBLL cliente)
        {
            _cliente = cliente;
        }

		public ActionResult Index()
		{
            var model = new IndexCliente();

            model.ListaCliente = _cliente.ListarClientes();

			return View(model);
		}

		public ActionResult Editar(int? id)
		{
			var model = new Cliente();

			if(id.HasValue && id.Value > 0)
			{
				model = _cliente.ProcurarClientePorId(id.Value);
			}

			return View(model);
		}

        public ActionResult Incluir(Cliente cliente)
        {
			_cliente.Incluir(cliente);

			return RedirectToAction("Index");
        }

        public ActionResult AlterarStatus(int idCliente, bool status)
        {
			_cliente.AlterarStatus(idCliente, status);

			return RedirectToAction("Index");
		}
	}
}