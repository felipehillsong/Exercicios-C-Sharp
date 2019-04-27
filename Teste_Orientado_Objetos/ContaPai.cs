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
            ContaPai c = new ContaPai();

            Console.WriteLine("Entre com o nome do cliente: ");
            c.Titular = Console.ReadLine();
            Console.WriteLine("Cliente: " + c.Titular);

            Console.WriteLine("Entre com o numero da conta: ");
            c.Numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero da conta é: " + c.Numero);                     

            c.SaldoInicial();            

            Console.WriteLine("Entre com o valor do deposito: ");
            double valor = double.Parse(Console.ReadLine());

            c.Depositar(valor);            

            Console.WriteLine("Entre com o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            c.Sacar(valorSaque);

            ContaPai c2 = new ContaPai();            

            Console.WriteLine("Entre com o nome do cliente destino da transferencia: ");
            c2.Titular = Console.ReadLine();
            Console.WriteLine("Cliente da transação: " + c2.Titular);

            Console.WriteLine("Entre com o numero da conta destino da transferencia: ");
            c2.Numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero da conta da transação: " + c2.Numero);

            Console.WriteLine("Realizar a transferencia de quanto: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            c.Trasnferencia(valorTransferencia, c, c2);

            Console.WriteLine("O saldo da conta do cliente " + c2.Titular + " é " + c2.Saldo);

            Console.WriteLine("Saldo do titular " + c.Titular + " e de " + c.Saldo);

        }        

        private void SaldoInicial()
        {
            this.Saldo = 100;
            Console.WriteLine("Saldo inicial é: " + this.Saldo);
        }

        
        private double Depositar(double valor)
        {            
            this.Saldo += valor;
            Console.WriteLine("Seu deposito foi de " + valor + " e seu saldo atual é de " + this.Saldo);
            return this.Saldo;                  
        }

        private bool Sacar(double valorSaque)
        {
            if (this.Saldo >= valorSaque)
            {
                this.Saldo -= valorSaque;
                Console.WriteLine("Foi feito o saque de " + valorSaque + " seu saldo atual é de " + this.Saldo);
                return true;                       
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
        }

        private bool Trasnferencia(double valorTransferencia, ContaPai c, ContaPai c2)
        {
            if (this.Saldo >= valorTransferencia)
            {
                c.Saldo -= valorTransferencia;
                c2.Saldo += valorTransferencia;
                
                Console.WriteLine("Foi feito a transferencia de " + valorTransferencia + " com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Não foi possivel realizar a transferencia!");
                return false;
            }

        }
    }
}
