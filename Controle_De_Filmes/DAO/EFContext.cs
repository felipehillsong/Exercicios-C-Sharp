using Controle_De_Filmes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Controle_De_Filmes.DAO
{
    public class EFContext : DbContext
    {
        public EFContext() : base("BDConexao")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //DIZ QUAIS SERAO AS ENTIDADES NO BANCO DE DADOS
        public DbSet<Filmes> Filmes{ get; set; }
    }
}