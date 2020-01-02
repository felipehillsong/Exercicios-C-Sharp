using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaMariaDaPenha
{
    public class Processamento
    {
        Funcionario funcionario { get; set; }

        public Processamento()
        {
            funcionario = new Funcionario();
        }

        public void Processar()
        {
            int s = 0;

            Console.WriteLine("Deseja calcular quantas fichas? ");
            int fichas = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o nome do funcionario: ");
            funcionario.Nome = Console.ReadLine();

            Console.WriteLine($"Entre com a matricula do funcionario {funcionario.Nome}: ");
            funcionario.Matricula = int.Parse(Console.ReadLine());

            Console.WriteLine($"Qual a classe de salario do funcionario {funcionario.Nome}? (1)R$16,00 por hora ou (2)R$20,00 por hora.");
            funcionario.ClasseSalario = int.Parse(Console.ReadLine());

            Console.WriteLine($"Entre com as horas trabalhadas do funcionario {funcionario.Nome}: ");
            funcionario.HorasTrabalhadas = double.Parse(Console.ReadLine());

            Console.WriteLine($"Entre com as horas extras do funcionario {funcionario.Nome}: ");
            funcionario.HorasExtras = double.Parse(Console.ReadLine());

            funcionario.Dados(funcionario);

            s = 1;

            for (s = 2; s <= fichas; s++)
            {
                Console.WriteLine("\nEntre com o nome do funcionario: ");
                funcionario.Nome = Console.ReadLine();

                Console.WriteLine($"Entre com a matricula do funcionario {funcionario.Nome}: ");
                funcionario.Matricula = int.Parse(Console.ReadLine());

                Console.WriteLine($"Qual a classe de salario do funcionario {funcionario.Nome}? (1)R$16,00 por hora ou (2)R$20,00 por hora.");
                funcionario.ClasseSalario = int.Parse(Console.ReadLine());

                Console.WriteLine($"Entre com as horas trabalhadas do funcionario {funcionario.Nome}: ");
                funcionario.HorasTrabalhadas = double.Parse(Console.ReadLine());

                Console.WriteLine($"Entre com as horas extras do funcionario {funcionario.Nome}: ");
                funcionario.HorasExtras = double.Parse(Console.ReadLine());

                funcionario.Dados(funcionario);
            }

        }
    }
}