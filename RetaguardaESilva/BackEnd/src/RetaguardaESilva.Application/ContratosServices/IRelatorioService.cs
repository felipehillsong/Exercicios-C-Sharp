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
        Task<IEnumerable<ClienteDTO>> GetClientesAllAsync(int empresaId);
        Task<IEnumerable<ClienteDTO>> GetClientesAtivoAsync(int empresaId);
        Task<IEnumerable<ClienteDTO>> GetClientesInativoAsync(int empresaId);
        Task<IEnumerable<ClienteDTO>> GetClientesExcluidoAsync(int empresaId);
    }
}
