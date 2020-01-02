using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcursoJustica
{
    public class Candidato
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int GrauInstrucao { get; set; }

        public void Dados(Candidato candidato)
        {
            if (candidato.Sexo == "M" || candidato.Sexo == "m")
            {
                switch (candidato.GrauInstrucao)
                {
                    case 1:
                        Console.WriteLine($"O nome do candidato é: {Nome}, seu sexo é: Masculino e seu grau de instrução é: Segundo Grau Completo");
                        break;
                    case 2:
                        Console.WriteLine($"O nome do candidato é: {Nome}, seu sexo é: Masculino e seu grau de instrução é: Terceiro Grau Completo");
                        break;
                    default:
                        Console.WriteLine("Grau de instrução não especificado");
                        break;
                }

            }

            if (candidato.Sexo == "F" || candidato.Sexo == "f")
            {
                switch (candidato.GrauInstrucao)
                {
                    case 1:
                        Console.WriteLine($"O nome do candidato é: {Nome}, seu sexo é: Masculino e seu grau de instrução é: Segundo Grau Completo");
                        break;
                    case 2:
                        Console.WriteLine($"O nome do candidato é: {Nome}, seu sexo é: Masculino e seu grau de instrução é: Terceiro Grau Completo");
                        break;
                    default:
                        Console.WriteLine("Grau de instrução não especificado");
                        break;
                }

            }

        }

    }
}