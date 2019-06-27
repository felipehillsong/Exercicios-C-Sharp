using CalculadoraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraMVC.Processamento
{
    public class Processar
    {
        public double Somar(double numero1, double numero2)
        {
            CalculadoraModel calculadora = new CalculadoraModel();
            calculadora.Numero1 = numero1;
            calculadora.Numero2 = numero2;

            calculadora.Resultado = calculadora.Numero1 + calculadora.Numero2;
            return calculadora.Resultado;
        }

        public double Subtrair(double numero1, double numero2)
        {
            CalculadoraModel calculadora = new CalculadoraModel();
            calculadora.Numero1 = numero1;
            calculadora.Numero2 = numero2;

            calculadora.Resultado = calculadora.Numero1 - calculadora.Numero2;
            return calculadora.Resultado;
        }

        public double Multiplicar(double numero1, double numero2)
        {
            CalculadoraModel calculadora = new CalculadoraModel();
            calculadora.Numero1 = numero1;
            calculadora.Numero2 = numero2;

            calculadora.Resultado = calculadora.Numero1 * calculadora.Numero2;
            return calculadora.Resultado;
        }

        public double Dividir(double numero1, double numero2)
        {
            CalculadoraModel calculadora = new CalculadoraModel();
            calculadora.Numero1 = numero1;
            calculadora.Numero2 = numero2;

            calculadora.Resultado = calculadora.Numero1 / calculadora.Numero2;
            return calculadora.Resultado;
        }

        public double EscolherOperacao(double num1, string oper, double num2)
        {
            CalculadoraModel calculadora = new CalculadoraModel();
            calculadora.Operador = oper;

            switch (calculadora.Operador)
            {
                case "+":
                    double soma = Somar(num1, num2);
                    calculadora.Resultado = soma;
                    break;
                case "-":
                    double subtrair = Subtrair(num1, num2);
                    calculadora.Resultado = subtrair;
                    break;
                case "*":
                    double multiplicar = Multiplicar(num1, num2);
                    calculadora.Resultado = multiplicar;
                    break;
                case "/":
                    double dividir = Dividir(num1, num2);
                    calculadora.Resultado = dividir;
                    break;
                default:
                    calculadora.Resultado = 00;
                    break;
            }

            return calculadora.Resultado;

        }
    }
}