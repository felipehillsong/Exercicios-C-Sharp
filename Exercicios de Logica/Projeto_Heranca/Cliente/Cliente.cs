using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Heranca
{
    public abstract class Cliente
    {
        protected string Nome { get; set; }

        protected float CPF { get; set; }

        public abstract void PegarNome(string nome);

        public abstract void PegarCPF(float cpf);
    }
}
