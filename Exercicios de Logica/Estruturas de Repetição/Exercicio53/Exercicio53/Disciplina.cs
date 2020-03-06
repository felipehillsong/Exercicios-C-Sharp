using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio53
{
    public class Disciplina
    {
        public long Matricula { get; set; }

        public double Nota1 { get; set; }

        public double Nota2 { get; set; }

        public double Nota3 { get; set; }

        private double NotaFinal { get; set; }

        public int Frequencia { get; set; }

        private int ReprovadosNota { get; set; }

        private int ReprovadosFrequncia { get; set; }

        private double ReprovadosPorFrequencia { get; set; }

        public int TotalReprovados { get; set; }

        public double PorcentagemReprovadosFrequencia { get; set; }

        public double NotaMediaTurma { get; set; }

        private double SomaNotas { get; set; }

        public void Dados(Disciplina disciplina, int resposta)
        {
            this.NotaFinal = (disciplina.Nota1 + disciplina.Nota2 + disciplina.Nota3) / 3;
            this.SomaNotas += this.NotaFinal;

            if (NotaFinal >= 60 && disciplina.Frequencia >= 40)
            {
                Console.WriteLine($"O aluno com matricula {disciplina.Matricula} obteve as notas {disciplina.Nota1}, {disciplina.Nota2} e {disciplina.Nota3}, e oteve a média { NotaFinal}. E sua frequencia foi de {disciplina.Frequencia}. Seu status é Aprovado");
            }
            else if (NotaFinal < 60 || disciplina.Frequencia < 40)
            {
                if(disciplina.Frequencia < 40)
                {
                    ReprovadosFrequncia += 1;

                }
                else if(NotaFinal < 60)
                {
                    ReprovadosNota += 1;
                }
                
                Console.WriteLine($"O aluno com matricula {disciplina.Matricula} obteve as notas {disciplina.Nota1}, {disciplina.Nota2} e {disciplina.Nota3}, e oteve a média {NotaFinal}. E sua frequencia foi de {disciplina.Frequencia}. Seu status é Reprovado");
            }

            NotaMediaTurma = SomaNotas / resposta;
            TotalReprovados = ReprovadosFrequncia + ReprovadosNota;
            ReprovadosPorFrequencia = ReprovadosFrequncia;
            PorcentagemReprovadosFrequencia = (ReprovadosPorFrequencia / TotalReprovados) * 100;
        }
    }
}
