using System;
using System.Collections.Generic;
using System.Text;

namespace CursoCSharp.API
{
    class Exemplo_DateTime
    {
        public static void Executar()
        {
            var dateTime = new DateTime(year: 1985, month: 10, day: 26);

            Console.WriteLine(dateTime.Day);
            Console.WriteLine(dateTime.Month);
            Console.WriteLine(dateTime.Year);

            //Sem horas

            var hoje = DateTime.Today;
            Console.WriteLine(hoje);

            //Com horas
            var diaAtual = DateTime.Now;
            Console.WriteLine(diaAtual);
            Console.WriteLine("Hora: " + diaAtual.Hour);
            Console.WriteLine("Minutos: " + diaAtual.Minute);
            Console.WriteLine("Segundos: " + diaAtual.Second);

            var amanha = diaAtual.AddDays(1);
            Console.WriteLine(amanha);

      
        }
    }
}
