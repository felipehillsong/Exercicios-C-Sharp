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
            this.Numero = numeroConta;
            Console.WriteLine("Numero da conta é: " + this.Numero);
            return this.Numero;
        }

        public override double SaldoComeco()
        {
            this.SaldoInicial = 100;
            Console.WriteLine("Saldo inicial é: " + this.SaldoInicial);
            return this.SaldoInicial;
        }

        public override double Deposito(double valorDeposito)
        {
            double saldoInicial = SaldoComeco();
            Console.WriteLine("O Valor do deposito foi de: " + valorDeposito);            
            this.SaldoFinal = saldoInicial + valorDeposito;
            Console.WriteLine("o valor do deposito com o saldo anterior é de: " + this.SaldoFinal);
            return this.SaldoFinal;
        }

        public override double Saque(double valorSaque)
        {
            Console.WriteLine("O valor do saque é: " + valorSaque);
            double saldoFinal = this.SaldoFinal;
            if(saldoFinal >= valorSaque)
            {
                double saldoFinalizado = saldoFinal - valorSaque;
                Console.WriteLine("Seu saldo final é: " + saldoFinalizado);
                return saldoFinalizado;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
                Environment.Exit(0);
                return 0;
            }

        }
    }
}
