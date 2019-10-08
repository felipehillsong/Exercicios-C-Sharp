using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesquisaProduto
{
    public class Pessoa
    {
        private string Nome { get; set; }

        private int Idade { get; set; }

        private string Sexo { get; set; }

        private string Resposta { get; set; }

        public void Dados(string nome, int idade, int sexo, int resposta)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Sexo = sexo.ToString();
            this.Resposta = resposta.ToString();
        }
    }
}
