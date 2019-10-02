using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritimoSalario
{
    public class Funcionario
    {
        private string Nome { get; set; }

        private double HorasTrabalhadas { get; set; }

        private double SalarioHora { get; set; }

        private string Sexo { get; set; }

        public void Dados(string nome, double horasTrabalhadas, double salarioHora, int sexo)
        {
            this.Nome = nome;
            this.HorasTrabalhadas = horasTrabalhadas;
            this.SalarioHora = salarioHora;
            this.Sexo = sexo.ToString();
        }
    }
}
