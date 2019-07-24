using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.Fundamentos
{
    class LendoDados
    {
        public static void Executar()
        {
            Console.WriteLine("Qual é o seu nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Qual a sua idade?");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o seu salario?");
            double salario = double.Parse(Console.ReadLine());

            Console.WriteLine(nome.ToUpper());
            Console.WriteLine(idade);
            Console.WriteLine(salario);

            Console.WriteLine($"{nome.ToUpper()} {idade} R${salario}");//o console vai ler tudo em uma linha so, tem que por desse jeito

            
        }
    }
}
