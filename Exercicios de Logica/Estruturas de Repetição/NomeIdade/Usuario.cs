using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomeIdade
{
    public class Usuario
    {
        private string Nome { get; set; }

        private int Idade { get; set; }

        public void Dados(string nome, int idade)
        {
            this.Nome += nome;
            this.Idade += idade;

            if (Idade >= 21)
            {
                Console.WriteLine(Nome+" É maior de idade");
            }
        }
        
    }
}
