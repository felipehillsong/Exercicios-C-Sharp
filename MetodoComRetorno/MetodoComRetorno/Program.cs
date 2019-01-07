using System;

namespace MetodoComRetorno
{
    class Program
    {
        static int Somar(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            int resultado = Somar(5, 6);
            Console.WriteLine(resultado);

        }
    }
}
