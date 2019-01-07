using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.ClassesEMetodos
{
    class CalculadoraComum
    {
        public int Somar(int a, int b)
        {
            return a + b;
        }   
        
        public int Subtrair(int a, int b)
        {
            return a - b;
        }

        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public int Dividir(int a, int b)
        {
            return a / b;
        }
    }

    class MetodosComRetorno
    {
        public static void Executar()
        {
            var calculadorComumSomar = new CalculadoraComum();
            var resultado1 = calculadorComumSomar.Somar(5,5);
            Console.WriteLine(resultado1);

            var calculadorComumSubtrair = new CalculadoraComum();
            var resultado2 = calculadorComumSubtrair.Subtrair(5, 7);
            Console.WriteLine(resultado2);

            var calculadoraComumMultiplicar = new CalculadoraComum();
            var resultador3 = calculadoraComumMultiplicar.Multiplicar(3, 4);
            Console.WriteLine(resultador3);

            var calculadoraComumDividir = new CalculadoraComum();
            var resultado4 = calculadoraComumDividir.Dividir(9, 3);
            Console.WriteLine(resultado4);

        }
    }
}
