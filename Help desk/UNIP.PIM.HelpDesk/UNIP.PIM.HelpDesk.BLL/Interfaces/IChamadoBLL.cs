using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DTO.Chamado;

namespace UNIP.PIM.HelpDesk.BLL.Interfaces
{
    public interface IChamadoBLL
    {
        List<Chamado> ListarChamados(long idUsuario, bool usuarioTecnico);
        Chamado ProcurarChamadoPorId(int idChamado);
        void Incluir(Chamado Chamado, long idUsuario);
        Dictionary<int, string> ListarStatus();

    }
}
