using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmpireConfeccoes
{
   public class Funcionarios
    {
        private string Nome { get; set; }

        private double SalarioHora { get; set; }       

        public void MostrarNome(string nome)
        {
            this.Nome = nome;
            Console.WriteLine("O nome do funcionario é: "+Nome);            
        }     

        public void MostrarSalario(double hora, double salario)
        {
             this.SalarioHora = salario;

            double salarioBruto = hora * SalarioHora;
            double descontoINSS = 11 * salarioBruto / 100;
            double salarioLiquido = salarioBruto - descontoINSS;

            Console.WriteLine("O salario bruto do funcionario "+this.Nome +" é: "+salarioBruto+". O salario liquido é: "+salarioLiquido);
        }
    }
}
