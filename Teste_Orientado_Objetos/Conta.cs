using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Orientado_Objetos
{
    public class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }

        public void SaldoInicial()
        {
            this.Saldo = 100;
            Console.WriteLine("Saldo inicial é: " + this.Saldo);
        }

        public double Depositar(double valor)
        {
            this.Saldo += valor;
            Console.WriteLine("Seu deposito foi de " + valor + " e seu saldo atual é de " + this.Saldo);
            return this.Saldo;
        }

        public bool Sacar(double valorSaque)
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

        public double Trasnferencia(double valorTransferencia, Conta contaTitular, Conta contaRecebeDeposito)
        {      
            if (this.Saldo >= valorTransferencia)
            {
                contaTitular.Saldo -= valorTransferencia;
                contaRecebeDeposito.Saldo += valorTransferencia;

                Console.WriteLine("Foi feito a transferencia de " + valorTransferencia + " com sucesso!");
                
            }
            else
            {
                Console.WriteLine("Não foi possivel realizar a transferencia!");                
            }
            return contaRecebeDeposito.Saldo;
        }          
       
    }
}