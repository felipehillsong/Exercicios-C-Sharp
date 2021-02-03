using System;

namespace Exercicio83
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] classeSalarial = new int[7];
            classeSalarial[0] = 800;
            classeSalarial[1] = 1000;
            classeSalarial[2] = 1100;
            classeSalarial[3] = 1500;
            classeSalarial[4] = 2500;
            classeSalarial[5] = 4000;
            classeSalarial[6] = 6000;

            string[] nomes = new string[10];
            int opcao = 0;
            int salario = 0;

            Console.WriteLine("Entre com o nome do funcionario: ");
            string nome = Console.ReadLine();

            Console.WriteLine($"Entre com a classe salarial do funcionario {nome}. Opções de 1 a 7: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    opcao = 0;
                    break;
                case 2:
                    opcao = 1;
                    break;
                case 3:
                    opcao = 2;
                    break;
                case 4:
                    opcao = 3;
                    break;
                case 5:
                    opcao = 4;
                    break;
                case 6:
                    opcao = 5;
                    break;
                case 7:
                    opcao = 6;
                    break;
                default:
                    Console.WriteLine("Opção digitada errada, favor escolher uma opção de 1 a 7");
                    break;
            }

            salario = classeSalarial[opcao];

            for (int i = 1; i < nomes.Length; i++)
            {
                Console.WriteLine("Entre com o nome do funcionario: ");
                nomes[i] = Console.ReadLine();
                Console.WriteLine($"Entre com a classe salarial do funcionario {nome}. Opções de 1 a 7: ");
                classeSalarial[opcao] = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        opcao = 0;
                        break;
                    case 2:
                        opcao = 1;
                        break;
                    case 3:
                        opcao = 2;
                        break;
                    case 4:
                        opcao = 3;
                        break;
                    case 5:
                        opcao = 4;
                        break;
                    case 6:
                        opcao = 5;
                        break;
                    case 7:
                        opcao = 6;
                        break;
                    default:
                        Console.WriteLine("Opção digitada errada, favor escolher uma opção de 1 a 7");
                        break;
                }

                

            }

            Console.ReadKey();

        }
    }
}
