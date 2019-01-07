using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.Fundamentos
{
    class NotacaoPonto
    {
        public static void Executar()
        {
            var saudacao = "ola".ToUpper().Insert(3, " World!").Replace ("Wold!", "Mundo");
            Console.WriteLine(saudacao);

            string nome = "felipe rocha e silva".ToUpper();//deixa tudo maiusculo
            Console.WriteLine(nome);
                        
            string sobrenome = "FERREIRA ROCHA".ToLower(); //deixa tudo minusculo
            Console.WriteLine(sobrenome);

            Console.WriteLine("Josecler Umbelino dos Santos".ToUpper());

        }

    }
}
