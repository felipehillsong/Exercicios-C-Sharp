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
            int respostaNaoFinal = 0;            
            int respostaNao = 0;
            int resposta;
            int numeroDeMulherNao = 0;
            int numeroDeMulherSim = 0;
            int totalDeMulheres = 0;
            double porcentagemMulheresSim = 0;      
            double numerosRespostasSimMulheres = 0;
            Pessoa pessoa = new Pessoa();        

            while(r < 2000) 
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
                        numeroDeMulherSim += 1;
                        pessoa.Dados(nome, idade, sexo, respostaSim);
                    }
                    if (resposta == 2)
                    {
                        respostaNao = resposta;
                        respostaNaoFinal += 1;
                        numeroDeMulherNao += 1;
                        pessoa.Dados(nome, idade, sexo, respostaNao);
                    }
                }
                r++;
            }           
            //TOTAL DE VOTOS DAS MULHERES
            totalDeMulheres = numeroDeMulherSim + numeroDeMulherNao;
            //SEPARA O VOTO SIM DAS MULHERES DOS DEMAIS VOTOS DAS MULHERES
            numerosRespostasSimMulheres = numeroDeMulherSim;
            //FAZ O CALCULO DE PORCENTAGEM
            porcentagemMulheresSim = (numerosRespostasSimMulheres / totalDeMulheres) * 100;


            Console.WriteLine("O numero de pessoas que responderam sim foram de: "+ respostaSimFinal);
            Console.WriteLine("O numero de pessoas que responderam não foram de: "+ respostaNaoFinal);
            Console.WriteLine("O numero total de mulheres entrevistadas foram de: "+totalDeMulheres);
            Console.WriteLine("A porcentagem de mulheres que votaram sim em relação ao total de mulheres foram de: "+ porcentagemMulheresSim);
        }
    }
}
