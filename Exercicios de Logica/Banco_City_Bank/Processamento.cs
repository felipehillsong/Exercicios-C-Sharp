using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_City_Bank
{
    public class Processamento
    {
        public void Processar()
        {
            ContaCorrente conta = new ContaCorrente();

            Console.WriteLine("Saldo Inicial: " + conta.SaldoInicio());

            Console.WriteLine("\nEntre com o valor do deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            conta.Depositar(valorDeposito);

            

            for(int i = 0; i <= 1; i++)
            {
                Console.WriteLine("\nEntre com um valor de saque: ");
                double valorSaque = double.Parse(Console.ReadLine());
                conta.Sacar(valorSaque);

            }

        }


    }
}
