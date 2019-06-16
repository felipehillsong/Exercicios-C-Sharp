using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDeTemperatura
{
    class PegarTemperatura
    {
        private double Fahrenheit{ get; set; }

        public double PegandoTemperatura(double temperatura)
        {
            this.Fahrenheit = temperatura;

            return this.Fahrenheit;
        }

        public void Conversao()
        {
            double celsius = (this.Fahrenheit - 32) * 5 / 9;

            Console.WriteLine("A temperatura em CELSIUS é: " + celsius);
        }
    }
}
