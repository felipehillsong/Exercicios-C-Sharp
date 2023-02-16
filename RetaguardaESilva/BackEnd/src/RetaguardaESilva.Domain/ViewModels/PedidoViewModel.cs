using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Domain.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TransportadorId { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime? DataCadastroPedido { get; set; }
        public int Status { get; set; }
    }
    public class PedidoRetornoViewModel
    {
        public int Id { get; set; }
        public string ClienteNome { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime? DataCadastroPedido { get; set; }
        public string Status { get; set; }
        public PedidoRetornoViewModel()
        {

        }
        public PedidoRetornoViewModel(int id, string clienteNome, decimal precoTotal, DateTime? dataCadastroPedido, string status)
        {
            this.Id = id;
            this.ClienteNome = clienteNome;
            this.PrecoTotal = precoTotal;
            this.DataCadastroPedido = dataCadastroPedido;
            this.Status = status;
        }
    }
}
