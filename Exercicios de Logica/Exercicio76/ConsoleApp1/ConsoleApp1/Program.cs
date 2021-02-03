using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[10];
            numeros[0] = 0;
            numeros[1] = 0;
            numeros[2] = 0;
            numeros[3] = 0;
            numeros[4] = 0;
            numeros[5] = 0;
            numeros[6] = 0;
            numeros[7] = 0;
            numeros[8] = 0;
            numeros[9] = 0;

            for (int i = 0; i < numeros.Length; i++)
            {               
                var resultadoIndicie = numeros[i] + i * i;
                //Se o resto da divisão do numero for 0 ele é par, se for 1 é impar
                if (resultadoIndicie % 2 == 0)
                {
                    Console.WriteLine(resultadoIndicie);                    
                }
            }


            Console.ReadKey();
        }
    }
}
