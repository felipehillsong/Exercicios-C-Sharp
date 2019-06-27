using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraMVC.Models
{
    public class CalculadoraModel
    {
        public double Numero1 { get; set; }

        public string Operador { get; set; }

        public double Numero2 { get; set; }

        public double Resultado { get; set; }

        public string Menssagem { get; set; }
    }
}