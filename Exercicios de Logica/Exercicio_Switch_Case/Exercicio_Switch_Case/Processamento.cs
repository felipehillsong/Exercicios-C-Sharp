using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Switch_Case
{
    public class Processamento
    {
        public void Processar()
        {
            Calculadora calculadora = new Calculadora();

            Console.WriteLine("Entre com o primeiro numero: ");
            double numero1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o operador desejado: ");
            string operador = Console.ReadLine();            

            Console.WriteLine("Entre com o segundo numero: ");
            double numero2 = double.Parse(Console.ReadLine());

            calculadora.EscolherOperacao(numero1, operador, numero2);          
            

        }        
        

    }
}
