using System;
using System.Linq;

namespace Exercicio81
{
    class Program
    {
        static void Main(string[] args)
        {
            int salario = 0;       

            int[] classeSalario = new int[11];
            classeSalario[1] = 800;
            classeSalario[2] = 1600;
            classeSalario[3] = 2000;
            classeSalario[4] = 2100;
            classeSalario[5] = 2200;
            classeSalario[6] = 2500;
            classeSalario[7] = 2600;
            classeSalario[8] = 2700;
            classeSalario[9] = 3000;
            classeSalario[10] = 4000;

            Console.WriteLine("Entre com o nome do funcionario: ");
            string nome = Console.ReadLine();

            Console.WriteLine($"Entre com a classe de salario do funcionario {nome}: ");
            int classe = int.Parse(Console.ReadLine());

            for (int i = 1; i < classeSalario.Length; i++)
            {
                if (i == classe)
                {
                    salario = classeSalario[i];                    
                }
                
            }

            Console.WriteLine($"O salario do funcionario {nome} é {salario}." );

            Console.ReadKey();
        }
    }
}
