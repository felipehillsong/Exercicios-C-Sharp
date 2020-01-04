using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Sistema_Loja.Models
{
    public class Sistema_LojaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Sistema_LojaContext() : base("name=Sistema_LojaContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<Sistema_Loja.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<Sistema_Loja.Models.TipoDocumento> TipoDocumentoes { get; set; }

        public System.Data.Entity.DbSet<Sistema_Loja.Models.Funcionario> Funcionarios { get; set; }

        public System.Data.Entity.DbSet<Sistema_Loja.Models.Fornecedor> Fornecedor { get; set; }

        public System.Data.Entity.DbSet<Sistema_Loja.Models.Customizar> Customizars { get; set; }
    }
}
