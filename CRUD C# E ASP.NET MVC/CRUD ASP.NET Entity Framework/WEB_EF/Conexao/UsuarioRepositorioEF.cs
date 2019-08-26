using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_EF.Models;

namespace WEB_EF.Conexao
{
    public class UsuarioRepositorioEF : IRepositorio<Usuarios>
    {
        public BD bd { get; private set; }

        public UsuarioRepositorioEF()
        {
            bd = new BD();
        }

        public void Delete(Usuarios entidade)
        {
            var usuarioExcluir = bd.usuarios.First(x => x.Id == entidade.Id);
            bd.Set<Usuarios>().Remove(usuarioExcluir);
            bd.SaveChanges();
        }

        public void Salvar(Usuarios entidade)
        {
            if (entidade.Id > 0)
            {
                var usuarioAlterar = bd.usuarios.First(x => x.Id == entidade.Id);
                usuarioAlterar.Nome = entidade.Nome;
                usuarioAlterar.Cargo = entidade.Cargo;
                usuarioAlterar.Data = entidade.Data;
            }
            else
            {
                bd.usuarios.Add(entidade);
            }
            bd.SaveChanges();
        }

        public IEnumerable<Usuarios> Select()
        {
            return bd.usuarios;
        }

        public Usuarios SelectById(int id)
        {            
            return bd.usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}