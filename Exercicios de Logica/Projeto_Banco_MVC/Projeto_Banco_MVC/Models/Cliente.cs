using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_MVC.Models
{
    public abstract class Cliente
    {
        protected string Nome { get; set; }

        protected double CPF { get; set; }

        public abstract string PegarNome(string nome);

        public abstract double PegarCPF(double cpf);
    }
}