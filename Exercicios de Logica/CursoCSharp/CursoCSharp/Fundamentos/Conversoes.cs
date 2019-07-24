using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.Fundamentos
{
    class Conversoes
    {
        public static void Executar()
        {
            int inteiro = 10;
            double quebrado = inteiro;
            Console.WriteLine(quebrado);//converteu int para double

            double nota = 9.7;
            int notaTruncada = (int)nota;
            Console.WriteLine(notaTruncada);//converteu double para int, ele arredondou para 9

            Console.WriteLine("Digite sua idade");
            string idadeString = Console.ReadLine();
            int idadeInteiro = int.Parse(idadeString);
            Console.WriteLine("Idade é: " + idadeInteiro);//converteu string para int

            idadeInteiro = Convert.ToInt32(idadeString);
            Console.WriteLine(idadeInteiro);//converteu tambem string para int





        }
    }
}
