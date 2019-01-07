using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHerenca
{
    class Gato:Animal
    {
        public void Mostrar2()
        {
            Nome = "Chitaro";
            Raca = "Vira-Lata";
            Idade = 2;

            Console.WriteLine("Meu nome é " + Nome + " sou da raça " + Raca + " e tenho " + Idade + " anos");
            

        }
    }
}
