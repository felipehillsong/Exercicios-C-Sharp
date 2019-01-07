using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.ClassesEMetodos
{
    public class CalculadoraEstatica
    {
        public int Somar(int a, int b)
        {
            return a + b;
        }

        public static int Multiplicar(int a, int b)
        {
            return a * b;
        }
    }

    class MetodosEstaticos
    {       
        public static void Executar()
        {
            CalculadoraEstatica calc = new CalculadoraEstatica();
            Console.WriteLine(calc.Somar(2, 2));

            var resultado = CalculadoraEstatica.Multiplicar(2, 2);
            Console.WriteLine(resultado);

            


        }
    }
}
