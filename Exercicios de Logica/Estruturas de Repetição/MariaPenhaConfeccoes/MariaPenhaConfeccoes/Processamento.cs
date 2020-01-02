using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaPenhaConfeccoes
{
    public class Processamento
    {
        Cadastro cadastro;

        public Processamento()
        {
            cadastro = new Cadastro();
        }

        public void Processar()
        {
            int resposta = 0;
            int numeroHomens = 0;
            int numeroMulheres = 0;
            int experienciaHomemSim = 0;
            int experienciaHomemNao = 0;
            int experienciaMulherSim = 0;
            int experienciaMulherNao = 0;
            int experienciaHomemInferior = 0;
            int experienciaHomemSuperior = 0;
            int experienciaMulherSuperior = 0;
            int menorIdadeMulher = 0;
            int maiorIdadeMulher = 0;
            int idadeHomem = 0;
            double mediaExperienciaHomemSim = 0;
            double porcentagemHomem = 0;
            double totalHomens = 0;
            double totalExperienciaInferior = 0;
            int s = 0;

            Console.WriteLine("Deseja cadastrar quantos candidatos? ");
            resposta = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o numero de inscrição do candidato: ");
            cadastro.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine($"Entre com o sexo do candidato {cadastro.Numero}. (M)Masculino (F)Feminino: ");
            cadastro.Sexo = Console.ReadLine();

            if (cadastro.Sexo == "M" || cadastro.Sexo == "m")
            {
                Console.WriteLine("Possui experiencia na serviço? (S)Sim (N)Não:");
                cadastro.Experiencia = Console.ReadLine();

                if (cadastro.Experiencia == "S" || cadastro.Experiencia == "s")
                {
                    experienciaHomemSim += 1;

                    Console.WriteLine($"Entre com a idade do candidado {cadastro.Numero}: ");
                    cadastro.Idade = int.Parse(Console.ReadLine());

                    idadeHomem += cadastro.Idade;

                    if (cadastro.Idade <= 35)
                    {
                        experienciaHomemInferior += 1;
                    }
                    if (cadastro.Idade >= 36)
                    {
                        experienciaHomemSuperior += 1;
                    }
                }
                if (cadastro.Experiencia == "N" || cadastro.Experiencia == "n")
                {
                    Console.WriteLine($"Entre com a idade do candidado {cadastro.Numero}: ");
                    cadastro.Idade = int.Parse(Console.ReadLine());

                    experienciaHomemNao += 1;
                }

                numeroHomens += 1;
                cadastro.Dados(cadastro);
            }

            if (cadastro.Sexo == "F" || cadastro.Sexo == "f")
            {
                Console.WriteLine("Possui experiencia na serviço? (S)Sim (N)Não:");
                cadastro.Experiencia = Console.ReadLine();

                if (cadastro.Experiencia == "S" || cadastro.Experiencia == "s")
                {
                    experienciaMulherSim += 1;

                    Console.WriteLine($"Entre com a idade do candidado {cadastro.Numero}: ");
                    cadastro.Idade = int.Parse(Console.ReadLine());

                    if (cadastro.Idade >= 35)
                    {
                        experienciaMulherSuperior += 1;
                    }

                    menorIdadeMulher = cadastro.Idade;
                    maiorIdadeMulher = cadastro.Idade;

                }
                if (cadastro.Experiencia == "N" || cadastro.Experiencia == "n")
                {
                    Console.WriteLine($"Entre com a idade do candidado {cadastro.Numero}: ");
                    cadastro.Idade = int.Parse(Console.ReadLine());

                    experienciaMulherNao += 1;
                }
                numeroMulheres += 1;
                cadastro.Dados(cadastro);

            }

            s = 1;
            for (s = 2; s <= resposta; s++)
            {
                Console.WriteLine("Entre com o numero de inscrição do candidato: ");
                cadastro.Numero = int.Parse(Console.ReadLine());

                Console.WriteLine($"Entre com o sexo do candidato {cadastro.Numero}. (M)Masculino (F)Feminino: ");
                cadastro.Sexo = Console.ReadLine();

                if (cadastro.Sexo == "M" || cadastro.Sexo == "m")
                {
                    Console.WriteLine("Possui experiencia na serviço? (S)Sim (N)Não:");
                    cadastro.Experiencia = Console.ReadLine();

                    if (cadastro.Experiencia == "S" || cadastro.Experiencia == "s")
                    {
                        experienciaHomemSim += 1;

                        Console.WriteLine($"Entre com a idade do candidado {cadastro.Numero}: ");
                        cadastro.Idade = int.Parse(Console.ReadLine());

                        idadeHomem += cadastro.Idade;

                        if (cadastro.Idade <= 35)
                        {
                            experienciaHomemInferior += 1;
                        }
                        if (cadastro.Idade >= 36)
                        {
                            experienciaHomemSuperior += 1;
                        }
                    }
                    if (cadastro.Experiencia == "N" || cadastro.Experiencia == "n")
                    {
                        Console.WriteLine($"Entre com a idade do candidado {cadastro.Numero}: ");
                        cadastro.Idade = int.Parse(Console.ReadLine());

                        experienciaHomemNao += 1;
                    }

                    numeroHomens += 1;
                    cadastro.Dados(cadastro);
                }

                if (cadastro.Sexo == "F" || cadastro.Sexo == "f")
                {
                    Console.WriteLine("Possui experiencia na serviço? (S)Sim (N)Não:");
                    cadastro.Experiencia = Console.ReadLine();

                    if (cadastro.Experiencia == "S" || cadastro.Experiencia == "s")
                    {
                        experienciaMulherSim += 1;

                        Console.WriteLine($"Entre com a idade do candidado {cadastro.Numero}: ");
                        cadastro.Idade = int.Parse(Console.ReadLine());

                        if (cadastro.Idade >= 35)
                        {
                            experienciaMulherSuperior += 1;
                        }

                        if (cadastro.Idade < menorIdadeMulher)
                        {
                            menorIdadeMulher = cadastro.Idade;
                        }
                        if (cadastro.Idade > maiorIdadeMulher)
                        {
                            maiorIdadeMulher = cadastro.Idade;
                        }
                    }
                    if (cadastro.Experiencia == "N" || cadastro.Experiencia == "n")
                    {
                        experienciaMulherNao += 1;

                        Console.WriteLine($"Entre com a idade do candidado {cadastro.Numero}: ");
                        cadastro.Idade = int.Parse(Console.ReadLine());
                    }
                    numeroMulheres += 1;
                    cadastro.Dados(cadastro);

                }
            }

            mediaExperienciaHomemSim = idadeHomem / experienciaHomemSim;
            totalHomens = numeroHomens;
            totalExperienciaInferior = experienciaHomemInferior;
            porcentagemHomem = (totalExperienciaInferior / totalHomens) * 100;

            Console.WriteLine($"\nNumero total de homens: {numeroHomens}. Numero total de mulheres: {numeroMulheres}");
            Console.WriteLine($"Media dos homens com experiência de serviço: {mediaExperienciaHomemSim}");
            Console.WriteLine($"Numero de mulheres acima de 35 anos com experiencia no serviço: {experienciaMulherSuperior}");
            Console.WriteLine($"A menor idade das mulheres com experiencia no serviço: {menorIdadeMulher}");
            Console.WriteLine($"A porcentagem de homens que tem idade inferios a 35 anos e experiencia no serviço em ralação aos outros: {porcentagemHomem}%");


        }
    }
}