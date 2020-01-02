using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaPenhaConfeccoes
{
    public class Cadastro
    {
        public int Numero { get; set; }

        public int Idade { get; set; }

        public string Sexo { get; set; }

        public string Experiencia { get; set; }

        public void Dados(Cadastro cadastro)
        {
            if (cadastro.Sexo == "M" || cadastro.Sexo == "m")
            {
                if (cadastro.Experiencia == "S" || cadastro.Experiencia == "s")
                {
                    Console.WriteLine($"Numero de inscrição: {Numero}. Idade: {Idade}. Sexo: Masculino. Experiência: Sim");
                }
                else if (cadastro.Experiencia == "N" || cadastro.Experiencia == "n")
                {
                    Console.WriteLine($"Numero de inscrição: {Numero}. Idade: {Idade}. Sexo: Masculino. Experiência: Não");
                }

            }
            else if (cadastro.Sexo == "F" || cadastro.Sexo == "f")
            {
                if (cadastro.Experiencia == "S" || cadastro.Experiencia == "s")
                {
                    Console.WriteLine($"Numero de inscrição: {Numero}. Idade: {Idade}. Sexo: Feminino. Experiência: Sim");
                }
                else if (cadastro.Experiencia == "N" || cadastro.Experiencia == "n")
                {
                    Console.WriteLine($"Numero de inscrição: {Numero}. Idade: {Idade}. Sexo: Feminino. Experiência: Não");
                }
            }
        }
    }
}
