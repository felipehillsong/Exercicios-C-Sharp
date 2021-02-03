using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public delegate double Calcular(double value1, double value2);
    public class Calculadora
    {        
        public double Somar(double value1, double value2)
        {  
            return value1 + value2;
        }
                
        public double Subtrair(double value1, double value2)
        {            
            return value1 - value2;
        }
        
        public double Multiplicar(double value1, double value2)
        {            
            return value1 * value2;
        }
        
        public double Dividir(double value1, double value2)
        {            
            return value1 / value2;
        }
    }
}