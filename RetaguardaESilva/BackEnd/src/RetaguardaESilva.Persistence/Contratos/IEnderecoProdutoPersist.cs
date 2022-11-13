using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Persistence.Contratos
{
    public interface IEnderecoProdutoPersist
    {
        Task<IEnumerable<EnderecoProduto>> GetAllEnderecosProdutosAsync(int empresaId);        
        Task<EnderecoProduto> GetEnderecoProdutoByIdAsync(int empresaId, int enderecoProdutoId);
        Task<EnderecoProduto> GetEnderecoProdutoByProdutoIdAsync(int empresaId, int produtoId);
    }
}