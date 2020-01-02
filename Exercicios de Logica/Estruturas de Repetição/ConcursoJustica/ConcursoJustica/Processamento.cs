using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcursoJustica
{
    public class Processamento
    {
        Candidato candidato { get; set; }

        public Processamento()
        {
            candidato = new Candidato();
        }
        public void Processar()
        {
            int resposta = 0;
            int homem = 0;
            int homemTerceiroGrau = 0;
            int homemSegundoGrau = 0;
            int mulher = 0;
            int mulherSegundoGrau = 0;
            int numerodeCandidatos = 0;
            int totalDeHomens = 0;
            double homensQueTemTerceiroGrau = 0;
            double porcentagemTerceiroGrau = 0;

            int s = 0;

            Console.WriteLine("Quantos candidatos você quer cadastrar? ");
            resposta = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o nome do candidato: ");
            candidato.Nome = Console.ReadLine();

            Console.WriteLine($"Entre com o sexo do candidato {candidato.Nome}: (M)Masculino (F)Feminino:");
            candidato.Sexo = Console.ReadLine();

            if (candidato.Sexo == "M" || candidato.Sexo == "m")
            {
                homem += 1;

                Console.WriteLine($"Entre com o grau de instrução do candidato {candidato.Nome}. (1)Segundo Grau Completo ou (2)Terceiro Grau Completo");
                candidato.GrauInstrucao = int.Parse(Console.ReadLine());

                if (candidato.GrauInstrucao == 1)
                {
                    homemSegundoGrau += 1;
                }
                if (candidato.GrauInstrucao == 2)
                {
                    homemTerceiroGrau += 1;
                }
                candidato.Dados(candidato);
            }

            if (candidato.Sexo == "F" || candidato.Sexo == "f")
            {
                mulher += 1;

                Console.WriteLine($"Entre com o grau de instrução do candidato {candidato.Nome}. (1)Segundo Grau Completo ou (2)Terceiro Grau Completo");
                candidato.GrauInstrucao = int.Parse(Console.ReadLine());

                if (candidato.GrauInstrucao == 1)
                {
                    mulherSegundoGrau += 1;
                }
                candidato.Dados(candidato);
            }

            s = 1;

            for (s = 2; s <= resposta; s++)
            {
                Console.WriteLine("Entre com o nome do candidato: ");
                candidato.Nome = Console.ReadLine();

                Console.WriteLine($"Entre com o sexo do candidato {candidato.Nome}: (M)Masculino (F)Feminino:");
                candidato.Sexo = Console.ReadLine();

                if (candidato.Sexo == "M" || candidato.Sexo == "m")
                {
                    homem += 1;

                    Console.WriteLine($"Entre com o grau de instrução do candidato {candidato.Nome}. (1)Segundo Grau Completo ou (2)Terceiro Grau Completo");
                    candidato.GrauInstrucao = int.Parse(Console.ReadLine());

                    if (candidato.GrauInstrucao == 1)
                    {
                        homemSegundoGrau += 1;
                    }
                    if (candidato.GrauInstrucao == 2)
                    {
                        homemTerceiroGrau += 1;
                    }
                    candidato.Dados(candidato);
                }

                if (candidato.Sexo == "F" || candidato.Sexo == "f")
                {
                    mulher += 1;

                    Console.WriteLine($"Entre com o grau de instrução do candidato {candidato.Nome}. (1)Segundo Grau Completo ou (2)Terceiro Grau Completo");
                    candidato.GrauInstrucao = int.Parse(Console.ReadLine());

                    if (candidato.GrauInstrucao == 1)
                    {
                        mulherSegundoGrau += 1;
                    }
                    candidato.Dados(candidato);
                }
            }
            numerodeCandidatos = homem + mulher;
            totalDeHomens = homemSegundoGrau + homemTerceiroGrau;
            homensQueTemTerceiroGrau = homemTerceiroGrau;
            porcentagemTerceiroGrau = (homensQueTemTerceiroGrau / totalDeHomens) * 100;

            Console.WriteLine($"\nNumero total de candidatos é {numerodeCandidatos}");
            Console.WriteLine($"O numero de candidatos do sexo masculino são {homem}");
            Console.WriteLine($"O numero de candidatas do sexo feminino são {mulher}");
            Console.WriteLine($"O numero de candidatas com apenas o segundo grau são {mulherSegundoGrau}");
            Console.WriteLine($"A porcentagem de homens com terceiro grau em ralação aos outros homens é de {porcentagemTerceiroGrau}%");
        }
    }
}
