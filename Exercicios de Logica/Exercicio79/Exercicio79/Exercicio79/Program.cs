using System;

namespace Exercicio79
{
    class Program
    {
        static void Main(string[] args)
        {   
            int[] numeros = new int[10];           
            int acumulador = 0;
            int menorNumero = 0;
            int maiorNumero = 0;

            Console.WriteLine("Entre com 10 numeros: ");
            int numero1 = int.Parse(Console.ReadLine());           
            menorNumero = numero1;
            maiorNumero = numero1;
            numeros[0] = numero1;
            acumulador = numeros[0];

            for (int i = 1; i < numeros.Length; i++)
            {
                int numero2 = int.Parse(Console.ReadLine());
                numeros[i] = numero2;
                acumulador += numeros[i];
                if (numeros[i] > maiorNumero)
                {
                    maiorNumero = numeros[i];
                }

                if (numeros[i] < menorNumero)
                {
                    menorNumero = numeros[i];
                }                
            }

            int media = acumulador / numeros.Length;
            Console.WriteLine($"O menor numero que entrou no array foi: {menorNumero}");
            Console.WriteLine($"O maior numero que entrou no array foi: {maiorNumero}");
            Console.WriteLine($"A media dos numeros é: {media}");
            Console.ReadKey();
        }
    }
}
