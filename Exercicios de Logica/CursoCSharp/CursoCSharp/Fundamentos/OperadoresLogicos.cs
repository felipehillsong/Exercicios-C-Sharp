using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.Fundamentos
{
    class OperadoresLogicos
    {
        public static void Executar()
        {
            var executouTrabalho1 = true;
            var executouTrabalho2 = false;

            var comprouTv50 = executouTrabalho1 && executouTrabalho2;//comando && as duas tem que ser verdadeiras
            Console.WriteLine(comprouTv50);

            var comprouTv = executouTrabalho1 || executouTrabalho2;//comando || apenas uma tem que ser verdadeira
            Console.WriteLine(comprouTv);

        }

    }
}
