using RetaguardaESilva.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface IPedidoService
    {
        Task<PedidoCreateDTO> AddPedido(PedidoCreateDTO model);
        Task<PedidoUpdateDTO> UpdatePedido(PedidoUpdateDTO model);
        Task<bool> DeletePedido(int empresaId, int pedidoId);
        Task<IEnumerable<PedidoRetornoDTO>> GetAllPedidosAsync(int empresaId);
        Task<PedidoDTO> GetPedidoByIdAsync(int empresaId, int pedidoId);
        Task<IEnumerable<ClientePedidoDTO>> GetAllClientesPedidoAsync(int empresaId);
    }
}
