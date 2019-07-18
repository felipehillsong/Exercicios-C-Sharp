using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Heranca
{
    public class Processamento
    {
        public void Processar()
        {
            Console.WriteLine("----------BANCO SILVA S/A----------");

            Console.WriteLine("\nEntre com o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Entre com o CPF do cliente: ");
            double cpf = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual tipo de clinte que é? Digite 1 para cliente fisico ou 2 para cliente juridico: ");
            int tipoCliente = int.Parse(Console.ReadLine());

            TipoCliente(nome, cpf, tipoCliente );

            Console.WriteLine("Qual tipo de conta o cliente possui? Digite 1 para Conta Corrente ou 2 para Conta Poucança:  ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o numero da conta do cliente: ");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o valor de deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            TipoConta(tipoConta, numero, valorDeposito, valorSaque);

        }

        private void TipoCliente(string nome, double cpf, int tipoCliente)
        {
            try
            {                
                switch (tipoCliente)
                {
                    case 1:
                        ClienteFisico clienteFisico = new ClienteFisico();
                        clienteFisico.PegarNome(nome);
                        clienteFisico.PegarCPF(cpf);
                        Console.WriteLine("Cliente do tipo Fisico");
                        break;
                    case 2:
                        ClienteJuridico clienteJuridico = new ClienteJuridico();
                        clienteJuridico.PegarNome(nome);
                        clienteJuridico.PegarCPF(cpf);
                        Console.WriteLine("Cliente do tipo Juridico");
                        break;
                    default:
                        Console.WriteLine("Tipo de cliente está errado!");
                        Environment.Exit(0);
                        break;
                }

                
            }
            catch(Exception e)
            {

                Console.WriteLine("Tipo de cliente errado! " + e.Message);
            }            
                           
        }     

        private void TipoConta(int tipoConta, int numero, double valorDeposito, double valorSaque)
        {
            try
            {
                switch (tipoConta)
                {
                    case 1:
                        ContaCorrente contaCorrente = new ContaCorrente();
                        Console.WriteLine("Tipo de conta do cliente é Conta Corrente");
                        contaCorrente.NumeroConta(numero);
                        contaCorrente.Deposito(valorDeposito);
                        contaCorrente.Saque(valorSaque);                        
                        break;
                    case 2:
                        ContaPoupanca contaPoupanca = new ContaPoupanca();
                        Console.WriteLine("Tipo de conta do cliente é Conta Poupança");
                        contaPoupanca.NumeroConta(numero);
                        contaPoupanca.Deposito(valorDeposito);
                        contaPoupanca.Saque(valorSaque);                        
                        break;
                    default:
                        Console.WriteLine("Tipo de conta errado!");
                        Environment.Exit(0);
                        break;
                }
            }
            catch(Exception e)
            {

                Console.WriteLine("Tipo de dodos errados " + e.Message);
            }           

            
        }
    }
}
