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
            double maiorNota = 0;
            double menorNota = 0;
            double notaFinal = 0;
            int s = 0;

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

            disciplina.Dados(disciplina);

            notaFinal = (disciplina.Nota1 + disciplina.Nota2 + disciplina.Nota3) / 3;
            maiorNota = notaFinal;
            menorNota = notaFinal;

            s = 1;

            while (s < 3)
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

                disciplina.Dados(disciplina);

                notaFinal = (disciplina.Nota1 + disciplina.Nota2 + disciplina.Nota3) / 3;

                if (notaFinal < menorNota)
                {
                    menorNota = notaFinal;
                }
                else if(notaFinal > maiorNota)
                {   
                    maiorNota = notaFinal;
                }

                s++;
            }

            Console.WriteLine($"Maior Nota {maiorNota}, menor nota {menorNota}");
        }
    }
}
