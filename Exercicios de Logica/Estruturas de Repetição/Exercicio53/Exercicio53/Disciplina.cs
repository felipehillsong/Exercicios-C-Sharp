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

        public double NotaFinal { get; set; }

        public int Frequencia { get; set; }        

        public void Dados(Disciplina disciplina)
        {
            disciplina.NotaFinal = (disciplina.Nota1 + disciplina.Nota2 + disciplina.Nota3) / 3;            

            if (disciplina.NotaFinal >= 60 && disciplina.Frequencia >= 40)
            {
                Console.WriteLine($"O aluno com matricula {disciplina.Matricula} obteve as notas {disciplina.Nota1}, {disciplina.Nota2} e {disciplina.Nota3}, e oteve a média { disciplina.NotaFinal}. E sua frequencia foi de {disciplina.Frequencia}. Seu status é Aprovado");
            }
            else if(disciplina.NotaFinal < 60 || disciplina.Frequencia < 40)
            {
                Console.WriteLine($"O aluno com matricula {disciplina.Matricula} obteve as notas {disciplina.Nota1}, {disciplina.Nota2} e {disciplina.Nota3}, e oteve a média { disciplina.NotaFinal}. E sua frequencia foi de {disciplina.Frequencia}. Seu status é Reprovado");
            }
        }
    }
}
