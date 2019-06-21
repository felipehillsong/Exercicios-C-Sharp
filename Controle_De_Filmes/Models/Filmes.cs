using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controle_De_Filmes.Models
{
    public class Filmes
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Diretor { get; set; }

        public string Genero  { get; set; }

        public int Ano { get; set; }

        public string Tipo { get; set; }
    }
}