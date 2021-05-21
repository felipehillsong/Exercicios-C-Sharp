using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraOrientadaObjeto
{
    public class Processamento
    {        
        public void Processar()
        {
            Calculadora calcular = new Calculadora();

            Console.WriteLine("Entre com o primeiro numero");
            int numero1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o operador desejado (+) (-) (*) (/)");
            calcular.Operador = Console.ReadLine();

            Console.WriteLine("Entre com o segundo numero");
            int numero2 = int.Parse(Console.ReadLine());

            switch (calcular.Operador)
            {
                case "+":
                    Console.WriteLine(calcular.Somar(numero1, numero2));                   
                    break;
                case "-":
                    Console.WriteLine(calcular.Subtrair(numero1, numero2));                   
                    break;
                case "*":
                    Console.WriteLine(calcular.Multiplicar(numero1, numero2));                   
                    break;
                case "/":
                    Console.WriteLine(calcular.Dividir(numero1, numero2));                   
                    break;
                default:
                    Console.WriteLine("Operador Invalido!");
                    break;
            }
           
        }
    }
}
