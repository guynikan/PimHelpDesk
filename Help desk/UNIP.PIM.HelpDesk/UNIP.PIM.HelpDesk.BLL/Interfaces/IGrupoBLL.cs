using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DTO.Grupo;

namespace UNIP.PIM.HelpDesk.BLL.Interfaces
{
    public interface IGrupoBLL
    {
        List<Grupo> ListarGrupos(int? idUsuario);
        Grupo ProcurarGrupoPorId(int idGrupo);
		void Incluir(Grupo Grupo);
		void AlterarStatus(int idGrupo, bool status);
        List<Grupo> ListarGruposUsuario(int idUsuario);
    }
}
