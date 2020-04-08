using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Data
{
    public class EstacionamentoESilvaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EstacionamentoESilvaContext() : base("name=EstacionamentoESilvaContext")
        {
        }

        public System.Data.Entity.DbSet<EstacionamentoESilva.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<EstacionamentoESilva.Models.Veiculo> Veiculoes { get; set; }

        public System.Data.Entity.DbSet<EstacionamentoESilva.Models.Servico> Servico { get; set; }

        public System.Data.Entity.DbSet<EstacionamentoESilva.Models.Funcionario> Funcionarios { get; set; }
    }
}
