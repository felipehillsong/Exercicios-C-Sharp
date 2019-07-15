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

            Console.WriteLine("Qual tipo de clinte que é? Digite 1 para cliente fisico ou 2 para cliente juridico: ");
            int tipoCliente = int.Parse(Console.ReadLine());

            TipoCliente(nome, tipoCliente);

            Console.WriteLine("Qual tipo de conta o cliente possui? Digite 1 para Conta Corrente ou 2 para Conta Poucança:  ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o numero da conta do cliente: ");
            int numero = int.Parse(Console.ReadLine());

            TipoConta(tipoConta, numero);

        }

        public void TipoCliente(string nome, int tipoCliente)
        {
            if(tipoCliente == 1)
            {
                ClienteFisico clienteFisico = new ClienteFisico();
                clienteFisico.PegarNome(nome);                
            }
            if(tipoCliente == 2)
            {
                ClienteJuridico clienteJuridico = new ClienteJuridico();
                clienteJuridico.PegarNome(nome);
            }
            else
            {
                Console.WriteLine("Tipo de cliente ou tipo de conta errado!");
            }                 
        }

        public void TipoConta(int tipoConta, int numero)
        {
            if(tipoConta == 1)
            {
                ContaCorrente conta = new ContaCorrente();
                conta.NumeroConta(numero);
            }
            if(tipoConta == 2)
            {
                ContaPoupanca contaPoupanca = new ContaPoupanca();
                contaPoupanca.NumeroConta(numero);
            }
        }
    }
}
