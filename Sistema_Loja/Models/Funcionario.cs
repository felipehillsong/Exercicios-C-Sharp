using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_Loja.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Display(Name ="Nome")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [StringLength(30, ErrorMessage = "Limite de 30 caracteres")]
        public string Nome { get; set; }       
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [StringLength(30, ErrorMessage = "Limite de 30 caracteres")]
        public string Sobrenome { get; set; }       
        [Display(Name = "Salario")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Salario { get; set; }
        [Display(Name = "Comissão")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float Comissao { get; set; }
        [Display(Name = "Data de Nascimento")]        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]        
        public DateTime Nascimento { get; set; }
        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Cadastro { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [NotMapped]
        public int Idade { get { return DateTime.Now.Year - Nascimento.Year; } }        
        [Required(ErrorMessage = "Você precisa entrar com {0}")]
        public int TipoDocumentoId { get; set; }


        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}