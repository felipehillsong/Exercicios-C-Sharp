using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesquisaProduto
{
    public class Processamento
    {
        public void Processar()
        {
            int r = 0;
            string nome;
            int idade;
            int sexo;
            int respostaSim = 0;
            int respostaSimFinal = 0;
            int respostaNao = 0;
            int respostaNaoFinal = 0;
            int resposta;       

            Pessoa pessoa = new Pessoa();        

            while(r < 3) 
            {     
                Console.WriteLine("Entre com o nome da pessoa: ");
                nome = Console.ReadLine();

                Console.WriteLine("Entre com a idade da pessoa " + nome);
                idade = int.Parse(Console.ReadLine());

                Console.WriteLine("Entre com o sexo da pessoa " + nome);
                sexo = int.Parse(Console.ReadLine());

                if (sexo == 1)
                {
                    Console.WriteLine("Entre com a resposta da pessoa " + nome + " (1)SIM ou (2)NÃO: ");
                    resposta = int.Parse(Console.ReadLine());
                    if(resposta == 1)
                    {
                        respostaSim = resposta;
                        respostaSimFinal += 1;
                        pessoa.Dados(nome, idade, sexo, respostaSim);
                    }
                    if (resposta == 2)
                    {
                        respostaNao = resposta;
                        respostaNaoFinal += 1;
                        pessoa.Dados(nome, idade, sexo, respostaNao);
                    }
                }

                if (sexo == 2)
                {
                    Console.WriteLine("Entre com a resposta da pessoa " + nome + " (1)SIM ou (2)NÃO: ");
                    resposta = int.Parse(Console.ReadLine());
                    if (resposta == 1)
                    {
                        respostaSim = resposta;
                        respostaSimFinal += 1;
                        pessoa.Dados(nome, idade, sexo, respostaSim);
                    }
                    if (resposta == 2)
                    {
                        respostaNao = resposta;
                        respostaNaoFinal += 1;
                        pessoa.Dados(nome, idade, sexo, respostaNao);
                    }
                }
                r++;
            }

            Console.WriteLine(respostaSimFinal);
            Console.WriteLine(respostaNaoFinal);
        }
    }
}
