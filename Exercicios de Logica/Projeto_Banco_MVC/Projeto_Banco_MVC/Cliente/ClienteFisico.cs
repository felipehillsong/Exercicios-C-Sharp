using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_MVC.Models
{
    public class ClienteFisico : Cliente
    {
        public override string PegarNome(string nome)
        {
            return Nome = nome;
        }

        public override double PegarCPF(double cpf)
        {
            return CPF = cpf;
        }
    }
}