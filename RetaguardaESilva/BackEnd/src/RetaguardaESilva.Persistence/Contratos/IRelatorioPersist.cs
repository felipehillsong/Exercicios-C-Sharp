using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Persistence.Contratos
{
    public interface IRelatorioPersist
    {
        Task<IEnumerable<Cliente>> GetAllClientesAtivosInativosExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Cliente>> GetAllClientesAtivosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Cliente>> GetAllClientesInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Cliente>> GetAllClientesExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Fornecedor>> GetAllFornecedoresAtivosInativosExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Fornecedor>> GetAllFornecedoresAtivosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Fornecedor>> GetAllFornecedoresInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Fornecedor>> GetAllFornecedoresExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosAllAsync(int empresaId);
        Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosAtivoAsync(int empresaId);
        Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosInativoAsync(int empresaId);
        Task<IEnumerable<FornecedorProdutoViewModel>> GetFornecedoresProdutosExcluidoAsync(int empresaId);
    }
}