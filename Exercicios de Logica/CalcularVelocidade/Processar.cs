using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularVelocidade
{
    public class Processar
    {
        public void Processamento()
        {
            ReceberVelocidade calculo = new ReceberVelocidade();

            Console.WriteLine("Entre com uma velocidade: ");
            double velocidade = double.Parse(Console.ReadLine());

            calculo.PegarVelocidade(velocidade);

            calculo.CalculandoVelocidade();           

        }     

    }
}
