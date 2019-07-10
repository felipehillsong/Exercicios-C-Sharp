using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Heranca
{
    class ClienteJuridico:Cliente
    {
        public override void PegarNome(string nome)
        {
            this.Nome = nome;
        }

        public override void PegarCPF(float cpf)
        {
            this.CPF = cpf;
        }
    }
}
