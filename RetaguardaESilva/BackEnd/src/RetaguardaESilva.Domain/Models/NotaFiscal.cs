using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Domain.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int PedidoNotaId { get; set; }
        public int ClienteId { get; set; }
        public int EmpresaId { get; set; }
        public DateTime? DataCadastroNotaFiscal { get; set; }
        public bool Ativo { get; set; }
    }
}
