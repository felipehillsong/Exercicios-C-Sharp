using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaHash
{
    public class Dicionario
    {
        public string palavra { get; set; }
        public string descricao { get; set; }
        public Hashtable dicionario { get; set; }

        public Dicionario()
        {
            dicionario = new Hashtable();

        }

        public Hashtable DicionarioIncluir(string palavra, string descricao)
        {
            dicionario[palavra] = descricao;
            return dicionario;
        }

        public Hashtable DicionarioAlterar(string palavra)
        {
            int resposta = 0;
            string novaDescricao = "";
            var dicionarioCheio = dicionario;
            if (dicionarioCheio.ContainsKey(palavra))
            {
                Console.WriteLine($"Tem certeza que deseja alterar a descrição da palavra {palavra}? (1)SIM ou (2)NÃO!");
                resposta = int.Parse(Console.ReadLine());
                if (resposta == 1)
                {
                    Console.WriteLine($"Entre com a nova descrição da palavra {palavra}!");
                    novaDescricao = Console.ReadLine();
                    dicionario[palavra] = novaDescricao;
                }
                if (resposta == 2)
                {
                    Console.WriteLine("Voltando ao dicionario!");
                }
                if (resposta != 1 && resposta != 2)
                {
                    Console.WriteLine("Opção inexistente, favor escolher (1)para SIM ou (2) para NÃO. Voltando para o dicionario!");
                }

            }
            else
            {
                Console.WriteLine($"A palavra {palavra} não existe no dicionario, favor procurar outra");
            }

            return dicionarioCheio;
        }

        public Hashtable DicionarioExcluir(string palavra)
        {
            int resposta = 0;
            var dicionarioCheio = dicionario;
            if (dicionarioCheio.ContainsKey(palavra))
            {
                Console.WriteLine($"Tem certeza que deseja excluir a palavra {palavra} e sua descrição do dicionario? (1)SIM ou (2)NÃO!");
                resposta = int.Parse(Console.ReadLine());
                if (resposta == 1)
                {
                    dicionarioCheio.Remove(palavra);
                    Console.WriteLine("Palavra e descrição excluidas com sucesso!");
                }
                if (resposta == 2)
                {
                    Console.WriteLine("Voltando ao dicionario!");
                }
                if (resposta != 1 && resposta != 2)
                {
                    Console.WriteLine("Opção inexistente, favor escolher (1)para SIM ou (2) para NÃO. Voltando para o dicionario!");
                }
            }
            else
            {
                Console.WriteLine($"A palavra {palavra} não existe no dicionario, favor procurar outra");
            }

            return dicionarioCheio;
        }

        public Hashtable DicionarioPesquisar(string palavra)
        {
            var dicionarioCheio = dicionario;
            if (dicionarioCheio.ContainsKey(palavra))
            {
                //peguei o valor da palavra dentro da variavel palavra
                string descricao = (string)dicionarioCheio[palavra];
                //exibe os valores da HashTable        
                Console.WriteLine("Palavra: {0}. Descrição: {1}", palavra, descricao);

            }
            else
            {
                Console.WriteLine($"A palavra {palavra} não existe no dicionario, favor procurar outra");
            }

            return dicionarioCheio;
        }

        public Hashtable DicionarioPesquisarTudo()
        {
            var dicionarioCheio = dicionario;

            foreach (DictionaryEntry palavras in dicionarioCheio)
            {
                //obtém os valores da HashTable usando Key e Value
                string palavra = (string)palavras.Key;
                string descricao = (string)palavras.Value;
                //exibe os valores da HashTable
                Console.WriteLine("Palavra: {0}. Descrição: {1}", palavra, descricao);
            }

            return dicionarioCheio;
        }


    }
}