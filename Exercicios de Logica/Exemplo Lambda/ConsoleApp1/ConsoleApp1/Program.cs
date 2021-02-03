using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Exemplo usando Lista
            List<int> numeros = new List<int>
            {
                1,2,3,4,5,6,7,8,9,10
            };

            List<int> numerosImpares = numeros.Where(x => x % 2 == 1).ToList();

            foreach (var item in numerosImpares)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------------------------------");

            List<int> numerosPares = numeros.Where(x => x % 2 == 0).ToList();

            foreach (var item in numerosPares)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------------------------------");


            //Exemplo usando Array
            string[] nomes =
            {
                "Felipe",
                "Polyana",
                "Hugo",
                "Renata",
                "Roberto"
            };

            var nomeEspecifico = (nomes.Where(x => x.Contains("F")));

            foreach (var item in nomeEspecifico)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------------------------------");
            

            List<string> ListaNomes = new List<string>();

            ListaNomes.Add("Eduardo");
            ListaNomes.Add("Fabricio");
            ListaNomes.Add("Quentin");
            ListaNomes.Add("Tarantino");
            ListaNomes.Add("Monica");
            ListaNomes.Add("Tobias");

            var listaNomeEpecifico = ListaNomes.Where(x => x.StartsWith("T"));
            foreach (var item in listaNomeEpecifico)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------------------------------");

            //Essa Func é o metodo comentado abaixo resumido
            Func<int, int> quadrado = num => num * num;
            Console.WriteLine(quadrado(4));

            var program = new Program();
            Console.WriteLine(program.Quadrado(4, 4));
            
            

            Console.ReadKey();
        }

        public int Quadrado(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
