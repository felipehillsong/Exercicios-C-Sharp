using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_MVC.Models
{
    public abstract class Conta
    {
        protected int Numero { get; set; }

        protected double SaldoInicial { get; set; }

        protected double SaldoFinal { get; set; }

        public abstract int NumeroConta(int Numero);

        public abstract double SaldoComeco();

        public abstract double Deposito(double valorDeposito);

        public abstract double Saque(double valorSaque);
    }
}