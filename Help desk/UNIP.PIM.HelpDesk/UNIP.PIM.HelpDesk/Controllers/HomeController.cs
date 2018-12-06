using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Login;

namespace UNIP.PIM.HelpDesk.Controllers
{
	public class HomeController : Controller
	{
        private readonly IUsuarioBLL _usuario;

        public HomeController(IUsuarioBLL usuario)
        {
            _usuario = usuario;
        }

		public ActionResult Index()
		{
            if (Session["IdUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logar(Login login)
        {
            var acessoValido = _usuario.RetornoAcessoValido(login);

            if (acessoValido)
            {
                var usuario = _usuario.Listar().Where(x => x.Email == login.Email).FirstOrDefault();
                Session["IdUsuario"] = usuario.IdUsuario;
                Session["Nome"] = usuario.Nome;

                return RedirectToAction("Index");
            }

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session["IdUsuario"] = null;
            Session["Nome"] = null;

            return RedirectToAction("Login");

        }
    }
}