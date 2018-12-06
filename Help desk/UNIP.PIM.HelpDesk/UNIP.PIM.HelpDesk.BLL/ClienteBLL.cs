using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.BLL.Interfaces;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Cliente;

namespace UNIP.PIM.HelpDesk.BLL
{
    public class ClienteBLL : IClienteBLL
    {
        private readonly IClienteDAL _cliente;

        public ClienteBLL(IClienteDAL cliente)
        {
            _cliente = cliente;
        }

		public void AlterarStatus(int idCliente, bool status)
		{
            _cliente.AlterarStatus(idCliente, status);
		}

		public void Incluir(Cliente cliente)
		{
			if(cliente.IdCliente > 0)
			{
				_cliente.Editar(cliente);
			}
			else
			{
				_cliente.Incluir(cliente);
			}
		}

		public List<Cliente> ListarClientes()
        {
            var retorno = _cliente.ListarClientes();
            return retorno;
        }

        public Cliente ProcurarClientePorId(int idCliente)
        {
            var retorno = _cliente.ProcurarClientePorId(idCliente);
            return retorno;
        }
    }
}
