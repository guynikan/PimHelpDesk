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
using UNIP.PIM.HelpDesk.DTO.Login;
using UNIP.PIM.HelpDesk.DTO.Perfil;
using UNIP.PIM.HelpDesk.DTO.Usuario;

namespace UNIP.PIM.HelpDesk.DAO
{
    public class UsuarioDAL : ConexaoBase, IUsuarioDAL
    {
		public void AlterarStatus(long idUsuario, bool status)
		{
            var conexao = RetornaConexao();
            string query = $"UPDATE tblUsuario SET ativo='{status}' WHERE idUsuario={idUsuario}";

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

        private void ExcluirPerfisUsuario(long idUsuario)
        {
            var conexao = RetornaConexao();
            string query = $"DELETE FROM tblPerfilUsuario WHERE idUsuario={idUsuario}";

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

        private void ExcluirGruposUsuario(long idUsuario)
        {
            var conexao = RetornaConexao();
            string query = $"DELETE FROM tblGrupoUsuario WHERE idUsuario={idUsuario}";

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

        public void Incluir(Usuario usuario)
		{
			if (usuario != null)
			{
				var conexao = RetornaConexao();
				string query = $@"INSERT INTO tblUsuario
                                       ([Nome]
                                       ,[Email]
                                       ,[Senha]
                                       ,[Ativo]
                                       ,[IdCliente])
                                 VALUES 
                                       ('{usuario.Nome }',
                                        '{usuario.Email}',
                                        '{usuario.Senha}',
                                        '{usuario.Ativo}',
                                        '{usuario.IdCliente}'
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

            long idUsuario = RetornaIdUsuario();

            IncluirGrupoUsuario(usuario.Grupos.Where(x => x.Selecionado).ToList(), idUsuario);
            IncluirUsuarioPerfil(usuario.Perfis.Where(x => x.Selecionado).ToList(), idUsuario);
		}

        public void IncluirUsuarioPerfil(List<Perfil> perfis, long idUsuario)
        {
            var conexao = RetornaConexao();

            if (perfis.Any())
            {
                foreach (var item in perfis)
                {
                    string query = $@"INSERT INTO [dbo].[tblUsuarioPerfil]
                                       ([IdUsuario]
                                       ,[IdPerfil])
                                 VALUES 
                                       ('{idUsuario }',
                                        '{item.IdPerfil}'
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
               
        }

        public void IncluirGrupoUsuario(List<Grupo> grupos, long idUsuario)
        {
            var conexao = RetornaConexao();

            if (grupos.Any())
            {
                foreach (var item in grupos)
                {
                    string query = $@"INSERT INTO [dbo].[tblGrupoUsuario]
                                       ([IdUsuario]
                                       ,[IdGrupo])
                                 VALUES 
                                       ('{idUsuario }',
                                        '{item.IdGrupo}'
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

        }

        public void Editar(Usuario usuario)
		{
			var conexao = RetornaConexao();
			string query = $@"UPDATE tblUsuario 
								SET 
								Nome='{usuario.Nome}',
								Email='{usuario.Email}',
								Senha='{usuario.Senha}',
								Ativo='{usuario.Ativo}',
								IdCliente='{usuario.IdCliente}' 
							 WHERE idUsuario={usuario.IdUsuario}";
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

            ExcluirGruposUsuario(usuario.IdUsuario);
            ExcluirPerfisUsuario(usuario.IdUsuario);

            IncluirGrupoUsuario(usuario.Grupos.Where(x => x.Selecionado == true).ToList(), usuario.IdUsuario);
            IncluirUsuarioPerfil(usuario.Perfis.Where(x => x.Selecionado == true).ToList(), usuario.IdUsuario);
        }

        public List<Usuario> Listar()
        {
            SqlDataReader dr = null;
            var listaUsuario = new List<Usuario>();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = @"SELECT 
                                    u.IdUsuario, 
                                    u.Ativo,
                                    c.NomeFantasia,
                                    u.Nome,
                                    u.Email
                                FROM tblUsuario u 
                                INNER JOIN tblCliente c ON u.idCliente = c.idCliente ";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaUsuario.Add(new Usuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Cliente = Convert.ToString(dr["NomeFantasia"]),
                        Nome = Convert.ToString(dr["Nome"]),
                        Email = Convert.ToString(dr["Email"]),
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

            return listaUsuario;
        }

        public List<Perfil> ListarPerfis()
        {
            SqlDataReader dr = null;
            var listaPerfil = new List<Perfil>();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = @"SELECT [IdPerfil]
                                  ,[Codigo]
                                  ,[Descricao]
                                  ,[Ativo]
                            FROM [dbo].[tblPerfil]";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaPerfil.Add(new Perfil
                    {
                        IdPerfil = Convert.ToInt32(dr["IdPerfil"]),
                        Descricao = Convert.ToString(dr["Descricao"]),
                        Codigo = Convert.ToString(dr["Codigo"]),
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

            return listaPerfil;
        }

        public List<Perfil> ListarPerfisUsuario(long idUsuario)
        {
            SqlDataReader dr = null;
            var listaPerfil = new List<Perfil>();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = $@"SELECT p.[IdPerfil]
                                  ,p.[Codigo]
                                  ,p.[Descricao]
                                  ,p.[Ativo]
                            FROM [dbo].[tblUsuarioPerfil] up
                            INNER JOIN tblPerfil p
                            ON p.idPerfil = up.IdPerfil
                            WHERE up.IdUsuario= {idUsuario}";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaPerfil.Add(new Perfil
                    {
                        IdPerfil = Convert.ToInt32(dr["IdPerfil"]),
                        Descricao = Convert.ToString(dr["Descricao"]),
                        Codigo = Convert.ToString(dr["Codigo"]),
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

            return listaPerfil;
        }

        public Usuario ProcurarPorId(long idUsuario)
        {
            SqlDataReader dr = null;
            var usuario = new Usuario();

            var conexao = RetornaConexao();

            try
            {
                string query = $"SELECT * FROM tblUsuario WHERE idUsuario = {idUsuario}";

                conexao.Open();

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Nome = Convert.ToString(dr["Nome"]),
                        Email = Convert.ToString(dr["Email"]),
                        Ativo = Convert.ToBoolean(dr["Ativo"]),
						IdCliente = Convert.ToInt32(dr["IdCliente"]),
						Senha = Convert.ToString(dr["Senha"]),
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

            return usuario;
        }

        public bool RetornoAcessoValido(Login login)
        {
            SqlDataReader dr = null;
            var usuario = new Usuario();

            var conexao = RetornaConexao();

            try
            {
                string query = $"SELECT * FROM tblUsuario WHERE Email = '{login.Email}' AND Senha = '{login.Senha}'";

                conexao.Open();

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Nome = Convert.ToString(dr["Nome"]),
                        Email = Convert.ToString(dr["Email"]),
                        Ativo = Convert.ToBoolean(dr["Ativo"]),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        Senha = Convert.ToString(dr["Senha"]),
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

            return usuario.IdUsuario > 0;
        }

        private long RetornaIdUsuario()
        {
            SqlDataReader dr = null;
            long idChamado = 0;

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = $@"SELECT max(idUsuario) AS IdUsuario FROM tblUsuario";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    idChamado = Convert.ToInt32(dr["IdUsuario"]);
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

            return idChamado;
        }
    }
}
