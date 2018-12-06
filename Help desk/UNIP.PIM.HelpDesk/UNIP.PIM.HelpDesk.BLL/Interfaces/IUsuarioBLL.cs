using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DTO.Login;
using UNIP.PIM.HelpDesk.DTO.Perfil;
using UNIP.PIM.HelpDesk.DTO.Usuario;

namespace UNIP.PIM.HelpDesk.BLL.Interfaces
{
    public interface IUsuarioBLL
    {
        List<Usuario> Listar();
        Usuario ProcurarPorId(long idUsuario);
		void Incluir(Usuario Usuario);
		void AlterarStatus(long idUsuario, bool status);
        bool RetornoAcessoValido(Login login);
        List<Perfil> ListarPerfis(long? idUsuario);
        List<Perfil> ListarPerfisUsuario(long idUsuario);
    }
}
