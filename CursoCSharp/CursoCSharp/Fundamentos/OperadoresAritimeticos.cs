using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.Fundamentos
{
    class OperadoresAritimeticos
    {
        public static void Executar()
        {
            //preço com desconto
            var preco = 1000.0;
            var imposto = 355;
            var desconto = 0.1;

            double total = preco + imposto;
            var totalDesconto = total - (total * desconto);
            Console.WriteLine(totalDesconto);
        }

    }
}
