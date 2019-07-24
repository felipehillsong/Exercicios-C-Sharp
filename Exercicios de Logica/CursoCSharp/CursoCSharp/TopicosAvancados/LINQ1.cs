using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoCSharp.TopicosAvancados
{
    public class Aluno
    {
        public string Nome;
        public int Idade;
        public double Nota;
    }    


    class LINQ1
    {
        public static void Executar()
        {
            var alunos = new List<Aluno>
            {
                new Aluno()
                {
                    Nome = "Felipe", Idade = 31, Nota = 8.0

                },

                new Aluno()
                {
                    Nome = "Polyana", Idade = 30, Nota = 9.2
                },

                new Aluno()
                {
                    Nome = "Aline", Idade = 25, Nota = 6.2
                },

                new Aluno()
                {
                    Nome = "Roberta", Idade = 28, Nota = 4.5
                },

                new Aluno()
                {
                    Nome = "Eny", Idade = 56, Nota = 9.9
                },

                new Aluno()
                {
                    Nome = "Julio", Idade = 56, Nota = 8.7
                },

                new Aluno()
                {
                    Nome = "Jorge", Idade = 47, Nota = 5.2
                },

                new Aluno()
                {
                    Nome = "Roberta", Idade = 36, Nota = 6.8
                }
            };

            Console.WriteLine("== Aprovados ===============");
            var aprovados = alunos.Where(a => a.Nota >= 6).OrderBy(a => a.Nome);
            foreach(var aluno in aprovados)
            {
                Console.WriteLine(aluno.Nome);
            }

            Console.WriteLine("\n== Chamada =============");
            var chamada = alunos.OrderBy(a => a.Nome).Select(a => a.Nome);
            foreach(var aluno in chamada)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine("\n== Aprovados por Idade ================");
            var alunosAprovados = from aluno in alunos where aluno.Nota >= 7 orderby aluno.Idade select aluno.Nome;
            foreach (var aluno in alunosAprovados)
            {
                Console.WriteLine(aluno);
            }
            
        }
    }
}
