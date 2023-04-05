using RetaguardaESilva.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface INotaFiscalService
    {
        Task<NotaFiscalDTO> AddNotaFiscal(NotaFiscalDTO model);
        Task<NotaFiscalDTO> UpdateNotaFiscal(NotaFiscalDTO model);
        Task<bool> DeleteCliente(int empresaId, int notafiscalId);
        Task<IEnumerable<NotaFiscalDTO>> GetAllNotaFiscalAsync(int empresaId);
        Task<NotaFiscalDTO> GetNotaFiscalByIdAsync(int empresaId, int notaFiscalId);
        Task<NotaFiscalDTO> GetNotaFiscalPedidoByIdAsync(int empresaId, int pedidoId);
    }
}
