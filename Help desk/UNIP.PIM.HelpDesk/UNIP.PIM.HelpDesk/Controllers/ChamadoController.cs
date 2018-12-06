using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Chamado;

namespace UNIP.PIM.HelpDesk.Controllers
{
    public class ChamadoController : Controller
    {
        private readonly IChamadoBLL _chamado;
        private readonly ISolicitacaoBLL _solicitacao;
        private readonly IUsuarioBLL _usuario;
        private readonly IClienteBLL _cliente;
        private readonly IGrupoBLL _grupo;

        public ChamadoController(IChamadoBLL chamado, ISolicitacaoBLL solicitacao, IUsuarioBLL usuario, IClienteBLL cliente, IGrupoBLL grupo)
        {
            _chamado = chamado;
            _solicitacao = solicitacao;
            _usuario = usuario;
            _cliente = cliente;
            _grupo = grupo;
        }

        public ActionResult Index()
        {
            var model = new IndexChamado();
            var idUsuario = Convert.ToInt64(Session["IdUsuario"]);

            var usuarioTecnico = _usuario.ListarPerfisUsuario(idUsuario).Any(x => x.Codigo == "Tecnico");


            model.ListaChamado = _chamado.ListarChamados(idUsuario, usuarioTecnico);

            return View(model);
        }

        public ActionResult Editar(int? id)
        {
            var model = new Chamado();
            var idUsuario = Convert.ToInt64(Session["IdUsuario"]);

            var usuarioTecnico = _usuario.ListarPerfisUsuario(idUsuario).Any(x => x.Codigo == "Tecnico");

            CarregarCombos();

            if(id.HasValue && id.Value > 0)
            {
                model = _chamado.ProcurarChamadoPorId(id.Value);
            }
            else
            {
                model.IdCliente = _usuario.ProcurarPorId(idUsuario).IdCliente;
                model.IdUsuarioAbertura = idUsuario;
                model.DataAbertura = DateTime.Now;
            }

            model.Ocorrencias.Add(new Ocorrencia
            {
                IdUsuarioAlteracao = idUsuario,
                DataAlteracao = DateTime.Now,
                Usuario = Session["Nome"].ToString()
            });

            model.Ocorrencias = model.Ocorrencias.OrderBy(x => x.IdOcorrencia).ToList();
            model.UsuarioTecnico = usuarioTecnico;

            return View(model);
        }

        public ActionResult Incluir(Chamado chamado)
        {
            var idUsuario = Convert.ToInt64(Session["IdUsuario"]);

            _chamado.Incluir(chamado, idUsuario);

            return RedirectToAction("Index");
        }

        private void CarregarCombos()
        {
            var solicitacoes = _solicitacao.ListarSolicitacoes().Where(x => x.Ativo == true).ToList();
            var usuarios = _usuario.Listar().Where(x => x.Ativo == true).ToList();
            var status = _chamado.ListarStatus();
            var clientes = _cliente.ListarClientes();
            var grupos = _grupo.ListarGrupos(null);

            ViewBag.Cliente = new SelectList(clientes, "IdCliente", "NomeFantasia");
            ViewBag.Solicitacao = new SelectList(solicitacoes, "IdSolicitacao", "Descricao");
            ViewBag.Tecnico = new SelectList(usuarios, "IdUsuario", "Nome");
            ViewBag.Usuario = new SelectList(usuarios, "IdUsuario", "Nome");
            ViewBag.Status = new SelectList(status, "Key", "Value");
            ViewBag.Grupo = new SelectList(grupos, "IdGrupo", "Descricao");

        }

        public JsonResult PreencherGrupo(int idSolicitacao)
        {
            var idGrupo = _solicitacao.ProcurarSolicitacaoPorId(idSolicitacao).IdGrupo;

            return Json(idGrupo, JsonRequestBehavior.AllowGet);
        }

    }
}