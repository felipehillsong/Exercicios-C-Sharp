using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Exercicio77
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cidades = new string[10];
            int[] cidadeRepetida = new int[10];
            
            cidades[0] = "Cuiabá";
            cidades[1] = "São Paulo";
            cidades[2] = "Cuiabá";
            cidades[3] = "Belo Horizonte";
            cidades[4] = "Rio de Janeiro";
            cidades[5] = "Maceió";
            cidades[6] = "Campo Grande";
            cidades[7] = "Manaus";
            cidades[8] = "Belo Horizonte";
            cidades[9] = "Fortaleza";

            Console.Write("A cidade de Belo Horizonte se encontra nas posições do array: ");
            for (int i = 0; i < cidades.Length; i++)
            {
                if (cidades[i].Equals("Belo Horizonte"))
                {
                    cidadeRepetida[i] = i;
                    
                    Console.Write(cidadeRepetida[i] + " ");
                }
            }            

            Console.ReadKey();
        }
    }
}
