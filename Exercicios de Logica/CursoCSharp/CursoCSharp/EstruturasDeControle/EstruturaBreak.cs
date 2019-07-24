using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.EstruturasDeControle
{
    class EstruturaBreak
    {
        public static void Executar()
        {
            Random aleatorio = new Random();
            int numero = aleatorio.Next(1, 51);

            Console.WriteLine("O numero que queremos é {0}.", numero);

            for(int i=1; i<=50; i++)
            {
                Console.WriteLine("{0} é o numero que queremos? ", i);
                if(i == numero)
                {
                    Console.WriteLine("Sim!");
                    break;
                }
                else
                {
                    Console.WriteLine("Não!");
                }
            }

        }
    }
}
