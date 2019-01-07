using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.MetodosEFuncoes
{
    delegate double Operacao(double x, double y);

    class LambdasDelegate
    {
        public static void Executar()
        {
            Operacao som = (x, y) => x + y;
            Operacao sub = (x, y) => x - y;
            Operacao mul = (x, y) => x * y;
            Operacao div = (x, y) => x / y;

            Console.WriteLine(som(3,7));
            Console.WriteLine(sub(15,8));
            Console.WriteLine(mul(10,6));
            Console.WriteLine(div(24,8));
        }
    }
}
