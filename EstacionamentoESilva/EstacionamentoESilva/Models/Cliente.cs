using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
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
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string NomeCompleto { get { return string.Format("{0} {1}", Nome, Sobrenome); } }

        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}