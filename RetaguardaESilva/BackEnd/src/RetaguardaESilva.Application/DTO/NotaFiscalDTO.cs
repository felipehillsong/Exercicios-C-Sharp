﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.DTO
{
    public class NotaFiscalDTO
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public int EmpresaId { get; set; }
        public int TransportadorId { get; set; }
        public int QuantidadeItens { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime? DataCadastroNotaFiscal { get; set; }
        public int Status { get; set; }
    }
}