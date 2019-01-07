using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CursoCSharp.API
{
    class Diretorios
    {
        public static void Executar()
        {
            var novoDir = @"~/PastaCSharp".ParseHome();
            var novoDestino = @"~PastaCSharpDestino".ParseHome();
            var dirProjeto = @"~/C:/Users/Felipe/Desktop/Projetos C#/CursoCSharp/CursoCSharp".ParseHome();

            if (Directory.Exists(novoDir))
            {
                Directory.Delete(novoDir, true);
            }

            if (Directory.Exists(novoDestino))
            {
                Directory.Delete(novoDestino, true);
            }

            Directory.CreateDirectory(novoDir);
            Console.WriteLine(Directory.GetCreationTime(novoDir));

            Console.WriteLine("==Pastas ==============");
            var pastas = Directory.GetDirectories(dirProjeto);
            foreach(var pasta in pastas)
            {
                Console.WriteLine(pasta);
            }
        }
    }
}
