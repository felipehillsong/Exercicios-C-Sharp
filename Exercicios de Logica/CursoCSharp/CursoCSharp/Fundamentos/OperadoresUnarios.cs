using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.Fundamentos
{
    class OperadoresUnarios
    {
        public static void Executar()
        {
            var valorNegativo = -5;
            var numero1 = 2;
            var numero2 = 3;
            var booleano = true;

            Console.WriteLine(-valorNegativo);//colocando o - antes ele inverte o sinal do numero
            Console.WriteLine(!booleano);//colocando o ! antes ele inverte de true pra false

            numero1++;//acrescentou mais um no numero 3
            Console.WriteLine(numero1);
                        
        }
    }
}
