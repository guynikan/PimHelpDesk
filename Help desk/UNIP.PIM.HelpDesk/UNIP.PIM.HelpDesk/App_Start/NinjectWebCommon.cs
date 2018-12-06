using Ninject;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using UNIP.PIM.HelpDesk.BLL;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DAO;
using UNIP.PIM.HelpDesk.DAO.Interfaces;

namespace UNIP.PIM.HelpDesk.App_Start
{
    public class NinjectWebCommon
    {
        public static void RegistrarDependencias()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IClienteBLL>().To<ClienteBLL>();
            kernel.Bind<IUsuarioBLL>().To<UsuarioBLL>();
            kernel.Bind<IGrupoBLL>().To<GrupoBLL>();
            kernel.Bind<ISolicitacaoBLL>().To<SolicitacaoBLL>();
            kernel.Bind<IChamadoBLL>().To<ChamadoBLL>();

            kernel.Bind<IClienteDAL>().To<ClienteDAL>();
            kernel.Bind<IUsuarioDAL>().To<UsuarioDAL>();
            kernel.Bind<IGrupoDAL>().To<GrupoDAL>();
            kernel.Bind<ISolicitacaoDAL>().To<SolicitacaoDAL>();
            kernel.Bind<IChamadoDAL>().To<ChamadoDAL>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}