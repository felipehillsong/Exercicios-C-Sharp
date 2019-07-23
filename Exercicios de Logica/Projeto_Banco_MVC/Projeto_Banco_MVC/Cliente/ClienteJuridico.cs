using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_MVC.Models
{
    public class ClienteJuridico : Cliente
    {
        public override string PegarNome(string nome)
        {
            return this.Nome = nome;
        }

        public override double PegarCPF(double cpf)
        {
            return this.CPF = cpf;
        }
    }
}