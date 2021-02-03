using System;

namespace Exercicio78
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros1 = new int[10];
            int[] numeros2 = new int[10];
            int[] somaNumeros = new int[10];
            int[] subtracaoNumeros = new int[10];

            numeros1[0] = 14;
            numeros1[1] = 8;
            numeros1[2] = 36;
            numeros1[3] = 24;
            numeros1[4] = 58;
            numeros1[5] = 41;
            numeros1[6] = 1;
            numeros1[7] = 63;
            numeros1[8] = 86;
            numeros1[9] = 77;

            numeros2[0] = 99;
            numeros2[1] = 15;
            numeros2[2] = 2;
            numeros2[3] = 18;
            numeros2[4] = 35;
            numeros2[5] = 81;
            numeros2[6] = 64;
            numeros2[7] = 26;
            numeros2[8] = 48;
            numeros2[9] = 55;

            for (int i = 0; i < numeros1.Length; i++)
            {
                Console.WriteLine($"Valores do primeiro array {numeros1[i]}");
            }

            Console.WriteLine("\n");

            for (int i = 0; i < numeros1.Length; i++)
            {
                Console.WriteLine($"Valores do segundo array {numeros2[i]}");
            }

            Console.WriteLine("\n");

            for (int i = 0; i < numeros1.Length; i++)
            {   
                somaNumeros[i] = numeros1[i] + numeros2[i];                
                Console.WriteLine($"A soma dos valores dos 2 arrays na posição {i}: {somaNumeros[i]}");
            }

            Console.WriteLine("\n");

            for (int i = 0; i < numeros1.Length; i++)
            {
                if (numeros1[i] < numeros2[i])
                {
                    subtracaoNumeros[i] = numeros2[i] - numeros1[i];
                }
                else
                {
                    subtracaoNumeros[i] = numeros1[i] - numeros2[i];
                }

                Console.WriteLine($"A diferença dos valores dos 2 arrays na posição {i}: {subtracaoNumeros[i]}");
            }

            Console.ReadKey();
        }
    }
}
