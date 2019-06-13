using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularVelocidade
{
    public class ReceberVelocidade
    {
        private double Velociade { get; set; }

        public double PegarVelocidade(double velocidade)
        {
            this.Velociade = velocidade;

            return this.Velociade;
        }

        public void CalculandoVelocidade()
        {
            this.Velociade *= 3.6;
            Console.WriteLine("A velocidade em metros por segundo é: " + this.Velociade);
        }
    }
}
