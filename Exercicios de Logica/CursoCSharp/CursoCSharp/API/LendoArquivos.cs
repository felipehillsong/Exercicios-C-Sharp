using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CursoCSharp.API
{
    class LendoArquivos
    {
        public static void Executar()
        {
            var anus = @"~/lendo_arquivos.txt".ParseHome();


            if (File.Exists(anus))
            {
                using (StreamWriter sw = File.AppendText(anus))
                {
                    sw.WriteLine("Produto;Preco;Qtde");
                    sw.WriteLine("Caneta Bic Preta;3.59;89");
                    sw.WriteLine("Borracha Branca;2.89;27");
                    sw.WriteLine("\n");
                }
            }

            try
            {
                using (StreamReader sr = new StreamReader(anus))
                {
                    var texto = sr.ReadToEnd();
                    Console.WriteLine(texto);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
