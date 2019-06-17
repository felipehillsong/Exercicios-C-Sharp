using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_SIMPLIFICADO.Models
{
    public class PessoaRepositorio : Repositorio
    {
        public void Incluir(Pessoa pessoa)
        {
            var sql = "insert into usuarios(Nome, CPF, RG, TelefoneFixo, TelefoneCelular, Endereco, Email, Observacoes) values (@nome, @cpf, @rg, @telefoneFixo, @telefoneCelular, @endereco, @email, @observacoes)";
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nome", pessoa.Nome));
            parametros.Add(new SqlParameter("@cpf", pessoa.CPF));
            parametros.Add(new SqlParameter("@rg", pessoa.RG));
            parametros.Add(new SqlParameter("@telefoneFixo", pessoa.TelefoneFixo));
            parametros.Add(new SqlParameter("@telefoneCelular", pessoa.TelefoneCelular));
            parametros.Add(new SqlParameter("@endereco", pessoa.Endereco));
            parametros.Add(new SqlParameter("@email", pessoa.Email));
            parametros.Add(new SqlParameter("@observacoes", pessoa.Observacoes));
            ExecuteNonQuery(sql, parametros);
        }
        public void Alterar(Pessoa pessoa)
        {
            var sql = "update usuarios set Nome = @nome, CPF = @cpf, RG = @rg, TelefoneFixo = @telefoneFixo, TelefoneCelular = @telefoneCelular, Endereco = @endereco, Email = @email, Observacoes = @observacoes" +
                          "where  Id = @Id";
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nome", pessoa.Nome));
            parametros.Add(new SqlParameter("@cpf", pessoa.CPF));
            parametros.Add(new SqlParameter("@rg", pessoa.RG));
            parametros.Add(new SqlParameter("@telefoneFixo", pessoa.TelefoneFixo));
            parametros.Add(new SqlParameter("@telefoneCelular", pessoa.TelefoneCelular));
            parametros.Add(new SqlParameter("@endereco", pessoa.Endereco));
            parametros.Add(new SqlParameter("@email", pessoa.Email));
            parametros.Add(new SqlParameter("@observacoes", pessoa.Observacoes));
            ExecuteNonQuery(sql, parametros);
        }
        public void Excluir(int codigo)
        {
            var sql = "delete from usuarios where Id = @Id ";
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Id", codigo));
            ExecuteNonQuery(sql, parametros);
        }

        private Pessoa Mapear(SqlDataReader registro)
        {
            var pessoa = new Pessoa();
            pessoa.Id = Convert.ToInt32(registro["Id"]);
            pessoa.Nome = registro["Nome"].ToString();
            pessoa.CPF = Convert.ToInt32(registro["CPF"]);
            pessoa.RG = Convert.ToInt32(registro["RG"]);
            pessoa.TelefoneFixo = Convert.ToInt32(registro["TelefoneFixo"]);
            pessoa.TelefoneCelular = Convert.ToInt32(registro["TelefoneCelular"]);
            pessoa.Endereco = registro["Endereco"].ToString();
            pessoa.Email = registro["Email"].ToString();
            pessoa.Observacoes = registro["Observacoes"].ToString();
            return pessoa;
        }
        public Pessoa BuscaPorId(int id)
        {
            var sqlCommand = "select Id,Nome, CPF, RG, TelefoneFixo, TelefoneCelular, Endereco, Email, Observacoes from usuarios " +
                                        " where ClientesID = @ClientesID ";
            Pessoa _pessoa = null;
            using (var conexao = ConexaoDados)
            {
                conexao.Open();
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sqlCommand;
                    comando.Parameters.AddWithValue("@Id", id);
                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.HasRows)
                        {
                            _pessoa = new Pessoa();
                            while (registro.Read())
                            {
                                _pessoa.Id = Convert.ToInt32(registro["Id"]);
                                _pessoa.Nome = registro["Nome"].ToString();
                                _pessoa.CPF = Convert.ToInt32(registro["CPF"]);
                                _pessoa.RG = Convert.ToInt32(registro["RG"]);
                                _pessoa.TelefoneFixo = Convert.ToInt32(registro["TelefoneFixo"]);
                                _pessoa.TelefoneCelular = Convert.ToInt32(registro["TelefoneCelular"]);
                                _pessoa.Endereco = registro["Endereco"].ToString();
                                _pessoa.Email = registro["Email"].ToString();
                                _pessoa.Observacoes = registro["Observacoes"].ToString();
                            }
                        }
                    }
                }
            }
            return _pessoa;
        }
        public IList<Pessoa> ListarTodasPessoas()
        {
            var sqlCommand = "select Id,Nome, CPF, RG, TelefoneFixo, TelefoneCelular, Endereco, Email, Observacoes from usuarios";
            IList<Pessoa> _pessoa = null;
            using (var conexao = ConexaoDados)
            {
                conexao.Open();
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sqlCommand;
                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.HasRows)
                        {
                            _pessoa = new List<Pessoa>();
                            while (registro.Read())
                            {
                                _pessoa.Add(Mapear(registro));
                            }
                        }
                    }
                }
            }
            return _pessoa;
        }
    }
}