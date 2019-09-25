using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomeIdade
{
    class Processamento
    {
        public void Processar()
        {
            int somar = 0;
            int inicializador = 0;

            while(inicializador < 3)
            {
                Console.WriteLine("Entre com o nome do usuario: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Entre com a idade do usuario: ");
                int idade = int.Parse(Console.ReadLine());               
               
                somar += idade;                

                Usuario usuario = new Usuario();
                usuario.Dados(nome, idade);

                inicializador++;
            }

            Console.WriteLine("A soma de todas as idades é: "+somar);
        }
    }
}
