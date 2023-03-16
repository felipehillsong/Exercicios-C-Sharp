﻿using System;
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

    public class PedidoRetornoViewModel : PedidoViewModel
    {
        public string ClienteNome { get; set; }
        public string TransportadorNome { get; set; }
        public List<ProdutoViewModel> Produtos { get; set; }
        public string StatusPedido { get; set; }
        public PedidoRetornoViewModel()
        {

        }

        public PedidoRetornoViewModel(int id, string clienteNome, decimal precoTotal, DateTime? dataCadastroPedido, string statusPedido, int status)
        {
            this.Id = id;
            this.ClienteNome = clienteNome;
            this.PrecoTotal = precoTotal;
            this.DataCadastroPedido = dataCadastroPedido;
            this.Status = status;
            this.StatusPedido = statusPedido;
        }
        public PedidoRetornoViewModel(int id, int clienteId, string clienteNome, int transportadorId, string transportadorNome, int empresaId, int usuarioId, decimal precoTotal, DateTime? dataCadastroPedido, int status, List<ProdutoViewModel> produtos)
        {
            this.Id = id;
            this.ClienteId = clienteId;
            this.ClienteNome = clienteNome;
            this.TransportadorId = transportadorId;
            this.TransportadorNome = transportadorNome;
            this.EmpresaId = empresaId;
            this.UsuarioId = usuarioId;
            this.PrecoTotal = precoTotal;
            this.DataCadastroPedido = dataCadastroPedido;
            this.Status = status;
            this.Produtos = produtos;
        }
    }   
}
