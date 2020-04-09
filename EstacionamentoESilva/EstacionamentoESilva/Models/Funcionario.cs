using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Required(ErrorMessage = "Nome Obrigatorio!", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Sobrenome Obrigatorio!", AllowEmptyStrings = false)]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "CPF Obrigatorio!", AllowEmptyStrings = false)]
        [Display(Name = "CPF")]
        public long CPF { get; set; }
        [Required(ErrorMessage = "Endereço Obrigatorio!", AllowEmptyStrings = false)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Telefone Obrigatorio!", AllowEmptyStrings = false)]
        [Display(Name = "Telefone")]
        public long Telefone { get; set; }
        [Required(ErrorMessage = "Email Obrigatorio!", AllowEmptyStrings = false)] 
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha Obrigatoria!", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}