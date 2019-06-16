using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_SIMPLIFICADO.Models
{
    public class Repositorio : IDisposable
    {
        private SqlConnection connection;

        public Repositorio()
        {
            string strConn = "Data Source=localhost;Initial Catalog=Cadastro;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Pessoa pessoa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO usuarios VALUES (@nome, @cpf, @rg, @telefoneFixo, @telefoneCelular, @endereco, @email, @observacoes)";

            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@email", pessoa.CPF);
            cmd.Parameters.AddWithValue("@email", pessoa.RG);
            cmd.Parameters.AddWithValue("@email", pessoa.TelefoneFixo);
            cmd.Parameters.AddWithValue("@email", pessoa.TelefoneCelular);
            cmd.Parameters.AddWithValue("@email", pessoa.Email);
            cmd.Parameters.AddWithValue("@email", pessoa.Observacoes);


            cmd.ExecuteNonQuery();
        }

        public List<Pessoa> Read()
        {

            List<Pessoa> lista = new List<Pessoa>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM usuarios";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Pessoa pessoa = new Pessoa();
                pessoa.Id = (int)reader["Id"];
                pessoa.Nome = (string)reader["Nome"];
                pessoa.CPF = (int)reader["CPF"];
                pessoa.RG = (int)reader["RG"];
                pessoa.TelefoneFixo = (int)reader["TelefoneFixo"];
                pessoa.TelefoneCelular = (int)reader["TelefoneCelular"];
                pessoa.Endereco = (string)reader["Endereco"];
                pessoa.Email = (string)reader["Email"];
                pessoa.Observacoes = (string)reader["Observacoes"];

                lista.Add(pessoa);
            }

            return lista;
        }

        public void Update(Pessoa pessoa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE usuario SET Nome=@nome, CPF=@cpf, @RG=rg, @TelefoneFixo=telefoneFixo, @TelefoneCelular=telefoneCelular, @Endreco=endereco, @Email=email, @Observacoes=observacoes WHERE IdContato=@id";

            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@cpf", pessoa.CPF);
            cmd.Parameters.AddWithValue("@rg", pessoa.RG);
            cmd.Parameters.AddWithValue("@telefoneFixo", pessoa.TelefoneFixo);
            cmd.Parameters.AddWithValue("@telefoneCelular", pessoa.TelefoneCelular);
            cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
            cmd.Parameters.AddWithValue("@email", pessoa.Email);
            cmd.Parameters.AddWithValue("@observacoes", pessoa.Observacoes);
            cmd.Parameters.AddWithValue("@id", pessoa.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM usuarios WHERE Id=@id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}