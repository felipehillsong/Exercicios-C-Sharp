using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaFor
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Crie uma página que exibe na tela números de 0 a 100
            e sempre que for múltiplos de 3 escreva Hello, e quando for múltiplos de 5 World.*/                 

            for(int i = 0; i<=100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i+" HELLO");
                }
                if(i% 5 == 0)
                {
                    Console.WriteLine(i + " WORD");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            Console.ReadKey();
        }
    }
}
