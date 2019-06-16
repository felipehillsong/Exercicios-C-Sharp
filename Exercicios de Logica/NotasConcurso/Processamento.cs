using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasConcurso
{
    class Processamento
    {
        public void Processar()
        {
            Materias notas = new Materias();

            Console.WriteLine("Entre com a nota de Portugues: ");
            double portugues = float.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a nota de Matematica: ");
            double matematica = float.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a nota de Direito: ");
            double direito = float.Parse(Console.ReadLine());

            notas.PegarNota(portugues, matematica, direito);

            notas.CalcularMedia();

            notas.CalculoPonderado();

        }
    }
}
