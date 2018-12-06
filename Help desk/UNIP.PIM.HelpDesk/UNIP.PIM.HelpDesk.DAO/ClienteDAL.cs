using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UNIP.PIM.HelpDesk.DAO.Conexao;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Cliente;

namespace UNIP.PIM.HelpDesk.DAO
{
    public class ClienteDAL : ConexaoBase, IClienteDAL
    {
		public void AlterarStatus(int idCliente, bool status)
		{
            var conexao = RetornaConexao();
            string query = $"UPDATE tblCliente SET ativo='{status}' WHERE idCliente={idCliente}";

            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }
        }

        public void Incluir(Cliente cliente)
        {
            if (cliente != null)
            {
                var conexao = RetornaConexao();
                string query = $@"INSERT INTO tblCliente 
                                       ([NomeFantasia]
                                       ,[CNPJ]
                                       ,[CPF]
                                       ,[RazaoSocial]
                                       ,[Ativo]
                                       ,[Email]
                                       ,[Cidade]
                                       ,[UF]
                                       ,[Numero]
                                       ,[Complemento]
                                       ,[Endereco]
                                       ,[Bairro]
                                       ,[CEP])
                                 VALUES 
                                       ('{cliente.NomeFantasia }',
                                        '{cliente.CNPJ}',
                                        '{cliente.CPF}',
                                        '{cliente.RazaoSocial}',
                                        '{cliente.Ativo}',
                                        '{cliente.Email}',
                                        '{cliente.Cidade}',
                                        '{cliente.UF}',
                                        '{cliente.Numero}',
                                        '{cliente.Complemento}',
                                        '{cliente.Endereco}',
                                        '{cliente.Bairro}',
                                        '{cliente.Cep}'
                                        )";

                try
                {
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand(query, conexao);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                }
                finally
                {
                    if (conexao.State == ConnectionState.Open)
                        conexao.Close();
                }
            }
        }

		public void Editar(Cliente cliente)
		{
			var conexao = RetornaConexao();
			string query = $@"UPDATE tblCliente
								SET 
								NomeFantasia='{cliente.NomeFantasia}',
								CNPJ='{cliente.Ativo}',
								CPF='{cliente.CPF}',
								RazaoSocial='{cliente.RazaoSocial}',
								Ativo='{cliente.Ativo}',
								Email='{cliente.Email}',
								Cidade='{cliente.Cidade}',
								UF='{cliente.UF}',
								Numero='{cliente.Numero}',
								Complemento='{cliente.Complemento}',
								Endereco='{cliente.Endereco}',
								Bairro='{cliente.Bairro}',
								CEP='{cliente.Cep}'
							 WHERE idCliente={cliente.IdCliente}";
			try
			{
				conexao.Open();
				SqlCommand cmd = new SqlCommand(query, conexao);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				string erro = ex.Message;
			}
			finally
			{
				if (conexao.State == ConnectionState.Open)
					conexao.Close();
			}
		}

		public List<Cliente> ListarClientes()
        {
            SqlDataReader dr = null;
            var listaCliente = new List<Cliente>();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = @"SELECT  
									IdCliente,
									NomeFantasia,
									CNPJ,
									Ativo
								FROM tblCliente";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaCliente.Add(new Cliente
                    {
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        NomeFantasia = Convert.ToString(dr["NomeFantasia"]),
                        CNPJ = Convert.ToString(dr["CNPJ"]),
                        Ativo = Convert.ToBoolean(dr["Ativo"])
                    });
                }

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            finally
            {
                if (dr != null)
                    dr.Close();

                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }

            return listaCliente;
        }

        public Cliente ProcurarClientePorId(int idCliente)
        {
            SqlDataReader dr = null;
            var cliente = new Cliente();

            var conexao = RetornaConexao();

            try
            {
                string query = $"SELECT * FROM tblCliente WHERE idCliente = {idCliente}";

                conexao.Open();

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cliente = new Cliente
                    {
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        NomeFantasia = Convert.ToString(dr["NomeFantasia"]),
                        CNPJ = Convert.ToString(dr["CNPJ"]),
                        Bairro = Convert.ToString(dr["Bairro"]),
						Cep = Convert.ToString(dr["Cep"]),
						Email = Convert.ToString(dr["Email"]),
						Endereco = Convert.ToString(dr["Endereco"]),
						Numero = Convert.ToString(dr["Numero"]),
						Cidade = Convert.ToString(dr["Cidade"]),
						Complemento = Convert.ToString(dr["Complemento"]),
						Ativo = Convert.ToBoolean(dr["Ativo"]),
						RazaoSocial = Convert.ToString(dr["RazaoSocial"]),
					};
                }

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            finally
            {
                if (dr != null)
                    dr.Close();

                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }

            return cliente;
        }
    }
}
