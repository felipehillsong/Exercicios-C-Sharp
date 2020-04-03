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
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
        [Display(Name = "CPF")]
        public long CPF { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Telefone")]
        public long Telefone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string NomeCompleto { get { return string.Format("{0} {1}", Nome, Sobrenome); } }

        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}