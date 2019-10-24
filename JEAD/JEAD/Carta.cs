using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAD
{
    public class Carta
    {
        public string Face { get; private set; }

        public string Naipe { get; private set; }

        public int Valor { get; private set; }

        public int Peso { get; private set; }

        public Carta(string face, string naipe, int valor, int peso)
        {
            this.Face = face;
            this.Naipe = naipe;
            this.Valor = valor;
            this.Peso = peso;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, $"Face: {Face}, Naipe: {Naipe}, Valor: {Valor}, Peso: {Peso}");
        }

    }
}