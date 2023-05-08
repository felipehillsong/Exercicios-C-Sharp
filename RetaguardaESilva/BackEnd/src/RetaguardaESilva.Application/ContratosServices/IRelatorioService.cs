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
        Task<IEnumerable<FornecedorProdutoDTO>> GetFornecedoresProdutosAllAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<FornecedorProdutoDTO>> GetFornecedoresProdutosAtivoAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<FornecedorProdutoDTO>> GetFornecedoresProdutosInativoAsync(int empresaId, string dataIncio, string dataFinal);
        Task<IEnumerable<FornecedorProdutoDTO>> GetFornecedoresProdutosExcluidoAsync(int empresaId, string dataIncio, string dataFinal);
    }
}
