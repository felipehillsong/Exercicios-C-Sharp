using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAD
{
    public class Jogar
    {
        #region - variaveis principais e objetos
        private Jogador jogador;
        private Baralho baralho;
        private Carta cartaJogardor1;
        private Carta cartaJogador2;
        #endregion

        #region - variaveis de controle
        int i = 0;
        int rodadas = 0;
        int respostaJogador1 = 0;
        int respostaJogador2 = 0;
        int vitoriasJogador1 = 0;
        int vitoriasJogador2 = 0;
        #endregion

        public Jogar()
        {
            jogador = new Jogador();
            baralho = new Baralho();
        }

        public void Processamento()
        {

            Console.WriteLine("------SEJAM BEM-VINDOS------");
            Console.WriteLine("-----QUEM TIVER A MAIOR CARTA, É O VENCEDOR-----");
            Console.WriteLine("\nO jogo terá quantas rodadas? ");
            rodadas = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o nome do primeiro jogador: ");
            string nomePrimeiroJogador = Console.ReadLine();
            Console.WriteLine($"\nJogador {nomePrimeiroJogador} quer tirar a primeira carta? (1)SIM ou (2)NÃO ");
            respostaJogador1 = int.Parse(Console.ReadLine());
            if (respostaJogador1 == 1)
            {
                cartaJogardor1 = baralho.PegarCartaJogador1();
                Console.WriteLine($"Jogador {nomePrimeiroJogador} tirou a carta {cartaJogardor1.Face} de {cartaJogardor1.Naipe}");
            }
            else if (respostaJogador1 == 2)
            {
                Console.WriteLine($"Foi um prazer jogar com você {nomePrimeiroJogador}, o jogo será encerrado, pois é necessário dois jogadores!");
                Console.ReadKey();
                Environment.Exit(1);
            }

            Console.WriteLine("\n\nEntre com o nome do segundo jogador: ");
            string nomeSegundoJogador = Console.ReadLine();
            Console.WriteLine($"Jogador {nomeSegundoJogador} quer tirar a segunda carta? (1)SIM ou (2)NÃO ");
            respostaJogador2 = int.Parse(Console.ReadLine());
            if (respostaJogador2 == 1)
            {
                cartaJogador2 = baralho.PegarCartaJogador2();
                Console.WriteLine($"Jogador {nomeSegundoJogador} tirou a carta {cartaJogador2.Face} de {cartaJogador2.Naipe}");
            }
            else if (respostaJogador2 == 2)
            {
                Console.WriteLine($"Foi um prazer jogar com você {nomeSegundoJogador}, o jogo será encerrado, pois é necessário dois jogadores!");
                Console.ReadKey();
                Environment.Exit(1);
            }


            jogador.MostrarNome(nomePrimeiroJogador, nomeSegundoJogador);

            if (cartaJogardor1.Peso > cartaJogador2.Peso)
            {
                vitoriasJogador1 += 1;
                Console.WriteLine($"\n\nJogador {nomePrimeiroJogador} ganhou o jogo, pois o peso da sua carta é {cartaJogardor1.Peso}");
            }

            if (cartaJogardor1.Peso < cartaJogador2.Peso)
            {
                vitoriasJogador2 += 1;
                Console.WriteLine($"\n\nJogador {nomeSegundoJogador} ganhou o jogo, pois o peso da sua carta é {cartaJogador2.Peso}");
            }

            i = 1;

            for (i = 2; i <= rodadas; i++)
            {
                Console.WriteLine($"\nJogador {nomePrimeiroJogador} quer tirar outra carta? (1)SIM ou (2)NÃO ");
                respostaJogador1 = int.Parse(Console.ReadLine());
                if (respostaJogador1 == 1)
                {
                    cartaJogardor1 = baralho.PegarCartaJogador1();
                    Console.WriteLine($"\nJogador {nomePrimeiroJogador} tirou a carta {cartaJogardor1.Face} de {cartaJogardor1.Naipe}");
                }
                else if (respostaJogador1 == 2)
                {
                    Console.WriteLine($"Foi um prazer jogar com você {nomeSegundoJogador}");
                    break;
                }

                Console.WriteLine($"\nJogador {nomeSegundoJogador} que tirar outra carta? (1) SIM ou (2)NÃO ");
                respostaJogador2 = int.Parse(Console.ReadLine());
                if (respostaJogador2 == 1)
                {
                    cartaJogador2 = baralho.PegarCartaJogador2();
                    Console.WriteLine($"Jogador {nomeSegundoJogador} tirou a carta {cartaJogador2.Face} de {cartaJogador2.Naipe}");
                }
                else if (respostaJogador2 == 2)
                {
                    Console.WriteLine($"Foi um prazer jogar com você {nomeSegundoJogador}");
                    break;
                }


                if (cartaJogardor1.Peso > cartaJogador2.Peso)
                {
                    vitoriasJogador1 += 1;
                    Console.WriteLine($"\nJogador {nomePrimeiroJogador} ganhou o jogo, pois o peso da sua carta é {cartaJogardor1.Peso}");
                }

                if (cartaJogardor1.Peso < cartaJogador2.Peso)
                {
                    vitoriasJogador2 += 1;
                    Console.WriteLine($"Jogador {nomeSegundoJogador} ganhou o jogo, pois o peso da sua carta é {cartaJogador2.Peso}");
                }
            }            

            Console.WriteLine($"Numero de vitorias do jogador {nomePrimeiroJogador} é {vitoriasJogador1}");
            Console.WriteLine($"Numero de vitorias do jogador {nomeSegundoJogador} é {vitoriasJogador2}");

            if (vitoriasJogador1 > vitoriasJogador2)
            {
                Console.WriteLine($"O grande vencedor é o jogador {nomePrimeiroJogador}");
            }
            else if (vitoriasJogador1 < vitoriasJogador2)
            {
                Console.WriteLine($"O grande vencedor é o jogador {nomeSegundoJogador}");
            }
            else if(vitoriasJogador1 == vitoriasJogador2)
            {
                Console.WriteLine("Jogo empatado");
            }           

            Console.WriteLine("\n\nFOI ÓTIMO JOGAR COM VOCÊS");

            Console.ReadKey();
        }

    }
}
