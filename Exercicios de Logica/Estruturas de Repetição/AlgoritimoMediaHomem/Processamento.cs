using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritimoMediaHomem
{
    public class Processamento
    {
        public void Processar()
        {
            float somarH;         
            float somaH = 0;           
            int acumuladorH = 0;           
            float maiorAlturaH = 0;
            float menorAlturaH = 0;            
            int h = 0;          
            float alturaH = 0;
            float alturaM = 0;
            int sexo = 0;
            string nome;

            Usuario usuario = new Usuario();

            Console.WriteLine("Deseja informar quantas pessoas? ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o nome do usuario: ");
            nome = Console.ReadLine();

            Console.WriteLine("Entre com o sexo do usuario " + nome + ", (1)Masculino ou (2)Feminino");
            sexo = int.Parse(Console.ReadLine());

            if (sexo == 1)
            {
                Console.WriteLine("Entre com a altura do usuario " + nome);
                alturaH = float.Parse(Console.ReadLine());
                usuario.Dados(nome, alturaH, sexo);
                //PARA VER A MEDIA DE ALTURA
                somaH += alturaH;
                acumuladorH += 1;
                //PARA VER MAIOR E MENOR ALTURA
                maiorAlturaH = alturaH;
                menorAlturaH = alturaH;
                h = 1;
            }

            if (sexo == 2)
            {
                Console.WriteLine("Entre com a altura do usuario " + nome);
                alturaM = float.Parse(Console.ReadLine());
                usuario.Dados(nome, alturaM, sexo);               
            }


            for (h = 2; h <= quantidade; h++)
            {
                Console.WriteLine("Entre com o nome do usuario: ");
                nome = Console.ReadLine();

                Console.WriteLine("Entre com o sexo do usuario " + nome + ", (1)Masculino ou (2)Feminino");
                sexo = int.Parse(Console.ReadLine());

                if (sexo == 1)
                {
                    Console.WriteLine("Entre com a altura do usuario " + nome);
                    alturaH = float.Parse(Console.ReadLine());
                    usuario.Dados(nome, alturaH, sexo);
                    //PARA VER A MEDIA DE ALTURA
                    somaH += alturaH;
                    acumuladorH += 1;
                    //PARA VER MAIOR E MENOR ALTURA
                    if (alturaH < menorAlturaH)
                    {
                        menorAlturaH = alturaH;
                    }
                    if (alturaH > maiorAlturaH)
                    {
                        maiorAlturaH = alturaH;
                    }
                }

                if (sexo == 2)
                {
                    Console.WriteLine("Entre com a altura do usuario " + nome);
                    alturaM = float.Parse(Console.ReadLine());
                    usuario.Dados(nome, alturaM, sexo);                    
                }

            }

            somarH = somaH;
            float mediaH = somarH / acumuladorH;
            Console.WriteLine("A media da altura dos homens: " + mediaH);

            Console.WriteLine("A menor altura dos homens é: " + menorAlturaH);
            Console.WriteLine("A maior altura dos homens é: " + maiorAlturaH);          
        }

    }

}
