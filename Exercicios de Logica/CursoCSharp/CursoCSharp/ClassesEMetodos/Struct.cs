using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.ClassesEMetodos
{
    interface Ponto
    {
        void MoverNaDiagonal(int delta);
    }

    struct Cooredenada: Ponto
    {
        public int X;
        public int Y;

        public Cooredenada(int x, int y)
        {
            X = x;
            Y = x;
        }

        public void MoverNaDiagonal(int delta)
        {
            X += delta;
            Y += delta;
        }

    }
    class ExemploStruct
    {
        public static void Executar()
        {
            Cooredenada cooredenadaInicial;
            cooredenadaInicial.X = 2;
            cooredenadaInicial.Y = 2;

            Console.WriteLine("Coordenada Inicial:");
            Console.WriteLine("X={0}", cooredenadaInicial.X);
            Console.WriteLine("Y={0}", cooredenadaInicial.Y);

            var cooredenadaFinal = new Cooredenada(x: 9, y: 1);
            cooredenadaFinal.MoverNaDiagonal(10);

            Console.WriteLine("Coordenada final:");
            Console.WriteLine("X={0}", cooredenadaFinal.X);
            Console.WriteLine("Y={0}", cooredenadaFinal.Y);
        }
    }
}