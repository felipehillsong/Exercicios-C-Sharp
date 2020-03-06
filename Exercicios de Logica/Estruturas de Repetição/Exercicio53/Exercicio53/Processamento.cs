using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio53
{
    public class Processamento
    {
        public Disciplina disciplina { get; set; }        

        public Processamento()
        {
            disciplina = new Disciplina();
        }

        public void Processar()
        {
            int resposta = 0;
            double maiorNota = 0;
            double menorNota = 0;
            double notaFinal = 0;
            int s = 0;

            Console.WriteLine("Quantos alunos deseja cadastrar as notas?");
            resposta = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a matricula do aluno: ");
            disciplina.Matricula = long.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a primeira nota do aluno: ");
            disciplina.Nota1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a segunda nota do aluno: ");
            disciplina.Nota2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a terceira nota do aluno: ");
            disciplina.Nota3 = double.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a frequencia do aluno: ");
            disciplina.Frequencia = int.Parse(Console.ReadLine());

            disciplina.Dados(disciplina, resposta);

            notaFinal = (disciplina.Nota1 + disciplina.Nota2 + disciplina.Nota3) / 3;
            maiorNota = notaFinal;
            menorNota = notaFinal;

            s = 1;

            while (s < resposta)
            {
                Console.WriteLine("Entre com a matricula do aluno: ");
                disciplina.Matricula = long.Parse(Console.ReadLine());

                Console.WriteLine("Entre com a primeira nota do aluno: ");
                disciplina.Nota1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Entre com a segunda nota do aluno: ");
                disciplina.Nota2 = double.Parse(Console.ReadLine());

                Console.WriteLine("Entre com a terceira nota do aluno: ");
                disciplina.Nota3 = double.Parse(Console.ReadLine());

                Console.WriteLine("Entre com a frequencia do aluno: ");
                disciplina.Frequencia = int.Parse(Console.ReadLine());

                disciplina.Dados(disciplina, resposta);

                notaFinal = (disciplina.Nota1 + disciplina.Nota2 + disciplina.Nota3) / 3;

                if (notaFinal < menorNota)
                {
                    menorNota = notaFinal;
                }
                else if (notaFinal > maiorNota)
                {
                    maiorNota = notaFinal;
                }

                s++;
            }

            Console.WriteLine($"Maior Nota {maiorNota}, menor nota {menorNota}");
            Console.WriteLine($"Reprovados {disciplina.TotalReprovados}");
            Console.WriteLine($"Media de nota da turma é {disciplina.NotaMediaTurma}");
            Console.WriteLine($"Porcentagem de reprovados por frequencia entre o total de reprovados é {disciplina.PorcentagemReprovadosFrequencia}");
        }
    }
}