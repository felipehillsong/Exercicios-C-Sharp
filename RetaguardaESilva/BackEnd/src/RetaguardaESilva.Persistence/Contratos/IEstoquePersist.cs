using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Persistence.Contratos
{
    public interface IEstoquePersist
    {
        //Vai trazer o estoque de todos os produtos cadastrados no banco, mas se incluir o cliente na busca, vai trazer apenas o estoque do cliente
        Task<IEnumerable<Estoque>> GetAllEstoqueClienteAsync(int empresaId);
        //Vai trazer o estoque geral de apenas um produto
        Task<Estoque> GetEstoqueByProdutoIdAsync(int empresaId, int produtoId);
        //Vai trazer o estoque por id
        Task<Estoque> GetEstoqueByIdAsync(int empresaId, int estoqueId);
        //Vai trazer o estoque por fornecedor
        Task<IEnumerable<Estoque>> GetEstoqueByFornecedorIdAsync(int empresaId, int fornecedorId);
    }
}