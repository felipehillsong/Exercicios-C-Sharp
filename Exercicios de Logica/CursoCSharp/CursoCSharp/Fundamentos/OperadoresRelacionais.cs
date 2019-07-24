using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.Fundamentos
{
    class OperadoresRelacionais
    {
        public static void Executar()
        {
            double nota = 10.0;
            double notaDeCorte = 7.0;

            Console.WriteLine(nota>10.0);
            Console.WriteLine("Nota ivalida " + (nota < 0.0));
            Console.WriteLine("Perfeito!" + (nota == 10.0));


        }
    }
}
