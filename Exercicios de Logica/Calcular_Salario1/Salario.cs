using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular_Salario1
{
    public class Salario
    {
        public double Salario1 { get; set; }        

        public double MostrarSalario(float horas, int funcional)
        {
            Funcionario funcionario = new Funcionario();
            float classe = funcionario.MostrarClasse(funcional);

            if(funcional == 1)
            {
                float salarioFinal = horas * 5;
                this.Salario1 = salarioFinal * 11 / 100;
                Console.WriteLine("O salario é: " + this.Salario1);
                return this.Salario1;
            }
            else if(funcional == 2)
            {
                float salarioFinal = horas * 9;
                this.Salario1 = salarioFinal * 11 / 100;
                Console.WriteLine("O salario é: " + this.Salario1);
                return this.Salario1;
            }

            return 0;
        }
    }
}
