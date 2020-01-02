using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcursoJustica
{
    class Program
    {
        static void Main(string[] args)
        {
            /*49. Em um concurso para auxiliar de justiça foram recebidas inscrições de candidatos de
            ambos os sexos e a partir do segundo grau completo. Sabendo que cada candidato
            preencheu uma ficha que contém o seu GRAU DE INSTRUÇÃO (1 = segundo
            grau, 2 = terceiro grau) seu NOME e SEXO (F = feminino, M = masculino),
            construa um algoritmo que calcule e imprima:
            a) O total de candidatos.
            b) O número de candidatos do sexo masculino e do sexo feminino.
            c) O número de mulheres com apenas o segundo grau.
            77
            d) A porcentagem de homens com terceiro grau em relação ao total de homens
            inscritos.
            */
            var processamento = new Processamento();
            processamento.Processar();
        }
    }
}