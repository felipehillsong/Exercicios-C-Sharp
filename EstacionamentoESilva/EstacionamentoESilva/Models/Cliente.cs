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

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public long CPF { get; set; }

        public string Endereco { get; set; }

        public long Telefone { get; set; }

        public string Email { get; set; }

        public string NomeCompleto { get { return string.Format("{0} {1}", Nome, Sobrenome); } }

        public virtual ICollection<Servico> Servico { get; set; }

        public virtual ICollection<Veiculo> Veiculo { get; set; }

    }
}