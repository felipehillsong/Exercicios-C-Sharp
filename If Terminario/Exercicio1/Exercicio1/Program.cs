using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoas = new List<Pessoa>();
            pessoas.Add(new Pessoa("Felipe", 34));
            pessoas.Add(new Pessoa("Polyana", 33));
            pessoas.Add(new Pessoa("Eny", 58));
            pessoas.Add(new Pessoa("Julio", 58));
            pessoas.Add(new Pessoa("Claudio", 52));
            pessoas.Add(new Pessoa("Felipe", 49));

            Console.WriteLine("Entre com um nome ou idade para a pesquisa a pessoa: ");
            string nomeOuIdade = Console.ReadLine();

            var converteString = ConverterString(nomeOuIdade);
            var converteInt = ConverterInt(nomeOuIdade);            

            var result = converteString != "" ? pessoas.FirstOrDefault(x => x.Nome.ToLower() == converteString.ToLower()) : pessoas.FirstOrDefault(x => x.Idade == converteInt);

            Console.WriteLine(result == null ? "Essa pessoa não existe na minha lista" : $"O nome da pessoa é {result.Nome} e a sua idade é {result.Idade}");                               
    
            Console.ReadKey();
        }

        static string ConverterString(string valor)
        {
            if (valor.Where(c => char.IsLetter(c)).Count() > 0)
            {
                return valor;
            }
            else
            {
                return "";
            }
        }

        static int ConverterInt(string valor)
        {
            if (valor.Where(c => char.IsLetter(c)).Count() > 0)
            {
                return 0;
            }
            else if (String.IsNullOrEmpty(valor) || valor.Trim().Length == 0)
            {
                return 0;
            }
            else
            {
                int numero = int.Parse(valor);
                return numero;
            }
        }
    }
}
