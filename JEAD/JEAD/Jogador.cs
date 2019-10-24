using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAD
{
    public class Jogador
    {
        private string Jogador1 { get; set; }

        private string Jogador2 { get; set; }

        public void MostrarNome(string jogador1, string jogador2)
        {
            this.Jogador1 = jogador1;
            this.Jogador2 = Jogador1;
        }
    }
}