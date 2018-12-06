using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNIP.PIM.HelpDesk.DAO.Conexao;
using UNIP.PIM.HelpDesk.DAO.Interfaces;
using UNIP.PIM.HelpDesk.DTO.Chamado;
using UNIP.PIM.HelpDesk.DTO.Grupo;

namespace UNIP.PIM.HelpDesk.DAO
{
    public class ChamadoDAL :ConexaoBase, IChamadoDAL
    {
        private readonly IGrupoDAL _grupo;
        private readonly ISolicitacaoDAL _solicitacao;

        public ChamadoDAL()
        {

        }

        public ChamadoDAL(IGrupoDAL grupo, ISolicitacaoDAL solicitacao)
        {
            _grupo = grupo;
            _solicitacao = solicitacao;
        }

        public void Incluir(Chamado chamado, long idUsuario)
        {
			var conexao = RetornaConexao();
            var conclusao = RetornaDataConclusaoPrevista(chamado).ToString("yyyy-MM-dd HH:mm:ss");

            string query = $@"INSERT INTO tblChamado 
                                        ([Titulo]
                                       ,[DataAbertura]
                                       ,[DataConclusaoPrevista]
                                       ,[DataFechamento]
                                       ,[IdStatus]
                                       ,[IdSolicitacao]
									   ,[IdUsuarioAbertura]
									   ,[IdTecnico])
                                 VALUES
                                       ('{chamado.Titulo}',
                                         getdate(),
                                         '{conclusao}',
                                         null,
                                        '{chamado.IdStatus}',
                                        '{chamado.IdSolicitacao}',
                                        '{idUsuario}',
                                        null                
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

            IncluirOcorrencia(chamado.Ocorrencias);
		}

        private void IncluirOcorrencia(List<Ocorrencia> ocorrencias)
        {
            var conexao = RetornaConexao();
            long idChamado = RetornaIdChamado();

            foreach (var item in ocorrencias)
            {
                string query = $@"INSERT INTO tblOcorrencia
                                        ([IdChamado]
                                       ,[DataAlteracao]
                                       ,[IdUsuarioAlteracao]
                                       ,[Descricao])
                                 VALUES
                                       ('{idChamado}',
                                        getdate(),
                                        '{item.IdUsuarioAlteracao}',
                                        '{item.Descricao}'                  
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

        public void Editar(Chamado chamado)
        {
            var conexao = RetornaConexao();
            string dataFechamento = string.Empty;
            string tecnico = string.Empty;

            var status = ListarStatus().Where(x => x.Key == chamado.IdStatus).FirstOrDefault().Value;

            if(status == "Encerrado")
            {
                dataFechamento = $"DataFechamento = getdate(),";
            }

            if(chamado.IdTecnico > 0)
            {
                tecnico = $"IdTecnico = {chamado.IdTecnico},";
            }

            string query = $@"UPDATE tblChamado
								SET 
								Titulo='{chamado.Titulo}',
								{dataFechamento}
								{tecnico}
								IdStatus='{chamado.IdStatus}'
							 WHERE idChamado={chamado.IdChamado}";
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

            RemoverOcorrencias(chamado.IdChamado);
            IncluirOcorrencia(chamado.Ocorrencias);
        }

        private void RemoverOcorrencias(long idChamado)
        {
            var conexao = RetornaConexao();
            string query = $"DELETE FROM tblChamado WHERE idChamado={idChamado}";

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

        public List<Chamado> ListarChamados(long idUsuario, bool usuarioTecnico)
        {
            SqlDataReader dr = null;
            var listaCliente = new List<Chamado>();
            string where = string.Empty;

            var conexao = RetornaConexao();

            where = $" c.IdUsuarioAbertura = {idUsuario}";

            if (usuarioTecnico == true)
            {
                var idsGrupo = string.Join(",", _grupo.ListarGruposUsuario(idUsuario).Select(x => x.IdGrupo).ToList());

                if (idsGrupo.Any())
                {
                    where = where + $" OR g.IdGrupo IN({idsGrupo}) ";
                }
            }

            try
            {
                conexao.Open();

                string query = $@"SELECT  
									c.IdChamado,
									c.Titulo,
									u.Nome as Tecnico,
									s.Descricao as Status,
                                    c.DataAbertura,
                                    c.DataConclusaoPrevista,
                                    c.DataFechamento,
                                    g.Descricao AS Grupo
								FROM tblChamado c
                                INNER JOIN tblStatus s
                                ON s.idStatus = c.IdStatus
								INNER JOIN tblSolicitacao sl
								ON sl.IdSolicitacao = c.IdSolicitacao
								LEFT JOIN tblGrupo g
								ON g.IdGrupo = sl.IdGrupo
                                LEFT JOIN tblUsuario u
                                ON u.IdUsuario = c.IdTecnico
                               WHERE {where}";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaCliente.Add(new Chamado
                    {
                        IdChamado = Convert.ToInt32(dr["IdChamado"]),
                        Titulo = Convert.ToString(dr["Titulo"]),
                        Tecnico = dr["Tecnico"] != DBNull.Value ? Convert.ToString(dr["Tecnico"]) : string.Empty,
                        Status = Convert.ToString(dr["Status"]),
                        DataAbertura = dr["DataAbertura"] != DBNull.Value ? Convert.ToDateTime(dr["DataAbertura"]) : new DateTime(),
                        DataConclusaoPrevista = dr["DataConclusaoPrevista"] != DBNull.Value ? Convert.ToDateTime(dr["DataConclusaoPrevista"]) : new DateTime(),
                        DataFechamento = dr["DataFechamento"] != DBNull.Value ? Convert.ToDateTime(dr["DataFechamento"]) : new DateTime(),
                        Grupo = dr["Grupo"] != DBNull.Value ? Convert.ToString(dr["Grupo"]) : string.Empty,
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

        public List<Chamado> ListarChamadosRelatorio(string idchamado, string titulo, string status, string tecnico, string usuario, string solicitacao, string dataAbertura, string dataFechamento, string dataConclusao )
        {
            SqlDataReader dr = null;
            var listaCliente = new List<Chamado>();
            string where = string.Empty;

            if (!string.IsNullOrEmpty(idchamado) && idchamado != " ")
            {
                where = $" AND c.IdChamado = {idchamado}";
            }
            if (!string.IsNullOrEmpty(titulo))
            {
                where += $" AND c.Titulo like '%{idchamado}%";
            }
            if (!string.IsNullOrEmpty(status))
            {
                where += $" AND s.Descricao = '{status}'";
            }
            if (!string.IsNullOrEmpty(tecnico))
            {
                where += $" AND u.Nome = '{tecnico}'";
            }
            if (!string.IsNullOrEmpty(usuario))
            {
                where += $" AND ua.Nome = '{usuario}'";
            }
            if (!string.IsNullOrEmpty(solicitacao))
            {
                where += $" AND sl.Descricao = '{solicitacao}'";
            }

            if (!string.IsNullOrEmpty(dataAbertura) && dataAbertura != " ")
            {
                where += $" AND c.dataAbertura = '{dataAbertura}'";
            }

            if (!string.IsNullOrEmpty(dataFechamento) && dataFechamento != " ")
            {
                where += $" AND c.dataFechamento = '{dataFechamento}'";
            }

            if (!string.IsNullOrEmpty(dataConclusao) && dataConclusao != " ")
            {
                where += $" AND c.dataConclusao = '{dataConclusao}'";
            }

            if (!string.IsNullOrEmpty(where))
            {
                where = $"WHERE 10 = 10 {where}";
            }
            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = $@"SELECT 
                                    c.IdChamado,
									c.Titulo,
									u.Nome as Tecnico,
	                                ua.Nome as UsuarioSolicitante,
									s.Descricao as Status,
                                    c.DataAbertura,
                                    c.DataConclusaoPrevista,
                                    c.DataFechamento,
                                    g.Descricao AS Grupo,
                                    sl.Descricao as Solicitacao
                                  FROM tblChamado c
                                LEFT JOIN tblStatus s
                                ON s.idStatus = c.IdStatus
								LEFT JOIN tblSolicitacao sl
								ON sl.IdSolicitacao = c.IdSolicitacao
								LEFT JOIN tblGrupo g
								ON g.IdGrupo = sl.IdGrupo
                                LEFT JOIN tblUsuario u
                                ON u.IdUsuario = c.IdTecnico
                                LEFT JOIN tblUsuario ua
                                ON ua.IdUsuario = c.IdUsuarioAbertura
                                {where}";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaCliente.Add(new Chamado
                    {
                        IdChamado = Convert.ToInt32(dr["IdChamado"]),
                        Titulo = Convert.ToString(dr["Titulo"]),
                        DataAbertura = dr["DataAbertura"] != DBNull.Value ? Convert.ToDateTime(dr["DataAbertura"]) : new DateTime(),
                        DataConclusaoPrevista = dr["DataConclusaoPrevista"] != DBNull.Value ? Convert.ToDateTime(dr["DataConclusaoPrevista"]) : new DateTime(),
                        DataFechamento = dr["DataFechamento"] != DBNull.Value ? Convert.ToDateTime(dr["DataFechamento"]) : new DateTime(),
                        Status = dr["Status"] != DBNull.Value ? Convert.ToString(dr["Status"]) : string.Empty,
                        Solicitacao = dr["Solicitacao"] != DBNull.Value ? Convert.ToString(dr["Solicitacao"]) : string.Empty,
                        IdUsuarioAbertura = 0,
                        Tecnico = dr["Tecnico"] != DBNull.Value ? Convert.ToString(dr["Tecnico"]) : string.Empty,
                        UsuarioSolicitante = dr["UsuarioSolicitante"] != DBNull.Value ? Convert.ToString(dr["UsuarioSolicitante"]) : string.Empty,
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

        public List<Ocorrencia> ListarOcorrencias(int idChamado)
        {
            SqlDataReader dr = null;
            var listaOcorrencias = new List<Ocorrencia>();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = $@"SELECT o.[IdOcorrencia]
                                          ,o.[IdChamado]
                                          ,o.[DataAlteracao]
                                          ,o.[IdUsuarioAlteracao]
                                          ,o.[Descricao]
                                          ,u.Nome as Usuario
                                      FROM [dbo].[tblOcorrencia] o
                                      INNER JOIN tblUsuario u
                                      ON u.IdUsuario = o.IdUsuarioAlteracao
                                      WHERE o.IdChamado = {idChamado}";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaOcorrencias.Add(new Ocorrencia
                    {
                        IdOcorrencia = Convert.ToInt32(dr["IdOcorrencia"]),
                        Descricao = Convert.ToString(dr["Descricao"]),
                        Usuario = dr["Usuario"] != DBNull.Value ? Convert.ToString(dr["Usuario"]) : string.Empty,
                        IdUsuarioAlteracao = Convert.ToInt32(dr["IdUsuarioAlteracao"]),
                        DataAlteracao = dr["DataAlteracao"] != DBNull.Value ? Convert.ToDateTime(dr["DataAlteracao"]) : new DateTime(),
                        IdChamado = dr["IdChamado"] != DBNull.Value ? Convert.ToInt64(dr["IdChamado"]) : 0,
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

            return listaOcorrencias;
        }

        public Dictionary<int, string> ListarStatus()
        {
            SqlDataReader dr = null;
            var listaStatus = new Dictionary<int, string>();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = @"SELECT  
									IdStatus, Descricao
                                FROM tblStatus";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaStatus.Add(Convert.ToInt32(dr["IdStatus"]), Convert.ToString(dr["Descricao"]));
 
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

            return listaStatus;
        }

        public List<Feriado> ListarFeriado()
        {
            SqlDataReader dr = null;
            var listaFeriado = new List<Feriado>();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = @"SELECT  
									[IdFeriado]
                                      ,[Dia]
                                      ,[Mes]
                                      ,[Ano]
                                      ,[Ativo]
                                      ,[Descricao]
                                      ,[FeriadoMovel]
                                  FROM [dbo].[tblFeriado]
                                  WHERE Ativo = 1";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listaFeriado.Add(new Feriado
                    {
                        IdFeriado = Convert.ToInt32(dr["IdFeriado"]),
                        Dia = Convert.ToInt32(dr["Dia"]),
                        Mes = Convert.ToInt32(dr["Mes"]),
                        Ano = Convert.ToInt32(dr["Ano"]),
                        FeriadoMovel = Convert.ToBoolean(dr["FeriadoMovel"]),
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

            return listaFeriado;
        }

        public Chamado ProcurarChamadoPorId(int idChamado)
        {
            SqlDataReader dr = null;
            var chamado = new Chamado();

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = $@"SELECT  
									c.IdChamado,
									c.Titulo,
									c.IdTecnico,
									c.IdStatus,
                                    c.DataAbertura,
                                    c.DataConclusaoPrevista,
                                    c.DataFechamento,
                                    sl.IdGrupo,
                                    c.IdSolicitacao,
                                    c.IdUsuarioAbertura
								FROM tblChamado c
								INNER JOIN tblSolicitacao sl
								ON sl.IdSolicitacao = c.IdSolicitacao
                            WHERE c.IdChamado = {idChamado}";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    chamado =  new Chamado
                    {
                        IdChamado = Convert.ToInt32(dr["IdChamado"]),
                        Titulo = Convert.ToString(dr["Titulo"]),
                        IdTecnico = dr["IdTecnico"] != DBNull.Value ? Convert.ToInt32(dr["IdTecnico"]) : 0,
                        IdStatus = Convert.ToInt32(dr["IdStatus"]),
                        DataAbertura = dr["DataAbertura"] != DBNull.Value ? Convert.ToDateTime(dr["DataAbertura"]) : new DateTime(),
                        DataConclusaoPrevista = dr["DataConclusaoPrevista"] != DBNull.Value ? Convert.ToDateTime(dr["DataConclusaoPrevista"]) : new DateTime(),
                        DataFechamento = dr["DataFechamento"] != DBNull.Value ? Convert.ToDateTime(dr["DataFechamento"]) : new DateTime(),
                        IdGrupo = dr["IdGrupo"] != DBNull.Value ? Convert.ToInt32(dr["IdGrupo"]) : 0,
                        IdSolicitacao = dr["IdSolicitacao"] != DBNull.Value ? Convert.ToInt32(dr["IdSolicitacao"]) : 0,
                        IdUsuarioAbertura = dr["IdUsuarioAbertura"] != DBNull.Value ? Convert.ToInt32(dr["IdUsuarioAbertura"]) : 0,
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

            chamado.Ocorrencias = ListarOcorrencias(idChamado);

            return chamado;
        }

        private long RetornaIdChamado()
        {
            SqlDataReader dr = null;
            long idChamado = 0;

            var conexao = RetornaConexao();

            try
            {
                conexao.Open();

                string query = $@"SELECT max(idChamado) AS IdChamado FROM tblChamado";

                SqlCommand cmd = new SqlCommand(query, conexao);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    idChamado = Convert.ToInt32(dr["IdChamado"]);
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

        private DateTime RetornaDataConclusaoPrevista(Chamado chamado)
        {
            var dataAbertura = chamado.DataAbertura;
            var conclusaoPrevista = DateTime.MinValue;

            var solicitacao = _solicitacao.ProcurarSolicitacaoPorId(chamado.IdSolicitacao);
            var sla = Convert.ToDouble(solicitacao.Sla);
            var grupo = new Grupo();

            if (solicitacao.IdGrupo.HasValue)
            {
                grupo = _grupo.ProcurarGrupoPorId(solicitacao.IdGrupo.Value);
            }

            conclusaoPrevista = dataAbertura.AddHours(sla);
            var diaUtil = true;

            do
            {
                var feriado = ListarFeriado().Where(x => x.Dia == conclusaoPrevista.Day && x.Mes == conclusaoPrevista.Month && x.Ano == conclusaoPrevista.Year).Any();
                var diaSemana = conclusaoPrevista.DayOfWeek.ToString().ToUpper();

                if (feriado)
                {
                    conclusaoPrevista = conclusaoPrevista.AddDays(1);
                    diaUtil = false;
                }

                else if(RetornaDiaTrabalhado(grupo, diaSemana) == false)
                {
                    conclusaoPrevista = conclusaoPrevista.AddDays(1);
                    diaUtil = false;
                }
                else
                {
                    diaUtil = true;
                }

            } while (diaUtil == false);

            return conclusaoPrevista;

        }

        private bool RetornaDiaTrabalhado(Grupo grupo, string diaSemana)
        {
            var diaTrabalhado = true;

            switch (diaSemana)
            {
                case "SUNDAY":
                    diaTrabalhado = grupo.DomingoDiaUtil;
                    break;
                case "MONDAY":
                    diaTrabalhado = grupo.SegundaDiaUtil;
                    break;
                case "TUESDAY":
                    diaTrabalhado = grupo.TercaDiaUtil;
                    break;
                case "WEDNESDAY":
                    diaTrabalhado = grupo.QuartaDiaUtil;
                    break;
                case "THURSDAY":
                    diaTrabalhado = grupo.QuintaDiaUtil;
                    break;
                case "FRIDAY":
                    diaTrabalhado = grupo.SextaDiaUtil;
                    break;
                case "SATURDAY":
                    diaTrabalhado = grupo.SabadoDiaUtil;
                    break;
                default:
                    diaTrabalhado = true;
                    break;
            }

            return diaTrabalhado;
        }
    }
}
