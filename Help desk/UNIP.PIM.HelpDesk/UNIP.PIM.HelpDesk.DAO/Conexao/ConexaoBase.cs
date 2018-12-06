using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UNIP.PIM.HelpDesk.DAO.Conexao
{
    public class ConexaoBase
    {
       
        public SqlConnection RetornaConexao()
        {
            string strConexao = ConfigurationManager.ConnectionStrings["HelpDeskConnection"].ConnectionString;
            return new SqlConnection(strConexao);
        }

    }
}
