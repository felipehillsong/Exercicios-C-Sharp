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
    }
}
