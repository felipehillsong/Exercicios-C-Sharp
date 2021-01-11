using System;
using System.Linq;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 5, 19, 98, 35, 72, 63, 21, 44, 59, 12, 59 };

            //var numerosSelecionado = numeros.Where(x => x < 30);

            //foreach (var item in numerosSelecionado)
            //{
            //    Console.WriteLine(item);
            //}

            //var numerosSelecionado = numeros.Count(x => x < 30);
            //Console.WriteLine(numerosSelecionado);

            //var numerosSelecionado = numeros.Count(x => x.Equals(59));
            //Console.WriteLine(numerosSelecionado);

            //var numerosSelecionado = numeros.Where(x => x.Equals(59));
            //foreach (var item in numerosSelecionado)
            //{
            //    Console.WriteLine(item);
            //}

            var numerosSelecionado = numeros.Sum(x => x);
            Console.WriteLine(numerosSelecionado);


            Console.ReadKey();
        }

        
    }
}
