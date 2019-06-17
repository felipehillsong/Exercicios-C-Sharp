using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CRUD_SIMPLIFICADO.Models
{
    public class Repositorio
    {
        protected SqlConnection ConexaoDados {
            get {
                return new SqlConnection(
ConfigurationManager.ConnectionStrings["ConexaoConnectionString"].ConnectionString);
            }
        }

        protected void ExecuteNonQuery(string sql, List<SqlParameter> parametros)
        {
            using (var conexao = ConexaoDados)
            {
                conexao.Open();
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sqlCommand;
                    foreach (var parametro in parametros)
                    {
                        comando.Parameters.Add(parametro);
                    }
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
                
            }
        }
    }
}
