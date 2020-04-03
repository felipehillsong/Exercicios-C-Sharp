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
        [Display(Name = "Cliente")]
        public string NomeCliente { get; set; }
        [Display(Name = "Marca")]
        public string Marca { get; set; }
        [Display(Name = "Placa")]
        public string Placas { get; set; }
        [Display(Name = "Hora da Entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:HH:mm}")]
        [Column(TypeName = "datetime2")]
        public DateTime HoraEntrada { get; set; }
        [Display(Name = "Hora da Saída")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:HH:mm}")]
        [Column(TypeName = "datetime2")]
        public DateTime HoraSaida { get; set; }
        [Display(Name = "Dia da Entrada")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:dd/MMMM}", ApplyFormatInEditMode = true)]
        public DateTime DiaEntrada { get; set; }
        [Display(Name = "Dia da Saída")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:dd/MMMM}", ApplyFormatInEditMode = true)]
        public DateTime DiaSaida { get; set; }
        [Display(Name = "Mês da Entrada")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:MMMMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MesEntrada { get; set; }
        [Display(Name = "Mês da Saída")]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:MMMMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MesSaida { get; set; }

    }
}