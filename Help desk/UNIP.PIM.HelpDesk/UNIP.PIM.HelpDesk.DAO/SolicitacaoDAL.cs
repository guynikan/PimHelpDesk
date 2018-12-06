using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UNIP.PIM.HelpDesk.DAO.Conexao;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.SolicitacaoChamado;

namespace UNIP.PIM.HelpDesk.DAO
{
    public class SolicitacaoDAL :ConexaoBase, ISolicitacaoDAL
    {
		public void AlterarStatus(int idSolicitacao, bool status)
		{
            var conexao = RetornaConexao();
            string query = $"UPDATE tblSolicitacao SET ativo='{status}' WHERE idSolicitacao={idSolicitacao}";

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

		public void Incluir(Solicitacao solicitacao)
		{
            var conexao = RetornaConexao();

            string query = $@"INSERT INTO tblSolicitacao
                                          ([Codigo]
                                          ,[Descricao]
                                          ,[IdGrupo]
                                          ,[Sla]
                                          ,Ativo)
                                        VALUES
                                           ('{solicitacao.Codigo}',
                                            '{solicitacao.Descricao}',
                                            '{solicitacao.IdGrupo}',
                                            '{solicitacao.Sla}',
                                            '{solicitacao.Ativo}'

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

		public void Editar(Solicitacao solicitacao)
		{
			var conexao = RetornaConexao();
			string query = $@"UPDATE tblSolicitacao 
								SET 
								Codigo='{solicitacao.Codigo}',
								Descricao='{solicitacao.Descricao}',
								IdGrupo='{solicitacao.IdGrupo}',
								Sla='{solicitacao.Ativo}',
							 WHERE idSolicitacao={solicitacao.IdSolicitacao}";
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

		public List<Solicitacao> ListarSolicitacoes()
        {
			SqlDataReader dr = null;
			var listaSolicitacao = new List<Solicitacao>();

			var conexao = RetornaConexao();

			try
			{
				conexao.Open();

				string query = @"SELECT 
									s.IdSolicitacao,
									s.Descricao,
									g.Descricao AS Grupo,
									s.Ativo
								FROM tblSolicitacao s
								LEFT JOIN tblGrupo g
								ON g.IdGrupo = s.Idgrupo";

				SqlCommand cmd = new SqlCommand(query, conexao);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					listaSolicitacao.Add(new Solicitacao
					{
						IdSolicitacao = Convert.ToInt32(dr["IdSolicitacao"]),
						Descricao = Convert.ToString(dr["Descricao"]),
						Grupo = dr["Grupo"] != DBNull.Value ? Convert.ToString(dr["Grupo"]) : string.Empty,
						Ativo = dr["Ativo"] != DBNull.Value ? Convert.ToBoolean(dr["Ativo"]) : false
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

			return listaSolicitacao;
		}

		public Solicitacao ProcurarSolicitacaoPorId(int idSolicitacao)
        {
			SqlDataReader dr = null;
			var Solicitacao = new Solicitacao();

			var conexao = RetornaConexao();

			try
			{
				string query = $"SELECT * FROM tblSolicitacao WHERE idSolicitacao = {idSolicitacao}";

				conexao.Open();

				SqlCommand cmd = new SqlCommand(query, conexao);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					Solicitacao = new Solicitacao
					{
						IdSolicitacao = Convert.ToInt32(dr["IdSolicitacao"]),
                        Codigo = Convert.ToString(dr["Codigo"]),
                        Descricao = Convert.ToString(dr["Descricao"]),
                        Sla = dr["Sla"] != DBNull.Value ? Convert.ToDecimal(dr["Sla"]) : 0,
                        IdGrupo = dr["IdGrupo"] != DBNull.Value ? Convert.ToInt32(dr["IdGrupo"]) : 0,
                        Ativo = dr["Ativo"] != DBNull.Value ? Convert.ToBoolean(dr["Ativo"]) : false
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

			return Solicitacao;
		}
	}
}
