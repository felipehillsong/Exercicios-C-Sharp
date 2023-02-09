using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }
        public int TransportadorId { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataCadastroPedido { get; set; }
        public bool Ativo { get; set; }
    }
}
