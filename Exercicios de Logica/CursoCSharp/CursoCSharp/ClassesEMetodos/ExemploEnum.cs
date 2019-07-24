using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.ClassesEMetodos
{
    public enum Genero { Acao, Aventura, Terror, Animacao, Comedia};

    public class Filme
    {
        public string Titulo;
        public Genero GeneroDoFilme;
    }

    class ExemploEnum
    {
        public static void Executar()
        {
            int id = (int)Genero.Animacao;
            Console.WriteLine(id);

            var filmèParaFamilia = new Filme();
            filmèParaFamilia.Titulo = "De volta para o futuro";
            filmèParaFamilia.GeneroDoFilme = Genero.Aventura;
            Console.WriteLine("{0} é {1}!", filmèParaFamilia.Titulo, filmèParaFamilia.GeneroDoFilme);
        }
    }
}
