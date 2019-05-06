using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Orientado_Objetos {
    public class Processar {        
        public void Processamento()
        {
            ContaTitular titular = new ContaTitular();

            Console.WriteLine("Entre com o nome do cliente: ");
            titular.Nome = Console.ReadLine();
            Console.WriteLine("Cliente: " + titular.Nome);

            Console.WriteLine("Entre com o CPF do cliente: ");
            titular.CPF = int.Parse(Console.ReadLine());
            Console.WriteLine("CPF: " + titular.CPF);

            Console.WriteLine("Entre com o RG do cliente: ");
            titular.RG = int.Parse(Console.ReadLine());
            Console.WriteLine("RG: " + titular.RG);

            Conta contaTitular = new Conta();

            Console.WriteLine("Entre com o numero da conta: ");
            contaTitular.Numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero da conta é: " + contaTitular.Numero);

            contaTitular.SaldoInicial();            

            Console.WriteLine("Entre com o valor do deposito: ");
            double valor = double.Parse(Console.ReadLine());

            contaTitular.Depositar(valor);            

            Console.WriteLine("Entre com o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            contaTitular.Sacar(valorSaque);

            ContaDeposito contaDeposito = new ContaDeposito();   

            Console.WriteLine("Entre com o nome do cliente destino da transferencia: ");
            contaDeposito.Nome = Console.ReadLine();
            Console.WriteLine("Cliente da transação: " + contaDeposito.Nome);

            Console.WriteLine("Entre com o CPF do cliente destino da transferencia: ");
            contaDeposito.CPF = int.Parse(Console.ReadLine());
            Console.WriteLine("CPF: " + contaDeposito.CPF);

            Console.WriteLine("Entre com o RG da conta destino da transferencia: ");
            contaDeposito.RG = int.Parse(Console.ReadLine());
            Console.WriteLine("Numero da conta da transação: " + contaDeposito.RG);

            Conta contaRecebeDeposito = new Conta();

            Console.WriteLine("Realizar a transferencia de quanto: ");
            double valorTransferencia = double.Parse(Console.ReadLine());            

            contaTitular.Trasnferencia(valorTransferencia, contaTitular, contaRecebeDeposito);           

            Console.WriteLine("O saldo da conta do cliente " + contaDeposito.Nome + " e " + contaRecebeDeposito.Saldo);

            Console.WriteLine("Saldo do titular " + titular.Nome + " e de " + contaTitular.Saldo);

        }  
    }
}
