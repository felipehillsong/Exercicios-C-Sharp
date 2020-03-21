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

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public long CPF { get; set; }

        public string Endereco { get; set; }

        public long Telefone { get; set; }

        public string Email { get; set; }
    }
}