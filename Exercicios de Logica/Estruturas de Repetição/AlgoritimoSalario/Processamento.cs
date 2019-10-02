using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritimoSalario
{
    public class Processamento
    {
        public void Processar()
        {
            string nome;
            double horasTrabalhadas = 0;   
            double salarioHora = 0;
            int sexo = 0;
            double s = 0;
            double maiorSalario = 0;
            double menorSalario = 0;
            double salarioFinal = 0;
            double resultadoSalario = 0;
            string nomes = "";
            string nomeMenor;
            string nomeMaior;

            Funcionario funcionario = new Funcionario();

            Console.WriteLine("Entre com a quantidade de funcionários");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o nome do funcionário: ");
            nome = Console.ReadLine();

            Console.WriteLine("Entre com as horas trabalhadas do funcionário(a): ");
            horasTrabalhadas = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o valor por hora do funcionário(a): ");
            salarioHora = double.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o sexo do funcionário(a), (1)Masculino (2)Feminino: ");
            sexo = int.Parse(Console.ReadLine());

            funcionario.Dados(nome, horasTrabalhadas, salarioHora, sexo);

            salarioFinal = horasTrabalhadas * salarioHora;
           
            //TAMBEM ARMAZENA O NOME NAS VARIAVEIS ABAIXO
            nomeMenor = nome;
            nomeMaior = nome;
            
            //TAMBEM ARMAZENA O VALOR DO SALARIO NAS VARIAVEIS ABAIXO
            maiorSalario = salarioFinal;
            menorSalario = salarioFinal;

            //A VARIAVEL resultadoSalario RECEBE A SOMA DOS SALARIOS, MAS NESSE CASO CONTEM APENAS 1 SALARIO
            //POIS AINDA NAO ENTROU NO FOR
            resultadoSalario += salarioFinal;

            s = 1;

            for (s = 2; s <= quantidade; s++)
            {
                Console.WriteLine("Entre com o nome do funcionário: ");
                nome = Console.ReadLine();

                Console.WriteLine("Entre com as horas trabalhadas do funcionário(a): ");
                horasTrabalhadas = int.Parse(Console.ReadLine());

                Console.WriteLine("Entre com o valor por hora do funcionário(a): ");
                salarioHora = double.Parse(Console.ReadLine());

                Console.WriteLine("Entre com o sexo do funcionário(a), (1)Masculino (2)Feminino: ");
                sexo = int.Parse(Console.ReadLine());

                funcionario.Dados(nome, horasTrabalhadas, salarioHora, sexo);
             
                salarioFinal = horasTrabalhadas * salarioHora;

                //COMO A VARIAVEL resultadoSalario JA ARMAZENOU O PRIMEIRO SALARIO ANTES DO FOR, ELE IRA
                //CONTINUAR ARMAZENDO, SENDO ESSE O SEGUNDO SALARIO
                resultadoSalario += salarioFinal;

                //A VARIAVEL nomes RECEBE OS NOMES DIGITADOS PELO USUARIO, NAO PRECISA USAR +=
                nomes = nome;

                //AQUI FARA A COMPARAÇÃO DOS SALARIOS
                if (salarioFinal < menorSalario)
                {
                    menorSalario = salarioFinal;
                    nomeMenor = nomes;
                }
                if (salarioFinal > maiorSalario)
                {
                    maiorSalario = salarioFinal;
                    nomeMaior = nomes;
                }                
            }

            Console.WriteLine("O salário total dos funcionários é: "+ resultadoSalario);
            Console.WriteLine("O  menor salario é: " + menorSalario);
            Console.WriteLine("O  maior salario é: "+ maiorSalario);
            Console.WriteLine("O funcionário que contem o menor salário que é " + menorSalario + " é o(a): " + nomeMenor);
            Console.WriteLine("O funcionário que contem o maior salário que é "+maiorSalario +" é o(a): "+ nomeMaior);
            






        }
    }
}
