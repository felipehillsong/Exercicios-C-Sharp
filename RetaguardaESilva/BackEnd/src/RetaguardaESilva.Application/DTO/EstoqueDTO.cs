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
    }
}
