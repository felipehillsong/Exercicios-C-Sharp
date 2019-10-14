using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Loja.Models
{
    public class TipoDocumento
    {
        [Key]
        public int TipoDocumentoId { get; set; }

        public string Descricao { get; set; }


        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}