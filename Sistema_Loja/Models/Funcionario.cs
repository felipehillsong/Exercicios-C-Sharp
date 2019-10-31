using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Loja.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Display(Name ="Primeiro nome")]
        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
        [Display(Name = "Salario")]
        public decimal Salario { get; set; }
        [Display(Name = "Comissão")]
        public float Comissao { get; set; }
        [Display(Name = "Nascimento")]
        public DateTime Nascimento { get; set; }
        [Display(Name = "Cadastro")]
        public DateTime Cadastro { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Primeiro nome")]
        public int TipoDocumentoId { get; set; }


        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}