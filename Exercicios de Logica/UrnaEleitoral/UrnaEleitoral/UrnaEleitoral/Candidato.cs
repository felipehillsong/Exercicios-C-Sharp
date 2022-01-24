using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Candidato
    {
        public string Nome { get; set; }
        public Partido partido { get; set; }
        public string ResultadoEleicaoAecio { get; set; }
        public string ResultadoEleicaoLula { get; set; }
        public string ResultadoEleicaoJean { get; set; }
        public string ResultadoEleicaoBolsonaro { get; set; }
        public string ResultadoEleicaoEmBranco { get; set; }
        public string ResultadoEleicaoNulo { get; set; }
        public double NumeroVotosAecio { get; set; }
        public double NumeroVotosLula { get; set; }
        public double NumeroVotosJean { get; set; }
        public double NumeroVotosBolsonaro { get; set; }
        public double NumeroVotosEmBranco { get; set; }
        public double NumeroVotosNulos { get; set; }
        public double totalVotos { get; set; }
        public double porcentagemAecio { get; set; }
        public double porcentagemLula { get; set; }
        public double porcentagemJean { get; set; }
        public double porcentagemBolsonaro { get; set; }
        public double porcentagemBranco { get; set; }
        public double porcentagemNulos { get; set; }
    }
}
