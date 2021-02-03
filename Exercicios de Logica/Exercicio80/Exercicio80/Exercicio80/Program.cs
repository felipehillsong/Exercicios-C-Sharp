using System;
using System.Globalization;

namespace Exercicio80
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] datas = new string[10];
            datas[0] = "11/11/1950";
            datas[1] = "15/03/2000";
            datas[2] = "26/10/1985";
            datas[3] = "16/05/1936";
            datas[4] = "07/04/1948";
            datas[5] = "30/01/2006";
            datas[6] = "03/09/2020";
            datas[7] = "22/12/2012";
            datas[8] = "01/06/1995";
            datas[9] = "19/02/1915";    

            for (int i = 0; i < datas.Length; i++)
            {
                var dataFormatada = Convert.ToDateTime(datas[i]);
                Console.WriteLine(dataFormatada.ToString("dddd, dd MMMM, yyyy"));
            }            

            Console.ReadKey();
        }
    }
}
