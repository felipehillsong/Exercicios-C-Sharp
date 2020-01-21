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
        [Display(Name = "Tipo do Documento")]
        public int TipoDocumentoId { get; set; }
        
        [Display(Name = "Tipo do Documento")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        public string Descricao { get; set; }


        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<Customizar> Customizar { get; set; }
    }
}