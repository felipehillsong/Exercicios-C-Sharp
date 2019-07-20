using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Heranca_MVC.Models.Cliente
{
    public class ClienteFisico : Cliente
    {
        public override void PegarNome(string nome)
        {
            this.Nome = nome;
            Console.WriteLine("Cliente: " + this.Nome);
        }

        public override void PegarCPF(double cpf)
        {
            this.CPF = cpf;
            Console.WriteLine("CPF do cliete é: " + this.CPF);
        }
    }
}