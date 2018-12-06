using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Login;
using UNIP.PIM.HelpDesk.DTO.Perfil;
using UNIP.PIM.HelpDesk.DTO.Usuario;

namespace UNIP.PIM.HelpDesk.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private IUsuarioDAL _usuario;

        public UsuarioBLL(IUsuarioDAL usuario)
        {
            _usuario = usuario;
        }

		public void AlterarStatus(long idUsuario, bool status)
		{
            _usuario.AlterarStatus(idUsuario, status);
		}

		public void Incluir(Usuario Usuario)
		{
			if(Usuario.IdUsuario > 0)
			{
				_usuario.Editar(Usuario);
			}
			else
			{
				_usuario.Incluir(Usuario);
			}
		}

		public List<Usuario> Listar()
        {
            var retorno = _usuario.Listar();

            return retorno;
        }

        public List<Perfil> ListarPerfis(long? idUsuario)
        {
            var perfis = _usuario.ListarPerfis();

            if (idUsuario.HasValue)
            {
                var perfisUsuario = ListarPerfisUsuario(idUsuario.Value);

                foreach (var perfil in perfis)
                {
                    foreach (var perfilUsuario in perfisUsuario)
                    {
                        if(perfil.IdPerfil == perfilUsuario.IdPerfil)
                        {
                            perfil.Selecionado = true;
                        }
                    }
                }

            }
            return perfis;
        }

        public List<Perfil> ListarPerfisUsuario(long idUsuario)
        {
            return _usuario.ListarPerfisUsuario(idUsuario);
        }

        public Usuario ProcurarPorId(long idUsuario)
        {
            var retorno = _usuario.ProcurarPorId(idUsuario);

            return retorno;
        }

        public bool RetornoAcessoValido(Login login)
        {
            return _usuario.RetornoAcessoValido(login);
        }
    }
}
