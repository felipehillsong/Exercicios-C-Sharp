using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDeTemperatura
{
    class Program
    {
        static void Main(string[] args)
        {
            Processamento medida = new Processamento();
            medida.Processar();
        }
    }
}
