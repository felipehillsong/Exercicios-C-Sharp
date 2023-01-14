﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.DTO
{
    public class EstoqueDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public int FornecedorId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }

    public class EstoqueViewModelDTO
    {
        public int IdEmpresa { get; set; }
        public string EmpresaNome { get; set; }
        public int IdFornecedor { get; set; }
        public string FornecedorNome { get; set; }
        public int IdProduto { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }

        public EstoqueViewModelDTO(int idEmpresa, string empresaNome, int idFornecedor, string fornecedorNome, int idProduto, string produtoNome, int quantidade)
        {
            this.IdEmpresa = idEmpresa;
            this.EmpresaNome = empresaNome;
            this.IdFornecedor = idFornecedor;
            this.FornecedorNome = fornecedorNome;
            this.IdProduto = idProduto;
            this.ProdutoNome = produtoNome;
            this.Quantidade = quantidade;
        }
    }
}
