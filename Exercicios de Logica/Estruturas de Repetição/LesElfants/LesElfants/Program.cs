using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesElfants
{
    class Program
    {
        static void Main(string[] args)
        {
            /*40. Escreva um algoritmo que leia o NOME, a MODALIDADE ESPORTIVA (1 =
            Voley, 2 = Basquete, 3 = Futsal), a IDADE e o SEXO (M ou F) de 10 atletas do
            clube "LES ENFANTS". Calcular e imprimir:
            • Média de idade dos homens.
            • Média de idade das mulheres.
            • Porcentagem de mulheres matriculadas no basquete, em relação ao número de
            mulheres matriculadas.
            • Número de homens com idade entre 25 e 30 anos. */
            Processamento processamento = new Processamento();
            processamento.Processar();
        }
    }
}
