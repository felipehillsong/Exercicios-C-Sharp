using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmpireConfeccoes
{
    class Processamento
    {
        public void Processar()
        {
            for(int i = 0; i<10; i++)
            {
                Funcionarios funcionarios = new Funcionarios();
                Console.WriteLine("Entre com o nome do Funcionario");
                string nome = Console.ReadLine();
                funcionarios.MostrarNome(nome);

                Console.WriteLine("Entre com as horas trabalhadas do funcionario " + nome + ".");
                double hora = double.Parse(Console.ReadLine());

                Console.WriteLine("Qual o salario por hora do funcionario " + nome + "?");
                double salario = double.Parse(Console.ReadLine());

                funcionarios.MostrarSalario(hora, salario);
            }
            
        }

    }
}
