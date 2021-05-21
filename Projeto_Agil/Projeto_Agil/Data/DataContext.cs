using Microsoft.EntityFrameworkCore;
using Projeto_Agil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Agil.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
         public DbSet<Evento>Eventos { get; set; }
    }
}
