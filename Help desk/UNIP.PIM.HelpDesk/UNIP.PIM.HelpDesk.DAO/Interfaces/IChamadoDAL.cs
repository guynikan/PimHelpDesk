using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DTO.Chamado;

namespace UNIP.PIM.HelpDesk.DAO.Interfaces
{
    public interface IChamadoDAL
    {
        Chamado ProcurarChamadoPorId(int idChamado);
        void Incluir(Chamado Chamado, long idUsuario);
        Dictionary<int, string> ListarStatus();
        List<Chamado> ListarChamados(long idUsuario, bool usuarioTecnico);
        void Editar(Chamado chamado);
    }
}
