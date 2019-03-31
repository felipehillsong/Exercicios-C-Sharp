using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Escolha um operador numerico: ");
            string operador = Console.ReadLine();
            if (operador == "+") {
                LogSoma();               
            } else if (operador == "-") {
                LogSubtracao();
            } else if (operador == "*") {
                LogMultiplicacao();
            } else if (operador == "/") {
                LogDivisao();
            } else {
                Console.WriteLine("ERRO!");
            }

        }       

        public static void LogSoma() {
            string nomeArquivo = @"C:\Users\Felipe\Desktop\logs\" + DateTime.Now.ToString("dd-MM-yyyy") + ".log.txt";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("Soma: " +(Soma(0, 0)));
            writer.Close();
        }

        public static void LogSubtracao() {
            string nomeArquivo = @"C:\Users\Felipe\Desktop\logs\" + DateTime.Now.ToString("dd-MM-yyyy") + ".log.txt";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("Subtração: " + Subtracao(0, 0));
            writer.Close();
        }

        public static void LogMultiplicacao() {
            string nomeArquivo = @"C:\Users\Felipe\Desktop\logs\" + DateTime.Now.ToString("dd-MM-yyyy") + ".log.txt";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("Multiplicação: " + Multiplicacao(0, 0));
            writer.Close();
        }

        public static void LogDivisao() {
            string nomeArquivo = @"C:\Users\Felipe\Desktop\logs\" + DateTime.Now.ToString("dd-MM-yyyy") + ".log.txt";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("Divisão: " + Divisao(0, 0));
            writer.Close();
        }



        public static int Soma(int x, int y) {            
            Console.WriteLine("Entre com o primeiro numero: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o segundo numero: ");
            y = int.Parse(Console.ReadLine());
            int resultdado = x + y;
            Console.WriteLine("O resultado é: " + resultdado + " e foi salvo no arquivo de log");
            return resultdado;
        }
        


        public static int Subtracao(int x, int y) {
            Console.WriteLine("Entre com o primeiro numero: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o segundo numero: ");
            y = int.Parse(Console.ReadLine());
            int resultdado = x - y;
            Console.WriteLine("O resultado é: " + resultdado + " e foi salvo no arquivo de log");
            return resultdado;
        }

        public static int Multiplicacao(int x, int y) {
            Console.WriteLine("Entre com o primeiro numero: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o segundo numero: ");
            y = int.Parse(Console.ReadLine());
            int resultdado = x * y;
            Console.WriteLine("O resultado é: " + resultdado + " e foi salvo no arquivo de log");
            return resultdado;
        }

        public static int Divisao(int x, int y) {
            Console.WriteLine("Entre com o primeiro numero: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o segundo numero: ");
            y = int.Parse(Console.ReadLine());
            int resultdado = x / y;
            Console.WriteLine("O resultado é: " + resultdado + " e foi salvo no arquivo de log");
            return resultdado;
        }        
        
    }
}