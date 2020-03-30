using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Models
{
    public class Servico
    {
        public int ServicoId { get; set; }

        public string NomeCliente { get; set; }

        public string Marca { get; set; }

        public string Placas { get; set; }

        public DateTime HoraEntrada { get; set; }

        public DateTime HoraSaida { get; set; }

        public DateTime MesEntrada { get; set; }

        public DateTime MesSaida { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Veiculo")]
        public int VeiculoId { get; set; }

        public virtual Veiculo Veiculo { get; set; }

        public virtual Veiculo Placa { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}