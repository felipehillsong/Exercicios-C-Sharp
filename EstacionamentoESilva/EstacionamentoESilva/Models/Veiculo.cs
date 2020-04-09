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
        [Required(ErrorMessage = "Marca Obrigatoria!", AllowEmptyStrings = false)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Placa Obrigatoria!", AllowEmptyStrings = false)]
        [Display(Name = "Placa")]
        public string Placa { get; set; }
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }
        [Required(ErrorMessage = "Cliente Obrigatorio!", AllowEmptyStrings = false)]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Servico Servico { get; set; }

    }
}