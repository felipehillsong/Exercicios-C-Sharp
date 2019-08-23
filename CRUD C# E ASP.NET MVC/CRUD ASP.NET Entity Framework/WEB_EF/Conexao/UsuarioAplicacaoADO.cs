using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEB_EF.Models;

namespace WEB_EF.Conexao
{
    public class UsuarioAplicacaoADO : IRepositorio<Usuarios>
    {
        private BD bd;

        private void Insert(Usuarios usuarios)
        {
            var exeQuery = "";
            exeQuery += "INSERT INTO usuarios(nome, cargo, data)";
            exeQuery += string.Format(" VALUES('{0}','{1}','{2}')", usuarios.Nome, usuarios.Cargo, usuarios.Data);
            using (bd = new BD())
            {
                bd.ExecutarComandoSemRetorno(exeQuery);
            }
        }

        private void Update(Usuarios usuarios)
        {
            var exeQuery = "";
            exeQuery += "UPDATE usuarios SET ";
            exeQuery += string.Format("nome = '{0}',", usuarios.Nome);
            exeQuery += string.Format("cargo = '{0}',", usuarios.Cargo);
            exeQuery += string.Format("data = '{0}'", usuarios.Data);
            exeQuery += string.Format("WHERE id = {0}", usuarios.Id);
            using (bd = new BD())
            {
                bd.ExecutarComandoSemRetorno(exeQuery);
            }
        }

        public void Delete(Usuarios usuarios)
        {
            using (bd = new BD())
            {
                var exeQuery = string.Format("DELETE FROM usuarios WHERE id = {0}", usuarios.Id);
                bd.ExecutarComandoSemRetorno(exeQuery);
            }
        }

        //metodo Salvar sera chamado para inserir ou deletar
        public void Salvar(Usuarios usuarios)
        {
            if (usuarios.Id > 0)
            {
                Update(usuarios);
            }
            else
            {
                Insert(usuarios);
            }
        }

        public IEnumerable<Usuarios> Select()
        {
            using (bd = new BD())
            {
                var exeQuery = "SELECT * FROM usuarios";
                var retorno = bd.ExecutaComandoComRetorno(exeQuery);
                return LerDadosDoBanco(retorno);
            }

        }

        public Usuarios SelectById(string id)
        {
            using (bd = new BD())
            {
                var exeQuery = string.Format("SELECT * FROM usuarios WHERE id = {0}", id);
                var retorno = bd.ExecutaComandoComRetorno(exeQuery);
                return LerDadosDoBanco(retorno).FirstOrDefault();
            }

        }

        private List<Usuarios> LerDadosDoBanco(SqlDataReader reader)
        {
            var usuarios = new List<Usuarios>();
            while (reader.Read())
            {
                var dados = new Usuarios()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Cargo = reader["cargo"].ToString(),
                    Data = DateTime.Parse(reader["data"].ToString())
                };

                usuarios.Add(dados);
            }

            reader.Close();
            return usuarios;
        }
    }
}