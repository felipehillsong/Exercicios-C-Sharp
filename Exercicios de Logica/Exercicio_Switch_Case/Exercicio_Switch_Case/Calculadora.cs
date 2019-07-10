using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Switch_Case
{
    public class Calculadora
    {
        private double Numero1 { get; set; }

        private double Numero2 { get; set; }

        private string Operador { get; set; }


        public double Somar(double numero1, double numero2)
        {
            this.Numero1 = numero1;
            this.Numero2 = numero2;           

            return this.Numero1 + this.Numero2;
        }

        public double Subtrair(double numero1, double numero2)
        {
            this.Numero1 = numero1;
            this.Numero2 = numero2;            
            
            return this.Numero1 - this.Numero2;
        }

        public double Multiplicar(double numero1, double numero2)
        {
            this.Numero1 = numero1;
            this.Numero2 = numero2;            
            
            return this.Numero1 * this.Numero2;
        }

        public double Dividir(double numero1, double numero2)
        {
            this.Numero1 = numero1;
            this.Numero2 = numero2;            
           
            return this.Numero1 / this.Numero2;
        }
        
        public void EscolherOperacao(double num1, string oper, double num2)
        {
            this.Operador = oper;
            switch (this.Operador)
            {
                case "+":
                    double soma = Somar(num1, num2);
                    Console.WriteLine(soma);
                    break;
                case "-":
                  double subtrair = Subtrair(num1, num2);
                    Console.WriteLine(subtrair);
                    break;
                case "*":
                    double multiplicar = Multiplicar(num1, num2);
                    Console.WriteLine(multiplicar);
                    break;
                case "/":
                    double dividir = Dividir(num1, num2);
                    Console.WriteLine(dividir);
                    break;
                default:
                    Console.WriteLine("OPERADOR NÃO FOI INICIADO!");
                    break;
            }            
           
        }

    }
}
