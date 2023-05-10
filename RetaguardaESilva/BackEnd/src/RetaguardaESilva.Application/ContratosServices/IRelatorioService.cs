using RetaguardaESilva.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface IRelatorioService
    {
        Task<IEnumerable<ClienteDTO>> GetClientesAllAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<ClienteDTO>> GetClientesAtivoAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<ClienteDTO>> GetClientesInativoAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<ClienteDTO>> GetClientesExcluidoAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<FornecedorDTO>> GetFornecedoresAllAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<FornecedorDTO>> GetFornecedoresAtivoAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<FornecedorDTO>> GetFornecedoresInativoAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<FornecedorDTO>> GetFornecedoresExcluidoAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresProdutosAllAsync(int empresaId);
        Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresProdutosAtivoAsync(int empresaId);
        Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresProdutosInativoAsync(int empresaId);
        Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresProdutosExcluidoAsync(int empresaId);
    }
}
