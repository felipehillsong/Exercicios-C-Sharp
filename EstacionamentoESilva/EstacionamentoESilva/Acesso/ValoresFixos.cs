using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Acesso
{
    public struct ValoresFixos
    {
        private decimal Fracao { get; set; }

        private decimal Fracionamento { get; set; }

        private decimal Hora { get; set; }

        private decimal Dia { get; set; }

        private decimal Mes { get; set; }

        public decimal PrecoFracao()
        {
            return this.Fracao = 2.50M;
        }

        public decimal PrecoFracionamento()
        {
            return this.Fracionamento = 10M;
        }

        public decimal Horista()
        {
            return this.Hora = 8M;
        }

        public decimal Diarista()
        {
            return this.Hora = 60M;
        }

        public decimal Mensalista()
        {
            return this.Hora = 200M;
        }
    }
}