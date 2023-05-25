using Microsoft.EntityFrameworkCore.Query.Internal;
using RetaguardaESilva.Domain.Models;
using System;
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
        public DateTime? DataCadastroEstoque { get; set; }
        public bool StatusExclusao { get; set; }
    }

    public class EstoqueViewModelDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; }
        public int FornecedorId { get; set; }
        public string FornecedorNome { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public int EnderecoProdutoId { get; set; }

        public EstoqueViewModelDTO(int estoqueId, int empresaId, string empresaNome, int fornecedorId, string fornecedorNome, int produtoId, string produtoNome, int quantidade)
        {
            this.Id = estoqueId;
            this.EmpresaId = empresaId;
            this.EmpresaNome = empresaNome;
            this.FornecedorId = fornecedorId;
            this.FornecedorNome = fornecedorNome;
            this.ProdutoId = produtoId;
            this.ProdutoNome = produtoNome;
            this.Quantidade = quantidade;
        }
        public EstoqueViewModelDTO(int estoqueId, int empresaId, string empresaNome, int fornecedorId, string fornecedorNome, int produtoId, string produtoNome, int quantidade, int enderecoProdutoId)
        {
            this.Id = estoqueId;
            this.EmpresaId = empresaId;
            this.EmpresaNome = empresaNome;
            this.FornecedorId = fornecedorId;
            this.FornecedorNome = fornecedorNome;
            this.ProdutoId = produtoId;
            this.ProdutoNome = produtoNome;
            this.Quantidade = quantidade;
            this.EnderecoProdutoId = enderecoProdutoId;
        }
    }

    public class EstoqueViewModelUpdateDTO : EstoqueViewModelDTO
    {
        public EstoqueViewModelUpdateDTO(int estoqueId, int empresaId, string empresaNome, int fornecedorId, string fornecedorNome, int produtoId, string produtoNome, int quantidade) : base(estoqueId, empresaId, empresaNome, fornecedorId, fornecedorNome, produtoId, produtoNome, quantidade)
        {
        }
    }
}
