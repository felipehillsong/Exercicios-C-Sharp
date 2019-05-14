using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    class TotalizadorDeContas
    {
        public double valortotal { get; private set; }

        public void Soma(Conta conta)
        {
            valortotal += conta.Saldo;            
        }     
        
    }    
}
