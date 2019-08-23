using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WEB_EF.Conexao
{
    class BD : IDisposable
    {
        private readonly SqlConnection conexao;

        public BD()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
            conexao.Open();
        }
        //usa para INSERT, UPTADE E DELETE
        public void ExecutarComandoSemRetorno(string exeQuery)
        {
            var comando = new SqlCommand
            {
                CommandText = exeQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };

            comando.ExecuteNonQuery();
        }
        //usa apenas para SELECT
        public SqlDataReader ExecutaComandoComRetorno(string exeQuery)
        {
            var comandoSelect = new SqlCommand(exeQuery, conexao);
            return comandoSelect.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
