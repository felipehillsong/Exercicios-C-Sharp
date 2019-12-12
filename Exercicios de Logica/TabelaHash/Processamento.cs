using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaHash
{
    public class Processamento
    {
        public Dicionario dicionario { get; set; }

        public Processamento()
        {
            dicionario = new Dicionario();
        }

        public void Processar()
        {
            int n1;
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("******************************************");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------ESCOLHA SUA OPÇÃO-----------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("******************************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("|1| - Adicionar uma palavra ao dicionario");
                Console.WriteLine("|2| - Alterar alguma palavra do dicionario");
                Console.WriteLine("|3| - Deletar uma palavra do dicionario");
                Console.WriteLine("|4| - Pesquisar alguma palavra no dicionario");
                Console.WriteLine("|5| - Para listar todas as palavras do dicionario");
                Console.WriteLine("|6| - Sair");
                n1 = int.Parse(Console.ReadLine());

                switch (n1)
                {
                    case 1: Adicionar(); break;
                    case 2: Alterar(); break;
                    case 3: Deletar(); break;
                    case 4: Pesquisar(); break;
                    case 5: Listar(); break;
                    case 6: break;
                    default: Console.WriteLine("Opcao errada!"); break;
                }
                Console.ReadLine();
                Console.Clear();

            } while (n1 != 6);
        }

        public Dicionario Adicionar()
        {
            Console.WriteLine($"Insira uma palavra ");
            string palavra = Console.ReadLine();
            Console.WriteLine($"Insira a descrição da palavra {palavra}");
            string descricao = Console.ReadLine();
            dicionario.DicionarioIncluir(palavra, descricao);
            return dicionario;
        }

        public Dicionario Alterar()
        {
            Console.WriteLine($"Qual a palavra que deseja alterar:");
            string palavra = Console.ReadLine();
            dicionario.DicionarioAlterar(palavra);
            return dicionario;

        }

        public Dicionario Deletar()
        {
            Console.WriteLine("Qual palavra você quer deletar? ");
            string palavra = Console.ReadLine();
            dicionario.DicionarioExcluir(palavra);
            return dicionario;
        }

        public Dicionario Pesquisar()
        {
            Console.WriteLine("Qual palavra você deseja pesquisa?");
            string palavra = Console.ReadLine();
            dicionario.DicionarioPesquisar(palavra);
            return dicionario;

        }

        public Dicionario Listar()
        {
            dicionario.DicionarioPesquisarTudo();
            return dicionario;
        }
    }
}