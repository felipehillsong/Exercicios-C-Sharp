using System;

namespace Banco
{
    public class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; private set; }
        public Cliente Titular { get; set; }

        public virtual void Deposita(double valorDeposito)
        {
            this.Saldo += valorDeposito;
        }

        public virtual void Saca(double valorSaque)
        {
            this.Saldo -= valorSaque;
        }
    }
}