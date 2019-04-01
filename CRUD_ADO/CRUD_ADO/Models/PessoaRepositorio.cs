using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace CRUD_ADO.Models {
    public class PessoaRepositorio : Repositorio<Pessoa, int> {
        ///<summary>Faz a exclusão
        ///<param name="entity">Referência de Pessoa que será excluída.</param>
        ///</summary>
        public override void Delete(Pessoa entity) {           
            using (var conn = new SqlConnection(StringConnection)) {
                string sql = "DELETE usuarios Where usuarioId=@usuarioId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@usuarioId", entity.Id);
                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        ///<summary>Exibe uma pessoa pelo ID
        ///<param name="id">Id do registro que será excluído.</param>
        ///</summary>
        public override Pessoa DeleteById(int id) {
            using (var conn = new SqlConnection(StringConnection)) {
                string sql = "Select usuarioId, Nome, Cargo, Data FROM usuarios WHERE usuarioId=@usuarioId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@usuarioId", id);
                Pessoa p = null;
                try {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                        if (reader.HasRows) {
                            if (reader.Read()) {
                                p = new Pessoa();
                                p.Id = (int)reader["usuarioId"];
                                p.Nome = reader["nome"].ToString();
                                p.Cargo = reader["cargo"].ToString();
                                p.Data = DateTime.Parse(reader["data"].ToString());

                            }
                        }
                    }
                } catch (Exception e) {
                    throw e;
                }
                return p;
            }
        }

        ///<summary>Obtém todas as pessoas
        ///<returns>Retorna as pessoas cadastradas.</returns>
        ///</summary>
        public override List<Pessoa> GetAll() {
            string sql = "Select UsuarioId, Nome, Cargo, Data FROM usuarios";
            using (var conn = new SqlConnection(StringConnection)) {
                var cmd = new SqlCommand(sql, conn);
                List<Pessoa> list = new List<Pessoa>();
                Pessoa p = null;
                try {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                        while (reader.Read()) {
                            p = new Pessoa();
                            p.Id = (int)reader["usuarioId"];
                            p.Nome = reader["Nome"].ToString();
                            p.Cargo = reader["Cargo"].ToString();
                            p.Data = DateTime.Parse(reader["data"].ToString());
                            

                            list.Add(p);
                        }
                    }
                } catch (Exception e) {
                    throw e;
                }
                return list;
            }
        }

        ///<summary>Obtém uma pessoa pelo ID
        ///<param name="id">Id do registro que obtido.</param>
        ///<returns>Retorna uma referência de Pessoa do registro encontrado ou null se ele não for encontrado.</returns>
        ///</summary>
        public override Pessoa GetById(int id) {
            using (var conn = new SqlConnection(StringConnection)) {
                string sql = "Select usuarioId, Nome, Cargo, Data FROM usuarios WHERE usuarioId=@usuarioId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@usuarioId", id);
                Pessoa p = null;
                try {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                        if (reader.HasRows) {
                            if (reader.Read()) {
                                p = new Pessoa();
                                p.Id = (int)reader["usuarioId"];
                                p.Nome = reader["nome"].ToString();
                                p.Cargo = reader["cargo"].ToString();
                                p.Data = DateTime.Parse(reader["data"].ToString());

                            }
                        }
                    }
                } catch (Exception e) {
                    throw e;
                }
                return p;
            }
        }

        public override Pessoa DetailsById(int id) {
            using (var conn = new SqlConnection(StringConnection)) {
                string sql = "Select usuarioId, Nome, Cargo, Data FROM usuarios WHERE usuarioId=@usuarioId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@usuarioId", id);
                Pessoa p = null;
                try {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                        if (reader.HasRows) {
                            if (reader.Read()) {
                                p = new Pessoa();
                                p.Id = (int)reader["usuarioId"];
                                p.Nome = reader["nome"].ToString();
                                p.Cargo = reader["cargo"].ToString();
                                p.Data = DateTime.Parse(reader["data"].ToString());

                            }
                        }
                    }
                } catch (Exception e) {
                    throw e;
                }
                return p;
            }
        }
        ///<summary>Salva a pessoa no banco
        ///<param name="entity">Referência de Pessoa que será salva.</param>
        ///</summary>
        public override void Save(Pessoa entity) {
            using (var conn = new SqlConnection(StringConnection)) {
                string sql = "INSERT INTO usuarios (nome, cargo, data) VALUES (@nome, @cargo, @data)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", entity.Nome);
                cmd.Parameters.AddWithValue("@cargo", entity.Cargo);
                cmd.Parameters.AddWithValue("@data", entity.Data).ToString();
                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                } catch (Exception e) {
                    throw e;
                }
            }
        }

        ///<summary>Atualiza a pessoa no banco
        ///<param name="entity">Referência de Pessoa que será atualizada.</param>
        ///</summary>
        public override void Update(Pessoa entity) {
            using (var conn = new SqlConnection(StringConnection)) {
                string sql = "UPDATE usuarios SET Nome=@Nome, Cargo=@Cargo, Data=@Data Where usuarioId=@usuarioId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@usuarioId", entity.Id);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Cargo", entity.Cargo);
                cmd.Parameters.AddWithValue("@Data", entity.Data);

                try {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                } catch (Exception e) {
                    throw e;
                }
            }
        }
    }
}