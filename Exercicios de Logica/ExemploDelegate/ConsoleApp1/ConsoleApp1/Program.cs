using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculadora = new Calculadora();
            var Somar = new Calcular(calculadora.Somar);
            var Subtrair = new Calcular(calculadora.Subtrair);
            var Multiplicar = new Calcular(calculadora.Multiplicar);
            var Dividir = new Calcular(calculadora.Dividir);

            Console.WriteLine("Qual operação deseja realizar? (1)Somar (2)Subtrair (3)Multiplicar (4)Dividir");
            double resposta = int.Parse(Console.ReadLine());

            if (resposta >= 5)
            {
                Console.WriteLine("Operação Invalida! Escolha uma operação de 1 a 4.");
                Environment.Exit(1);
            }

            Console.WriteLine("PRIMEIRO NUMERO: ");
            double value1 = int.Parse(Console.ReadLine());

            Console.WriteLine("SEGUNDO NUMERO: ");
            double value2 = int.Parse(Console.ReadLine());

            switch (resposta)
            {
                case 1:
                    Console.WriteLine(Somar(value1, value2));
                    break;
                case 2:
                    Console.WriteLine(Subtrair(value1, value2));
                    break;
                case 3:
                    Console.WriteLine(Multiplicar(value1, value2));
                    break;
                case 4:
                    Console.WriteLine(Dividir(value1, value2));
                    break;
                default:
                  
                    break;
            }
           
            Console.ReadKey();
        }
    }
}