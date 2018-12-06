using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DTO.Grupo;

namespace UNIP.PIM.HelpDesk.DAO.Interfaces
{
    public interface IGrupoDAL
    {
        List<Grupo> ListarGrupos();
        Grupo ProcurarGrupoPorId(int idGrupo);
		void Incluir(Grupo Grupo);
		void AlterarStatus(int idGrupo, bool status);
		void Editar(Grupo grupo);
        List<Grupo> ListarGruposUsuario(long idUsuario);

    }
}
