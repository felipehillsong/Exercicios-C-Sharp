using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Domain.ViewModels
{
    public class EstoqueProdutoViewModel
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; }
        public int FornecedorId { get; set; }
        public string FornecedorNome { get;set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set;}

        public EstoqueProdutoViewModel(int estoqueId, int empresaId, string empresaNome, int fornecedorId, string fornecedorNome, int produtoId, string produtoNome, int quantidade)
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
        public EstoqueProdutoViewModel()
        {
        }
    }

    public class EstoqueProdutoViewModelUpdate : EstoqueProdutoViewModel
    {      
        public EstoqueProdutoViewModelUpdate(int estoqueId, int empresaId, string empresaNome, int fornecedorId, string fornecedorNome, int produtoId, string produtoNome, int quantidade) : base(estoqueId, empresaId, empresaNome, fornecedorId, fornecedorNome, produtoId, produtoNome, quantidade)
        {
        }
        public EstoqueProdutoViewModelUpdate()
        {
        }
    }

    public class EstoqueViewModelEnderecoProduto : EstoqueProdutoViewModel
    {
        public int EnderecoProdutoId { get; set; }
        public string NomeEndereco { get; set; }
        public bool Ativo { get; set; }

        public EstoqueViewModelEnderecoProduto(int estoqueId, int empresaId, string empresaNome, int fornecedorId, string fornecedorNome, int produtoId, string produtoNome, int quantidade, int enderecoProdutoId, string nomeEndereco, bool ativo) : base(estoqueId, empresaId, empresaNome, fornecedorId, fornecedorNome, produtoId, produtoNome, quantidade)
        {
            this.EnderecoProdutoId = enderecoProdutoId;
            this.NomeEndereco = nomeEndereco;
            this.Ativo = ativo;  
        }

    }
}
