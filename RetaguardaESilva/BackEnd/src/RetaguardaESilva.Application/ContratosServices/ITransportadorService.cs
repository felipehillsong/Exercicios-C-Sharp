using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface ITransportadorService
    {
        Task<TransportadorDTO> AddTransportador(TransportadorCreateDTO model);
        Task<TransportadorDTO> UpdateTransportador(int empresaId, int transportadorId, TransportadorUpdateDTO model);
        Task<bool> DeleteTransportador(int empresaId, int transportadorId);
        Task<IEnumerable<TransportadorDTO>> GetAllTransportadoresAsync(int empresaId);
        Task<TransportadorDTO> GetTransportadorByIdAsync(int empresaId, int transportadorId);
    }
}
