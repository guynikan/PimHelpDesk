using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Chamado;

namespace UNIP.PIM.HelpDesk.BLL
{
    public class ChamadoBLL : IChamadoBLL
    {
        private readonly IChamadoDAL _chamado;

        public ChamadoBLL(IChamadoDAL chamado)
        {
            _chamado = chamado;
        }

        public void Incluir(Chamado chamado, long idUsuario)
        {
            if(chamado.IdChamado > 0)
            {
                _chamado.Editar(chamado);
            }
            else
            {
                _chamado.Incluir(chamado, idUsuario);
            }
        }

        public List<Chamado> ListarChamados(long idUsuario, bool usuarioTecnico)
        {
            var retorno = _chamado.ListarChamados(idUsuario, usuarioTecnico);

            return retorno;
        }

        public Dictionary<int, string> ListarStatus()
        {
            var retorno = _chamado.ListarStatus();

            return retorno;
        }

        public Chamado ProcurarChamadoPorId(int idChamado)
        {
            var retorno = _chamado.ProcurarChamadoPorId(idChamado);

            return retorno;
        }
    }
}
