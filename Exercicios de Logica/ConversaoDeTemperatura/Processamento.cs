using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDeTemperatura
{
    class Processamento
    {
        public void Processar()
        {
            PegarTemperatura calcular = new PegarTemperatura();

            Console.WriteLine("Entre com a temperatura em FAHRENHEIT: ");
            double temperatura = double.Parse(Console.ReadLine());
            calcular.PegandoTemperatura(temperatura);

            calcular.Conversao();        
        }
    }
}
