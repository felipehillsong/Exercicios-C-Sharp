using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CursoCSharp.Colecoes
{
    class ColecoesQueue
    {
        public static void Executar()
        {
            var fila = new Queue<string>();
            fila.Enqueue("Felipe");
            fila.Enqueue("Polyana");
            fila.Enqueue("Eny");

            Console.WriteLine(fila.Peek());
            Console.WriteLine(fila.Count);

            Console.WriteLine(fila.Dequeue());

            Console.WriteLine(fila.Count);

            foreach(var pessoa in fila)
            {
                Console.WriteLine(pessoa);
            }

            var salada = new Queue();
            salada.Enqueue(3);
            salada.Enqueue("Maçã");
            salada.Enqueue(true);
            salada.Enqueue(3.14);

            Console.WriteLine(salada.Contains("maçã"));
            Console.WriteLine(salada.Contains("Maçã"));
        }
    }
}
