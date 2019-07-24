using System;
using System.Globalization;//importar biblioteca de moeda mundial

namespace CursoCSharp.Fundamentos
{
    class FormatandoNumero
    {
        public static void Executar()
        {
            double valor = 15.175;

            Console.WriteLine(valor.ToString("F1"));//arredenda para 15.2
            Console.WriteLine(valor.ToString("C"));//coloca o R$ antes do valor
            Console.WriteLine(valor.ToString("P"));//multiplica por 100 e poe o %
            Console.WriteLine(valor.ToString("F2"));//mostra os numeros com duas casas decimais
            CultureInfo cultura = new CultureInfo("en-US");//comando para mostrar valor em dolar ou qualquer moeda que queira
            Console.WriteLine(valor.ToString("C0", cultura));//imprimi o valor acima

            int inteiro = 256;
            Console.WriteLine(inteiro.ToString("D10"));//mostra o numero com 10 caracteres = 0000000256

        }
    }
}
