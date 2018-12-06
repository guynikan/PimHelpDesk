using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DTO.Login;
using UNIP.PIM.HelpDesk.DTO.Perfil;
using UNIP.PIM.HelpDesk.DTO.Usuario;

namespace UNIP.PIM.HelpDesk.DAO.Interfaces
{
    public interface IUsuarioDAL
    {
        List<Usuario> Listar();
        Usuario ProcurarPorId(long idUsuario);
		void Incluir(Usuario Usuario);
		void AlterarStatus(long idUsuario, bool status);
		void Editar(Usuario usuario);
        bool RetornoAcessoValido(Login login);
        List<Perfil> ListarPerfis();
        List<Perfil> ListarPerfisUsuario(long idUsuario);
    }
}
