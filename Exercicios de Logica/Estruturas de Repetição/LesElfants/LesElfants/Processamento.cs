using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesElfants
{
    public class Processamento
    {
        Atleta atleta;

        public Processamento()
        {
            atleta = new Atleta();
            atleta.esporte = new Esporte();
        }

        public void Processar()
        {
            int resposta = 0;
            int idadeMediaHomem = 0;
            int idadeMediaMulher = 0;
            int homem = 0;
            int mulher = 0;
            int idadeAcumuladorH = 0;
            int idadeAcumuladorM = 0;
            float idadeMediaGeralH = 0;
            float idadeMediaGeralM = 0;
            int mulherVolei = 0;
            int mulherFutsal = 0;
            int mulherBasquete = 0;
            int totalMulheres = 0;
            double porcentagemMulher = 0;
            double totalMulheresBasquete = 0;
            int homensIdade = 0;
            int s = 0;

            Console.WriteLine("Deseja cadastrar quantos atletas? ");
            resposta = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o nome do Atleta: ");
            atleta.Nome = Console.ReadLine();

            Console.WriteLine($"Entre com o sexo do atleta {atleta.Nome}. (M)Masculino (F)Feminino: ");
            atleta.Sexo = (Console.ReadLine());

            if (atleta.Sexo == "M" || atleta.Sexo == "m")
            {
                Console.WriteLine($"Entre com a idade do atleta {atleta.Nome}: ");
                atleta.Idade = int.Parse(Console.ReadLine());
                idadeMediaHomem += atleta.Idade;

                if (atleta.Idade >= 25 && atleta.Idade <= 30)
                {
                    homensIdade += 1;
                }

                Console.WriteLine($"Entre com a modalidade esportiva do atleta {atleta.Nome}. (1)Volei (2)Basquete (3)Futsal: ");
                atleta.esporte.Modalidade = int.Parse(Console.ReadLine());

                idadeAcumuladorH += 1;
                homem += 1;
                atleta.Dados(atleta);
            }

            if (atleta.Sexo == "F" || atleta.Sexo == "f")
            {
                Console.WriteLine($"Entre com a idade do atleta {atleta.Nome}: ");
                atleta.Idade = int.Parse(Console.ReadLine());
                idadeMediaMulher += atleta.Idade;

                Console.WriteLine($"Entre com a modalidade esportiva do atleta {atleta.Nome}. (1)Volei (2)Basquete (3)Futsal: ");
                atleta.esporte.Modalidade = int.Parse(Console.ReadLine());

                switch (atleta.esporte.Modalidade)
                {
                    case 1:
                        mulherVolei += 1;
                        break;
                    case 2:
                        mulherBasquete += 1;
                        break;
                    case 3:
                        mulherFutsal += 1;
                        break;
                }
                idadeAcumuladorM += 1;
                mulher += 1;
                atleta.Dados(atleta);

            }

            s = 1;

            for (s = 2; s <= resposta; s++)
            {
                Console.WriteLine("Entre com o nome do Atleta: ");
                atleta.Nome = Console.ReadLine();

                Console.WriteLine($"Entre com o sexo do atleta {atleta.Nome}. (M)Masculino (F)Feminino: ");
                atleta.Sexo = (Console.ReadLine());

                if (atleta.Sexo == "M" || atleta.Sexo == "m")
                {
                    Console.WriteLine($"Entre com a idade do atleta {atleta.Nome}: ");
                    atleta.Idade = int.Parse(Console.ReadLine());
                    idadeMediaHomem += atleta.Idade;

                    if (atleta.Idade >= 25 && atleta.Idade <= 30)
                    {
                        homensIdade += 1;
                    }

                    Console.WriteLine($"Entre com a modalidade esportiva do atleta {atleta.Nome}. (1)Volei (2)Basquete (3)Futsal: ");
                    atleta.esporte.Modalidade = int.Parse(Console.ReadLine());

                    idadeAcumuladorH += 1;
                    homem += 1;
                    atleta.Dados(atleta);
                }

                if (atleta.Sexo == "F" || atleta.Sexo == "f")
                {
                    Console.WriteLine($"Entre com a idade do atleta {atleta.Nome}: ");
                    atleta.Idade = int.Parse(Console.ReadLine());
                    idadeMediaMulher += atleta.Idade;

                    Console.WriteLine($"Entre com a modalidade esportiva do atleta {atleta.Nome}. (1)Volei (2)Basquete (3)Futsal: ");
                    atleta.esporte.Modalidade = int.Parse(Console.ReadLine());

                    switch (atleta.esporte.Modalidade)
                    {
                        case 1:
                            mulherVolei += 1;
                            break;
                        case 2:
                            mulherBasquete += 1;
                            break;
                        case 3:
                            mulherFutsal += 1;
                            break;
                    }
                    idadeAcumuladorM += 1;
                    mulher += 1;
                    atleta.Dados(atleta);
                }

            }

            //MEDIA DE IDADE DOS HOMENS
            idadeMediaGeralH = idadeMediaHomem / idadeAcumuladorH;
            //MEDIA DE IDADE DAS MULHERES
            idadeMediaGeralM = idadeMediaMulher / idadeAcumuladorM;
            //TOTAL DE MULHERES QUE ESTAO MATRICULADAS EM CADA ESPORTE
            totalMulheres = mulherVolei + mulherBasquete + mulherFutsal;
            //SEPARA A QUANTIDADE DE MULHERES QUE ESTAO MATRICULADAS NO BASQUETE NA VARIAVEL totalMulheresBasquete
            totalMulheresBasquete = mulherBasquete;
            //FAZ O CALCULO DE PORCENTAGEM DE MULHERES QUE ESTAO MATRICULADAS NO BASQUETE EM RELAÇÃO AS OUTRAS MULHERES MATRICULADAS NOS OUTROS ESPORTES
            porcentagemMulher = (totalMulheresBasquete / totalMulheres) * 100;

            Console.WriteLine($"\n\nNumero de Homens: {homem}, Media de idade dos homens: {idadeMediaGeralH}");
            Console.WriteLine($"Numero de Mulheres: {mulher}, Media de idade das mulheres: {idadeMediaGeralM}");
            Console.WriteLine($"Porcentagem de mulheres matriculadas no basquete em relação ao número de mulheres matriculadas nos outros esportes: {porcentagemMulher}%");
            Console.WriteLine($"Numero de homens com a idade entre 25 e 30 anos: {homensIdade}");

        }

    }
}
