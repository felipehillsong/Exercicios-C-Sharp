using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogoAED
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

    }
}
