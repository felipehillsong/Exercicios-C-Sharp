using System;
using System.Collections;
using System.Text;

namespace CursoCSharp.Colecoes
{
    class CoelcoesStack
    {
        public static void Executar()
        {
            var pilha = new Stack();

            pilha.Push(3);
            pilha.Push("a");
            pilha.Push(true);
            pilha.Push(3.14f);

            foreach(var item in pilha)
            {
                Console.Write($"{item} ");

                Console.WriteLine($"\nPop: {pilha.Pop()}");

                
            }
        }
    }
}
