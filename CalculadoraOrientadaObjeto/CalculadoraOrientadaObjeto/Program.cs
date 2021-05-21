using System;

namespace CalculadoraOrientadaObjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var processamento = new Processamento();
            processamento.Processar();

            Console.ReadKey();
        }
    }
}
