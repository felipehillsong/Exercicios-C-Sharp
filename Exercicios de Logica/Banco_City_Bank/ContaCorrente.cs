using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_City_Bank
{
    public class ContaCorrente
    {
        private double SaldoInicial { get; set; }

        private double SaldoFinal { get; set; }

        public double SaldoInicio()
        {
            return this.SaldoInicial = 500;
        }

        public void Depositar(double deposito)
        {
            double saldoinicial = this.SaldoInicio();
            this.SaldoFinal = saldoinicial + deposito;
            Console.WriteLine("\nO Deposito junto com o saldo inicial é de: " + this.SaldoFinal);            
        }

        public double Sacar(double saque)
        {           
            if(this.SaldoFinal >= saque)
            {
                this.SaldoFinal -= saque;
                Console.WriteLine("\nO Saldo depois do saque é de: " + this.SaldoFinal);
                return this.SaldoFinal;
            }
            else
            {
                return 0;
            }
        }

       
    }
}
