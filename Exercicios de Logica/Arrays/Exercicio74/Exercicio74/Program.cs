using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio74
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[5];
            numeros[0] = 0;
            numeros[1] = 0;
            numeros[2] = 0;
            numeros[3] = 0;
            numeros[4] = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine(numeros[i] = i + 1);
            }


            Console.ReadKey();
        }
    }
}
