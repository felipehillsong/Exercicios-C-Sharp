using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesElfants
{
    public class Atleta
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Sexo { get; set; }

        public Esporte esporte { get; set; }

        public Atleta Dados(Atleta atleta)
        {
            if (atleta.Sexo == "M" || atleta.Sexo == "m")
            {
                switch (esporte.Modalidade)
                {
                    case 1:
                        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, Sexo: Masculino, Esporte: Volei");
                        break;
                    case 2:
                        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, Sexo: Masculino, Esporte: Basquete");
                        break;
                    case 3:
                        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, Sexo: Masculino, Esporte: Futebol");
                        break;
                }


            }
            else if (atleta.Sexo == "F" || atleta.Sexo == "f")
            {
                switch (esporte.Modalidade)
                {
                    case 1:
                        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, Sexo: Feminino, Esporte: Volei");
                        break;
                    case 2:
                        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, Sexo: Feminino, Esporte: Basquete");
                        break;
                    case 3:
                        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, Sexo: Feminino, Esporte: Futebol");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, Esporte: {esporte.Modalidade}");
                Console.WriteLine($"Sexo do aleta {Nome} não informado, favor informar (M) para masculino, (F) para feminino");
            }

            return atleta;
        }

    }
}
