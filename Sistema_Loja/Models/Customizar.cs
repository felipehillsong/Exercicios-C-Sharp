using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Loja.Models
{
    public class Customizar
    {
        [Key]
        public int CustomizarId { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        public string Sobrenome { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Documento")]
        public string Documento { get; set; }
        public int TipoDocumentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}