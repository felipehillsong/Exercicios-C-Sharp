using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Models
{
    public class Servico
    {
        [Key]
        public int ServicoId { get; set; }

        public string NomeCliente { get; set; }

        public string Marca { get; set; }

        public string Placas { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime HoraEntrada { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime HoraSaida { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DiaEntrada { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DiaSaida { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime MesEntrada { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime MesSaida { get; set; }

    }
}