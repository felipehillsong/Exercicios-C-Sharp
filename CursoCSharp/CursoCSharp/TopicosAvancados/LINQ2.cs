using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoCSharp.TopicosAvancados
{
    class LINQ2
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

            var felipe = alunos.Single(aluno => aluno.Nome.Equals("Felipe"));
            Console.WriteLine($"{felipe.Nome}{felipe.Nota}");
        }
    }
}
