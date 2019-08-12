using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Salario1
{
    public class Procesaamento
    {
        public void Processar()
        {
            Funcionario funcionario = new Funcionario();
            Salario salario = new Salario();

            Console.WriteLine("--------\nSNOB CONFECÇÕES--------");

            Console.WriteLine("\nEntre com o nome do funcionario: ");
            string nome = Console.ReadLine();

            funcionario.MostrarNome(nome);

            Console.WriteLine("\nEntre com as horas trabalhadas do funcionario " + nome);
            float horas = float.Parse(Console.ReadLine());           

            Console.WriteLine("\nEntre com a classe funcional do funcionario " + nome + " (1) ou (2): ");
            int funcionalidade = int.Parse(Console.ReadLine());

            Console.WriteLine("\nClasse funcional selecionada foi a " + funcionalidade);

            salario.MostrarSalario(horas, funcionalidade);
        }
    }
}
