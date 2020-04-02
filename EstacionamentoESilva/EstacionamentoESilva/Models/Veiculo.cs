using EstacionamentoESilva.Acesso;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstacionamentoESilva.Models
{
    public class Veiculo
    {
        [Key]
        public int VeiculoId { get; set; }

        public string Marca { get; set; }

        public string Placa { get; set; }

        public string Observacoes { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Cliente")]

        public string CarroPlaca { get { return string.Format("{0} - {1}", Marca, Placa); } }

        public virtual Cliente Cliente { get; set; }

        public virtual Servico ServicoHorista { get; set; }

    }
}