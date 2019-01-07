using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHerenca
{
    class Cachorro:Animal
    {        
        public void Mostrar()
        {
            Nome = "Luke";
            Raca = "Vira-Lata";
            Idade = 1;

            Console.WriteLine("Meu nome é " + Nome + " sou da raça " + Raca + " e tenho " + Idade + " ano");
        }
    }
}
