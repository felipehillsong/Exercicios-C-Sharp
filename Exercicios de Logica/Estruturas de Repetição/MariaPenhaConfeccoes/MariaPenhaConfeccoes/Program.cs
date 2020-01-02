using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaPenhaConfeccoes
{
    class Program
    {
        static void Main(string[] args)
        {
            /*48. A MARIA DA PENHA CONFECÇÕES decidiu fazer um levantamento em relação
            aos 3823 candidatos que se apresentaram para preenchimento de vagas no seu
            quadro de funcionários. Supondo que você seja o programador responsável pelo
            programa deste levantamento, construa um algoritmo que:
            1º) Leia as 3823 fichas contendo, cada uma, os seguintes dados:
            a) número de inscrição do candidato
            b) idade
            c) sexo
            d) experiência no serviço (SIM ou NÃO).
            2º) Calcule:
            a) O número de candidatos do sexo feminino.
            b) O número de candidatos do sexo masculino.
            c) A idade média dos homens que já tem experiência no serviço.
            d) Porcentagem de homens que têm idade inferior a 35 anos e experiência no
            serviço.
            e) Número de mulheres que têm idade superior a 35 anos e experiência no serviço.
            f) A menor idade entre as mulheres que já tem experiência no serviço.
            3º) Imprima:
            a) O número de inscrição de cada mulher pertencente ao grupo descrito no item e.
            b) O que foi calculado em cada item acima especificado. */
            var processar = new Processamento();
            processar.Processar();
        }
    }
}