using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Acesso
{
    public struct Valores
    {
        public decimal Hora { get; set; }

        public decimal Dia { get; set; }

        public decimal Mes { get; set; }

        public decimal Horista()
        {
           return this.Hora = 8;
        }

        public decimal Diarista()
        {
            return this.Hora = 50;
        }

        public decimal Mensalista()
        {
            return this.Hora = 180;
        }
    }
}