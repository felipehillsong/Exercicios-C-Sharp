using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit.Sdk;

namespace Projeto_Banco_MVC.Models
{
    public abstract class Cliente
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        protected string Nome { get; set; }

        protected double CPF { get; set; }

        public abstract string PegarNome(string nome);

        public abstract double PegarCPF(double cpf);
    }
}