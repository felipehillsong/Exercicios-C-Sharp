using System;
using System.Collections.Generic;
using System.Text;


namespace Encapsulamento
{
    public class SubCelebridade
    {
        //Todos - public
        public string InfoPublica = "Tenho um instagram!";

        //herença - protected
        protected string CorDoOlho = "Verde";

        //mesmo projeto - assembry
        internal ulong NumeroCelular = 5531984927952;

        //herança - protected
        protected internal string JeitodeFalar = "Uso muitas girias";

        //mesma class ou herança no mesmo projeto(C#>=7.2)
        private protected string SegredoFamilia = "Vou votar no Bolsonaro!";

        //private é o padrão
        private bool UsoMuitoPhotoshop = true;

        public void MeusAcessos()
        {
            Console.WriteLine("SubCelebridade...");
            Console.WriteLine(InfoPublica);
            Console.WriteLine(CorDoOlho);
            Console.WriteLine(NumeroCelular);
            Console.WriteLine(JeitodeFalar);
            Console.WriteLine(UsoMuitoPhotoshop);

        }
    }
}
