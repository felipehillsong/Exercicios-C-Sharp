using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraOrientadaObjeto
{
    public class Calculadora
    {        
        public string Operador { get; set; }

        public int Somar(int num1, int num2)
        {
            return num1 + num2;
        }
        public int Subtrair(int num1, int num2)
        {
            return num1 - num2;
        }
        public int Multiplicar(int num1, int num2)
        {
            return num1 * num2;
        }
        public int Dividir(int num1, int num2)
        {
            return num1 / num2;
        }
    }
}
