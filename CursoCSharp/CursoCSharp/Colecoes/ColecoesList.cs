using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.Colecoes
{
    public class Produto
    {
        public string Nome;
        public double Preco;

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }     

    }

    class ColecoesList
    {
        public static void Executar()
        {
            var livro = new Produto("Game of Thrones", 49.9);
            var dvd = new Produto("De volta para o futuro", 49.9);

            var carrinho = new List<Produto>();
            carrinho.Add(livro);
            carrinho.Add(dvd);

            var combo = new List<Produto>
            {
                new Produto("Camisa", 29.9),
                new Produto("8º Temporada Game of Thornes", 99.9),
                new Produto("Poster", 10),
                new Produto("Adesivo", 5)
            };

            carrinho.AddRange(combo);
            Console.WriteLine(carrinho.Count);
            carrinho.RemoveAt(3);

            foreach(var item in carrinho)
            {
                Console.WriteLine(carrinho.IndexOf(item));
                Console.WriteLine($"{item.Nome} {item.Preco}");
            }
                        
            
            
            
        }
    }
}