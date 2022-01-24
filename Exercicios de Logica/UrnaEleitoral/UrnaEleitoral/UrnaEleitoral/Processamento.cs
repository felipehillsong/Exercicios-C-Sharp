using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Processamento
    {
        private Candidato candidato { get; set; }
        private Partido partido { get; set; }
        public Processamento()
        {
            partido = new Partido();
            candidato = new Candidato();
            candidato.partido = new Partido();            
        }

        public void Processar()
        {
            Candidato resultado;
            var voto = 0;
            var votoDeNovo = 0;
            bool resposta = false;

            Console.WriteLine("Escolha seu candidato: (45)AÉCIO (13)LULA (50)JEAN (17) BOLSONARO (00)BRANCO. QUALQUER OUTRO NUMERO DIGITADO SERA DADO COMO NULO.");
            voto = int.Parse(Console.ReadLine());
            resultado = Eleicao(voto);

            Console.WriteLine("Gostaria de votar? (1)SIM ou (2)NÃO");
            votoDeNovo = int.Parse(Console.ReadLine());
            resposta = false;

            if (votoDeNovo == 1)
            {
                resposta = true;
            }
            else
            {
                resposta = false;
            }


            while (resposta)
            {
                Console.WriteLine("Escolha seu candidato: (45)AÉCIO (13)LULA (50)JEAN (17) BOLSONARO (00)BRANCO. QUALQUER OUTRO NUMERO DIGITADO SERA DADO COMO NULO.");
                voto = int.Parse(Console.ReadLine());
                resultado = Eleicao(voto);

                Console.WriteLine("Gostaria de votar? (1)SIM ou (2)NÃO");
                votoDeNovo = int.Parse(Console.ReadLine());

                if (votoDeNovo == 1)
                {
                    resposta = true;
                }
                else if(votoDeNovo == 2 || votoDeNovo != 1)
                {
                    resposta = false;
                }
                else
                {
                    resposta = false;
                }
            }

            Console.WriteLine($"Detalhes da eleição PMDB: {resultado.ResultadoEleicaoAecio}, Percentual em Realção a Todos os Votos: {resultado.porcentagemAecio}");
            Console.WriteLine($"Detalhes da eleição PT: {resultado.ResultadoEleicaoLula}, Percentual em Realção a Todos os Votos: {resultado.porcentagemLula}");
            Console.WriteLine($"Detalhes da eleição PSOL: {resultado.ResultadoEleicaoJean}, Percentual em Realção a Todos os Votos: {resultado.porcentagemJean}");
            Console.WriteLine($"Detalhes da eleição PSL: {resultado.ResultadoEleicaoBolsonaro}, Percentual em Realção a Todos os Votos: {resultado.porcentagemBolsonaro}");
            Console.WriteLine($"Detalhes da eleição em Branco: {resultado.ResultadoEleicaoEmBranco}, Percentual em Realção a Todos os Votos: {resultado.porcentagemBranco}");
            Console.WriteLine($"Detalhes da eleição Nulos: {resultado.ResultadoEleicaoNulo}, Percentual em Realção a Todos os Votos: {resultado.porcentagemNulos}");
        }

        private Candidato Eleicao(int voto)
        {
            switch (voto)
            {
                case 45:
                    candidato.partido.NomePartido = Partido.PartidoPolitico.PSDB.ToString();
                    candidato.partido.NumeroPartido = (int)Partido.PartidoPolitico.PSDB;
                    candidato.Nome = "Aécio";
                    candidato.NumeroVotosAecio += 1;
                    candidato.ResultadoEleicaoAecio = $"Nome: {candidato.Nome}, Partido: {candidato.partido.NomePartido}, Numero do Partido: {candidato.partido.NumeroPartido}, Quantidade de Votos: {candidato.NumeroVotosAecio}";
                    break;
                case 13:
                    candidato.partido.NomePartido = Partido.PartidoPolitico.PT.ToString();
                    candidato.partido.NumeroPartido = (int)Partido.PartidoPolitico.PT;
                    candidato.Nome = "Lula";
                    candidato.NumeroVotosLula += 1;
                    candidato.ResultadoEleicaoLula = $"Nome: {candidato.Nome}, Partido: {candidato.partido.NomePartido}, Numero do Partido: {candidato.partido.NumeroPartido}, Quantidade de Votos: {candidato.NumeroVotosLula}";
                    break;
                case 50:
                    candidato.partido.NomePartido = Partido.PartidoPolitico.PSOL.ToString();
                    candidato.partido.NumeroPartido = (int)Partido.PartidoPolitico.PSOL;
                    candidato.Nome = "Jean";
                    candidato.NumeroVotosJean += 1;
                    candidato.ResultadoEleicaoJean = $"Nome: {candidato.Nome}, Partido: {partido.NomePartido}, Numero do Partido: {candidato.partido.NumeroPartido}, Quantidade de Votos: {candidato.NumeroVotosJean}";
                    break;
                case 17:
                    candidato.partido.NomePartido = Partido.PartidoPolitico.PSL.ToString();
                    candidato.partido.NumeroPartido = (int)Partido.PartidoPolitico.PSL;
                    candidato.Nome = "Bolsonaro";
                    candidato.NumeroVotosBolsonaro += 1;
                    candidato.ResultadoEleicaoBolsonaro = $"Nome: {candidato.Nome}, Partido: {candidato.partido.NomePartido}, Numero do Partido: {candidato.partido.NumeroPartido}, Quantidade de Votos: {candidato.NumeroVotosBolsonaro}";
                    break;
                case 00:
                    candidato.NumeroVotosEmBranco += 1;
                    candidato.ResultadoEleicaoEmBranco = $"Votos em Branco: {candidato.NumeroVotosEmBranco}";
                    break;
                default:
                    candidato.NumeroVotosNulos += 1;
                    candidato.ResultadoEleicaoNulo = $"Votos Nulos: {candidato.NumeroVotosNulos}";
                    break;
            }

            candidato.totalVotos = candidato.NumeroVotosAecio + candidato.NumeroVotosLula + candidato.NumeroVotosJean + candidato.NumeroVotosBolsonaro;
            candidato.porcentagemAecio = (candidato.NumeroVotosAecio / candidato.totalVotos) * 100;
            candidato.porcentagemLula = (candidato.NumeroVotosLula / candidato.totalVotos) * 100;
            candidato.porcentagemJean = (candidato.NumeroVotosJean / candidato.totalVotos) * 100;
            candidato.porcentagemBolsonaro = (candidato.NumeroVotosBolsonaro / candidato.totalVotos) * 100;
            candidato.porcentagemBranco = (candidato.NumeroVotosEmBranco / candidato.totalVotos) * 100;
            candidato.porcentagemNulos = (candidato.NumeroVotosNulos / candidato.totalVotos) * 100;

            return candidato;
        }
    }
}
