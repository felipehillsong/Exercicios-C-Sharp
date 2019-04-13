using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Orientado_Objetos {
    class ContaPai {
        private int Numero { get; set; }
        private string Titular { get; set; }
        private double Saldo { get; set; }

        public void Processamento()
        {
            Console.WriteLine("Entre com o nome do cliente: ");
            this.Titular = Console.ReadLine();
            Console.WriteLine("Cliente: " + this.Titular);

            Console.WriteLine("Entre com o numero da conta: ");
            this.Numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero da conta é: " + this.Numero);

            ContaPai c = new ContaPai();         

            c.SaldoInicial();            

            Console.WriteLine("Entre com o valor do deposito: ");
            double valor = double.Parse(Console.ReadLine());

            c.Depositar(valor);            

            Console.WriteLine("Entre com o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            c.Sacar(valorSaque);
            
        }
        
        private void SaldoInicial()
        {
            this.Saldo = 100;
            Console.WriteLine("Saldo inicial é: " + this.Saldo);
        }

        
        private double Depositar(double valor){
            
            this.Saldo += valor;
            Console.WriteLine("Você fez o deposito de " + valor + " Seu saldo atual é de: " + this.Saldo);
            return this.Saldo;                  
        }

        private bool Sacar(double valorSaque)
        {            
            if (this.Saldo >= valorSaque)
            {
                this.Saldo -= valorSaque;
                Console.WriteLine("Você fez o saque de " + valorSaque + " Seu saldo atual é de: " + this.Saldo);
                return true;                       
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
        }
    }
}
