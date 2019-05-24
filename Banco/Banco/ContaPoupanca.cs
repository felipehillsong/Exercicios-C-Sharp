using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    public class ContaPoupanca:Conta
    {
        public override void Saca(double valorSaque)
        {
            base.Saca(valorSaque + 0.10);
        }
    }
}
