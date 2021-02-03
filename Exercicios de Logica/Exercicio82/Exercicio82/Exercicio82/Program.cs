using System;

namespace Exercicio82
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 50, 10, 88, 26, 3, 75, 41, 30, 94, 63 };
            int maiorNumero = 0;
            int menorNumero = 0;
            int maiorNumeroParametro = 0;
            int menorNumeroParametro = 0;

            maiorNumero = numeros[0];
            menorNumero = numeros[0];
            for (int i = 1; i < numeros.Length; i++)
            {
                maiorNumeroParametro = numeros[i];
                menorNumeroParametro = numeros[i];
                if (maiorNumeroParametro > maiorNumero)
                {
                    maiorNumero = maiorNumeroParametro;
                }
                            
                if (menorNumeroParametro < menorNumero)
                {
                    menorNumero = menorNumeroParametro;
                }
                
            }

            Console.WriteLine($"O menor numero do array é {menorNumero}");
            Console.WriteLine($"O maior numero do array é {maiorNumero}");

            Console.ReadKey();

        }
    }
}
