﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Domain.ViewModels
{
    public class NotaFiscalViewModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string NomeCliente { get; set; }
        public int QuantidadeItens { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime? DataCadastroNotaFiscal { get; set; }
        public string Status { get; set; }

        public NotaFiscalViewModel()
        {
            
        }

        public NotaFiscalViewModel(int id, int pedidoId, string nomeCliente, int quantidadeItens, decimal precoTotal, DateTime? dataCadastroNotaFiscal, string status)
        {
            this.Id = id;
            this.PedidoId = pedidoId;
            this.NomeCliente = nomeCliente;
            this.QuantidadeItens = quantidadeItens;
            this.PrecoTotal = precoTotal;
            this.DataCadastroNotaFiscal = dataCadastroNotaFiscal;
            this.Status = status;
        }
    }
}
