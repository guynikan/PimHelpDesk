using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DTO.Cliente;

namespace UNIP.PIM.HelpDesk.DAO.Interfaces
{
    public interface IClienteDAL
    {
        List<Cliente> ListarClientes();
        Cliente ProcurarClientePorId(int idCliente);
		void Incluir(Cliente cliente);
		void AlterarStatus(int idCliente, bool status);
		void Editar(Cliente cliente);
	}
}
