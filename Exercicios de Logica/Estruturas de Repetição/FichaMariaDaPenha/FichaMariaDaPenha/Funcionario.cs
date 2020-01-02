using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaMariaDaPenha
{
    public class Funcionario : IDados
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int ClasseSalario { get; set; }
        public double HorasTrabalhadas { get; set; }
        public double HorasExtras { get; set; }
        private double SalarioNormalFinal { get; set; }
        private double SalarioHoraExtraFinal { get; set; }
        private double SalarioComDesconto { get; set; }
        private double SalarioFinalizado { get; set; }

        public void Dados(Funcionario funcionario)
        {
            switch (funcionario.ClasseSalario)
            {
                case 1:
                    if (funcionario.HorasExtras == 0)
                    {
                        this.SalarioNormalFinal = funcionario.HorasTrabalhadas * 16;
                        this.SalarioComDesconto = (SalarioNormalFinal * 8) / 100;
                        this.SalarioFinalizado = SalarioNormalFinal - SalarioComDesconto;
                        Console.WriteLine($"\nNome do funcionario: {Nome}\nMatricula do funcionario {Nome}: {Matricula}\nHoras Trabalhadas: {HorasTrabalhadas}\nSalario Bruto: R${SalarioNormalFinal}\nHoras Extras: {HorasExtras}\nDesconto INSS: R${SalarioComDesconto}\nSalario Liquido: R${SalarioFinalizado}");
                    }

                    if (funcionario.HorasExtras > 0)
                    {
                        this.SalarioNormalFinal = funcionario.HorasTrabalhadas * 16;
                        this.SalarioHoraExtraFinal = SalarioNormalFinal * 1.30;
                        this.SalarioComDesconto = (SalarioHoraExtraFinal * 8) / 100;
                        this.SalarioFinalizado = SalarioHoraExtraFinal - SalarioComDesconto;
                        Console.WriteLine($"\nNome do funcionario: {Nome}\nMatricula do funcionario {Nome}: {Matricula}\nHoras Trabalhadas: {HorasTrabalhadas}\nSalario Bruto: R${SalarioNormalFinal}\nHoras Extras: {HorasExtras}\nSalario Bruto com horas extras: {SalarioHoraExtraFinal}\nDesconto INSS: R${SalarioComDesconto}\nSalario Liquido: R${SalarioFinalizado}");
                    }
                    break;
                case 2:
                    if (funcionario.HorasExtras == 0)
                    {
                        this.SalarioNormalFinal = funcionario.HorasTrabalhadas * 20;
                        this.SalarioComDesconto = (SalarioNormalFinal * 8) / 100;
                        this.SalarioFinalizado = SalarioNormalFinal - SalarioComDesconto;
                        Console.WriteLine($"\nNome do funcionario: {Nome}\nMatricula do funcionario {Nome}: {Matricula}\nHoras Trabalhadas: {HorasTrabalhadas}\nSalario Bruto: R${SalarioNormalFinal}\nHoras Extras: {HorasExtras}\nDesconto INSS: R${SalarioComDesconto}\nSalario Liquido: R${SalarioFinalizado}");
                    }

                    if (funcionario.HorasExtras > 0)
                    {
                        this.SalarioNormalFinal = funcionario.HorasTrabalhadas * 20;
                        this.SalarioHoraExtraFinal = SalarioNormalFinal * 1.30;
                        this.SalarioComDesconto = (SalarioHoraExtraFinal * 8) / 100;
                        this.SalarioFinalizado = SalarioHoraExtraFinal - SalarioComDesconto;
                        Console.WriteLine($"\nNome do funcionario: {Nome}\nMatricula do funcionario {Nome}: {Matricula}\nHoras Trabalhadas: {HorasTrabalhadas}\nSalario Bruto: R${SalarioNormalFinal}\nHoras Extras: {HorasExtras}\nSalario Bruto com horas extras: {SalarioHoraExtraFinal}\nDesconto INSS: R${SalarioComDesconto}\nSalario Liquido: R${SalarioFinalizado}");
                    }
                    break;
            }
        }
    }
}