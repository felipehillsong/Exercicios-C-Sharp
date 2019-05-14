using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Orientado_Objetos
{
    public class Banco
    {
        private string Nome { get; set; }
        private string Endereco { get; set; }      
        
        
        public void NomeBanco()
        {
            this.Nome = "\n\n\nBanco Itaú";
            Console.WriteLine(this.Nome);                        
        }

        public void EnderecoCompleto()
        {
            this.Endereco = ("Avenida Afonso Pena 1300, Centro, Belo Horizonte, Minas Gerais");
            Console.WriteLine(this.Endereco);          
        }

    }

}
