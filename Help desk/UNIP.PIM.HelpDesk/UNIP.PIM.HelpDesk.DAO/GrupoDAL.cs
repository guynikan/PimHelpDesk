using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DAO.Conexao;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Grupo;

namespace UNIP.PIM.HelpDesk.DAO
{
    public class GrupoDAL :ConexaoBase, IGrupoDAL
    {
		public void AlterarStatus(int idGrupo, bool status)
		{
            var conexao = RetornaConexao();
            string query = $"UPDATE tblGrupo SET ativo='{status}' WHERE idGrupo={idGrupo}";

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

		public void Incluir(Grupo Grupo)
		{
            int idJornadaTrabalho = 0;
            var conexao = RetornaConexao();
            string query = $@"INSERT INTO tblGrupo 
                                        ([Descricao]
                                       ,[Ativo]
                                       ,[Codigo]
                                       ,[HorarioInicio]
                                       ,[HorarioFim]
                                       ,[Segunda]
                                       ,[Terca]
                                       ,[Quarta]
                                       ,[Quinta]
                                       ,[Sexta]
                                       ,[Sabado]
                                       ,[Domingo])
                                 VALUES
                                       ('{Grupo.Descricao}',
                                        '{Grupo.Ativo}',
                                        '{Grupo.Codigo}',
                                        '{Grupo.HorarioInicio}',
                                        '{Grupo.HorarioFim}',
                                        '{Grupo.SegundaDiaUtil}',
                                        '{Grupo.TercaDiaUtil}',
                                        '{Grupo.QuartaDiaUtil}',
                                        '{Grupo.QuintaDiaUtil}',
                                        '{Grupo.SextaDiaUtil}',
                                        '{Grupo.SabadoDiaUtil}',
                                        '{Grupo.DomingoDiaUtil}'                                   
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

        private int IncluirJornadaTrabalho(Grupo grupo)
        {
            int idJornadaTrabalho = 0;
            var conexao = RetornaConexao();
            string query = $@"INSERT INTO tblJornadaTrabalho
                                           ([Segunda]
                                           ,[Terca]
                                           ,[Quarta]
                                           ,[Quinta]
                                           ,[Sexta]
                                           ,[Sabado]
                                           ,[Domingo])
                                            OUTPUT Inserted.IdJornadaTrabalho
                                 VALUES
                                       ('{grupo.SegundaDiaUtil}',
                                        '{grupo.TercaDiaUtil}',
                                        '{grupo.QuartaDiaUtil}',
                                        '{grupo.QuintaDiaUtil}',
                                        '{grupo.SextaDiaUtil}',
                                        '{grupo.SabadoDiaUtil}',
                                        '{grupo.DomingoDiaUtil}'                   
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

            return idJornadaTrabalho;
        }

		public void Editar(Grupo grupo)
		{
			var conexao = RetornaConexao();
			string query = $@"UPDATE tblGrupo
								SET 
								Descricao='{grupo.Descricao}',
								Ativo='{grupo.Ativo}',
								Codigo='{grupo.Codigo}',
								HorarioInicio='{grupo.HorarioInicio}',
								HorarioFim='{grupo.HorarioFim}',
								IdJornadaTrabalho='{0}',
							 WHERE idGrupo={grupo.IdGrupo}";
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

		public List<Grupo> ListarGrupos()
        {
			SqlDataReader dr = null;
			var listaGrupo = new List<Grupo>();

			var conexao = RetornaConexao();

			try
			{
				conexao.Open();

				string query = @"SELECT 
									IdGrupo,
									Descricao,
									Ativo
								FROM tblGrupo";

				SqlCommand cmd = new SqlCommand(query, conexao);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					listaGrupo.Add(new Grupo
					{
						IdGrupo = Convert.ToInt32(dr["IdGrupo"]),
						Descricao = Convert.ToString(dr["Descricao"]),
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

			return listaGrupo;
		}

        public List<Grupo> ListarGruposUsuario(long idUsuario)
        {
            SqlDataReader dr = null;
            var listaGrupo = new List<Grupo>();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = $@"SELECT 
									g.IdGrupo,
									g.Descricao,
									g.Ativo
								FROM tblGrupoUsuario gu
                                INNER JOIN tblGrupo g
                                ON g.IdGrupo = gu.IdGrupo
                                WHERE gu.IdUsuario = {idUsuario}";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaGrupo.Add(new Grupo
                    {
                        IdGrupo = Convert.ToInt32(dr["IdGrupo"]),
                        Descricao = Convert.ToString(dr["Descricao"]),
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

            return listaGrupo;
        }

        public Grupo ProcurarGrupoPorId(int idGrupo)
        {
			SqlDataReader dr = null;
			var Grupo = new Grupo();

			var conexao = RetornaConexao();

			try
			{
				string query = $"SELECT * FROM tblGrupo WHERE idGrupo = {idGrupo}";

				conexao.Open();

				SqlCommand cmd = new SqlCommand(query, conexao);
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					Grupo = new Grupo
					{
						IdGrupo = Convert.ToInt32(dr["IdGrupo"]),
						Descricao = Convert.ToString(dr["Descricao"]),
                        Codigo = Convert.ToString(dr["Codigo"]),
                        Ativo = Convert.ToBoolean(dr["Ativo"]),
                        SegundaDiaUtil = Convert.ToBoolean(dr["Segunda"]),
                        TercaDiaUtil = Convert.ToBoolean(dr["Terca"]),
                        QuartaDiaUtil = Convert.ToBoolean(dr["Quarta"]),
                        QuintaDiaUtil = Convert.ToBoolean(dr["Quinta"]),
                        SextaDiaUtil = Convert.ToBoolean(dr["Sexta"]),
                        SabadoDiaUtil = Convert.ToBoolean(dr["Sabado"]),
                        DomingoDiaUtil = Convert.ToBoolean(dr["Domingo"]),
                        HorarioInicio = Convert.ToDecimal(dr["HorarioInicio"]),
                        HorarioFim = Convert.ToDecimal(dr["HorarioFim"]),

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

			return Grupo;
		}
    }
}
