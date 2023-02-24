using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.DTO
{
    public class PedidoDTO
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

    public class PedidoCreateDTO : PedidoDTO
    {
        public List<ProdutoPedidoDTO> Produtos { get; set; }
        public List<string>? ProdutosSemEstoque { get; set; }
    }

    public class PedidoUpdateDTO : PedidoCreateDTO
    {

    }

    public class PedidoRetornoDTO
    {
        public int Id { get; set; }
        public string ClienteNome { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime? DataCadastroPedido { get; set; }
        public string Status { get; set; }
        public PedidoRetornoDTO()
        {

        }
        public PedidoRetornoDTO(int id, string clienteNome, decimal precoTotal, DateTime? dataCadastroPedido, string status)
        {
            this.Id = id;
            this.ClienteNome = clienteNome;
            this.PrecoTotal = precoTotal;
            this.DataCadastroPedido = dataCadastroPedido;
            this.Status = status;
        }
    }

    public class ClientePedidoDTO
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public ClientePedidoDTO(int id, string nome)
        {
            this.ClienteId = id;
            this.ClienteNome = nome;
        }
    }
}
