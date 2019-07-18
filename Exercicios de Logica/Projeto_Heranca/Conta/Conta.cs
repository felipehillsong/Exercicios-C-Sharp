using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Heranca
{
    public abstract class Conta
    {
        protected int Numero { get; set; }

        protected double SaldoInicial { get; set; }

        protected double SaldoFinal { get; set; }

        public abstract int NumeroConta(int Numero);

        public virtual double SaldoComeco()
        {
            return this.SaldoInicial;
        }        

        public abstract double Deposito(double valorDeposito);

        public abstract double Saque(double valorSaque);
    }
}
