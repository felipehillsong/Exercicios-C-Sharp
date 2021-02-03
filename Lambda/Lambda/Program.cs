using System;
using System.Linq;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] candidatos = { 0, 12, 13, 17, 27, 29, 45, 50 };
            int candidato12 = 0;
            int candidato13 = 0;
            int candidato17 = 0; 
            int candidato27 = 0;
            int candidato29 = 0;
            int candidato45 = 0;
            int candidato50 = 0;
            int candidato0 = 0;
            int? votacao = 0;
            int votosNulos = 0;

            do
            {   
                Console.WriteLine("Outra votação? (1)Sim outros numeros Não");
                votacao = int.Parse(Console.ReadLine());                

                if (votacao != 1)
                {
                    break;
                }

                Console.WriteLine("Selecione o numero do seu candidato: 12, 13, 17, 27, 29, 45, 50. Ou 0 para Branco. Para anular qualquer numero que não seja os anteriores");
                int voto = int.Parse(Console.ReadLine());

                foreach (var item in candidatos)
                {
                    Console.WriteLine($"Votou no numero {voto}");
                    if (voto != 12 && voto != 13 && voto != 12 && voto != 17 && voto != 27 && voto != 29 && voto != 45 && voto != 50 && voto != 0)
                    {
                        votosNulos = +1;
                        Console.WriteLine("Votou nulo");
                    }
                    else
                    {
                        switch (voto)
                        {
                            case 12:
                                candidato12 += 1;
                                break;
                            case 13:
                                candidato13 += 1;
                                break;
                            case 17:
                                candidato17 += 1;
                                break;
                            case 27:
                                candidato27 += 1;
                                break;
                            case 29:
                                candidato29 += 1;
                                break;
                            case 45:
                                candidato45 += 1;
                                break;
                            case 50:
                                candidato50 += 1;
                                break;
                            case 0:
                                candidato0 += 1;
                                Console.WriteLine("Votou em Branco");
                                break;
                            default:
                                break;
                        }
                    }                   

                    break;
                };
               
            } while (votacao == 1);

                Console.WriteLine($"Numeros de votos do candidato 12 são: {candidato12} ");
                Console.WriteLine($"Numeros de votos do candidato 13 são: {candidato13} ");
                Console.WriteLine($"Numeros de votos do candidato 17 são: {candidato17} ");
                Console.WriteLine($"Numeros de votos do candidato 27 são: {candidato27} ");
                Console.WriteLine($"Numeros de votos do candidato 29 são: {candidato29} ");
                Console.WriteLine($"Numeros de votos do candidato 45 são: {candidato45} ");
                Console.WriteLine($"Numeros de votos do candidato 50 são: {candidato50} ");
                Console.WriteLine($"Numeros de votos em Branco são: {candidato0} ");
                Console.WriteLine($"Numeros de votos em Nulos são: {votosNulos} ");
                Console.ReadKey();
            }
        }
    }
