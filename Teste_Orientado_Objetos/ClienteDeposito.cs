using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Orientado_Objetos
{
    class ClienteDeposito
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int RG { get; set; }
        public string Endereco { get; set; }

        public void Processamento3()
        {
            Cliente clientedeposito = new Cliente();

            Console.WriteLine("Entre com o nome do cliente: ");
            clientedeposito.Nome = Console.ReadLine();
            Console.WriteLine("Cliente: " + clientedeposito.Nome);

            Console.WriteLine("Entre com o CPF do cliente");
            clientedeposito.CPF = int.Parse(Console.ReadLine());
            Console.WriteLine("Cliente: " + clientedeposito.CPF);

            Console.WriteLine("Entre com o RG do cliente");
            clientedeposito.RG = int.Parse(Console.ReadLine());
            Console.WriteLine("Cliente: " + clientedeposito.RG);

            Console.WriteLine("Entre com o endereço do cliente");
            clientedeposito.Endereco = Console.ReadLine();
            Console.WriteLine("Cliente: " + clientedeposito.Endereco);
        }
    }
}
