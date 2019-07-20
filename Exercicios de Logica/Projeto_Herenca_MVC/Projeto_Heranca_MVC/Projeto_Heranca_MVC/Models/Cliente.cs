using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Heranca_MVC.Models.Cliente
{
    public abstract class Cliente
    {
        protected string Nome { get; set; }

        protected double CPF { get; set; }

        public abstract void PegarNome(string nome);

        public abstract void PegarCPF(double cpf);
    }
}