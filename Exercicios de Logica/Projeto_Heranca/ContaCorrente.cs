using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Heranca
{
    public class ContaCorrente:Conta
    {
        public override int NumeroConta(int numeroConta)
        {
            return this.Numero = numeroConta;
        }

        public override double SaldoComeco()
        {
            return this.SaldoInicial = 100;
        }

        public override void Deposito(double valorDeposito)
        {
            double saldoInicial = SaldoComeco();
            this.SaldoFinal = saldoInicial + valorDeposito;
        }

        public override double Saque(double valorSaque)
        {
            double saldoFinal = this.SaldoFinal;
            if(saldoFinal >= valorSaque)
            {
                double saldoFinalizado = saldoFinal - valorSaque;
                return saldoFinalizado;
            }
            else
            {
                return 0;
            }

        }
    }
}
