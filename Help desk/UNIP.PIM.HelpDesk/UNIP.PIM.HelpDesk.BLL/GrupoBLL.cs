using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Grupo;

namespace UNIP.PIM.HelpDesk.BLL
{
    public class GrupoBLL : IGrupoBLL
    {
		private readonly IGrupoDAL _grupoDAL;

		public GrupoBLL(IGrupoDAL grupoDAL)
		{
			_grupoDAL = grupoDAL;
		}

		public void AlterarStatus(int idGrupo, bool status)
		{
            _grupoDAL.AlterarStatus(idGrupo, status);
		}

		public void Incluir(Grupo grupo)
		{
			if(grupo.IdGrupo > 0)
			{
				_grupoDAL.Editar(grupo);
			}
			else
			{
				_grupoDAL.Incluir(grupo);
			}
		}

		public List<Grupo> ListarGrupos(int? idUsuario)
        {
			var grupos = _grupoDAL.ListarGrupos();

            if (idUsuario.HasValue)
            {
                var gruposUsuario = ListarGruposUsuario(idUsuario.Value);

                foreach (var grupo in grupos)
                {
                    foreach (var grupoUsuario in gruposUsuario)
                    {
                        if(grupo.IdGrupo == grupoUsuario.IdGrupo)
                        {
                            grupo.Selecionado = true;
                        }
                    }
                }
            }

			return grupos;
        }

        public List<Grupo> ListarGruposUsuario(int idUsuario)
        {
            return _grupoDAL.ListarGruposUsuario(idUsuario);

        }

        public Grupo ProcurarGrupoPorId(int idGrupo)
        {
			var retorno = _grupoDAL.ProcurarGrupoPorId(idGrupo);

			return retorno;
		}
	}
}
