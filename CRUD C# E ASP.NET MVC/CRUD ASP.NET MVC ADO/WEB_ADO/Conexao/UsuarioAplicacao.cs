using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WEB_ADO.Models;

namespace WEB_ADO.Conexao
{
    class UsuarioAplicacao
    {
        public UsuarioAplicacaoADO comando { get; private set; }

        public UsuarioAplicacao()
        {
            comando = new UsuarioAplicacaoADO();
        }

        public void Delete(int id)
        {
            comando.Delete(id);
        }
       
        public void Salvar(Usuarios usuarios)
        {
            comando.Salvar(usuarios);
        }

        public List<Usuarios> Select()
        {
            return comando.Select();

        }

        public Usuarios SelectById(int id)
        {
            return comando.SelectById(id);

        }
        
    }
}