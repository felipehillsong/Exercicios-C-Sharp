using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEB_ADO.Models;

namespace WEB_ADO.Conexao
{
    public class UsuarioAplicacao
    {
        public IRepositorio<Usuarios> comando { get; private set; }

        public UsuarioAplicacao(IRepositorio<Usuarios> repo)
        {
            comando = repo;
        }

        public void Delete(Usuarios usuarios)
        {
            comando.Delete(usuarios);
        }
       
        public void Salvar(Usuarios usuarios)
        {
            comando.Salvar(usuarios);
        }

        public IEnumerable<Usuarios> Select()
        {
            return comando.Select();

        }

        public Usuarios SelectById(string id)
        {
            return comando.SelectById(id);

        }
        
    }
}