using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface IEnderecoProdutoService
    {
        Task<EnderecoProduto> AddEnderecoProduto(int empresaId, EnderecoProduto model);
        Task<EnderecoProduto> UpdateEnderecoProduto(int empresaId, int enderecoProdutoId, EnderecoProduto model);
        Task<bool> DeleteEnderecoProduto(int empresaId, int enderecoProdutoId);
        Task<IEnumerable<EnderecoProduto>> GetAllEnderecosProdutosAsync(int empresaId);
        Task<EnderecoProduto> GetEnderecoProdutoByIdAsync(int empresaId, int enderecoProdutoId);
        Task<EnderecoProduto> GetEnderecoProdutoByProdutoIdAsync(int empresaId, int produtoId);      
    }
}
