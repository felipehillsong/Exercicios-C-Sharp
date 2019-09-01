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

        private string PegarNome(string nome)
        {                  
            return this.Nome = nome;
        }     

        public void MostrarSalario(string nome, double hora, double salario)
        {
            string nomeFuncionario = PegarNome(nome);
            this.SalarioHora = salario;

            double salarioBruto = hora * SalarioHora;
            double descontoINSS = 11 * salarioBruto / 100;
            double salarioLiquido = salarioBruto - descontoINSS;

            Console.WriteLine("O salario bruto do funcionario "+ nomeFuncionario + " é: "+salarioBruto+". O salario liquido é: "+salarioLiquido);
        }
    }
}
