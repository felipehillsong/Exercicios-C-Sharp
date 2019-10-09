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
            int respostaSimFinalHomem = 0;
            int respostaNaoFinalHomem = 0;
            int respostaSimFinalMulher = 0;
            int respostaNaoFinalMulher = 0;
            int respostaNao = 0;
            int resposta;
            int numeroDeMulherNao = 0;
            int numeroDeMulherSim = 0;
            int totalDeMulheres = 0;
            double porcentagemMulheresSim = 0;
            int numeroDeHomemSim = 0;
            int numeroDeHomemNao = 0;
            double numerosRespostasSimMulheres = 0;
            int totalDeVotosSim = 0;
            int totalDeVotosNao = 0;

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
                        respostaSimFinalHomem += 1;
                        numeroDeHomemSim += 1;
                        pessoa.Dados(nome, idade, sexo, respostaSim);
                    }
                    if (resposta == 2)
                    {
                        respostaNao = resposta;
                        respostaNaoFinalHomem += 1;
                        numeroDeHomemNao += 1;
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
                        respostaSimFinalMulher += 1;
                        numeroDeMulherSim += 1;
                        pessoa.Dados(nome, idade, sexo, respostaSim);
                    }
                    if (resposta == 2)
                    {
                        respostaNao = resposta;
                        respostaNaoFinalMulher += 1;
                        numeroDeMulherNao += 1;
                        pessoa.Dados(nome, idade, sexo, respostaNao);
                    }
                }
                r++;
            }

            totalDeVotosSim = respostaSimFinalHomem + respostaSimFinalMulher;
            totalDeVotosNao = respostaNaoFinalHomem + respostaNaoFinalMulher;

            totalDeMulheres = numeroDeMulherSim + numeroDeMulherNao;
            numerosRespostasSimMulheres = numeroDeMulherSim;
            porcentagemMulheresSim = (numerosRespostasSimMulheres / totalDeMulheres) * 100;


            Console.WriteLine("O numero de pessoas que responderam sim foram de: "+totalDeVotosSim);
            Console.WriteLine("O numero de pessoas que responderam nãp foram de: "+totalDeVotosNao);
            Console.WriteLine("O numero total de mulheres entrevistadas foram de: "+totalDeMulheres);
            Console.WriteLine("A porcentagem de mulheres que votaram sim em relação ao total de mulheres foram de: "+ porcentagemMulheresSim);
        }
    }
}
