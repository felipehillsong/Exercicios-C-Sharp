using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasConcurso
{
    class Materias
    {
        private double Portugues { get; set; }

        private double Matematica { get; set; }

        private double Direito { get; set; }

        public void PegarNota(double portugues, double matematica, double direito)
        {
            this.Portugues = portugues;
            this.Matematica = matematica;
            this.Direito = direito;
        }

        public void CalcularMedia()
        {
            double media = (this.Portugues + this.Matematica + this.Direito) / 3;
            Console.WriteLine("A media das notas é: " + media);
        }

        public void CalculoPonderado()
        {
            double mediaPonderada = (this.Portugues * 2) + (this.Matematica * 4) + (this.Direito) * 3 / 9;
            Console.WriteLine("A media ponderada das notas é: " + mediaPonderada);
        }
    }
}
