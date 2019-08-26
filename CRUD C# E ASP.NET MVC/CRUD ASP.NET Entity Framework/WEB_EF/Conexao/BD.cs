using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WEB_EF.Models;

namespace WEB_EF.Conexao
{
    public class BD : DbContext
    {
        public BD() : base("conexaoBD")
        {

        }

        public DbSet<Usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Usuarios>().Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Usuarios>().Property(x => x.Cargo).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Usuarios>().Property(x => x.Data).IsRequired().HasColumnType("date");
        }

    }
}