using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exemplo_Razor.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Informe o email do usuario")]
        [Display(ShortName = "Qual o login?")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário")]
        [Display(ShortName = "Qual a senha?")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe a idade do usuário")]
        [Display(ShortName = "Qual a idade?")]
        public int Idade { get; set; }
    }
}