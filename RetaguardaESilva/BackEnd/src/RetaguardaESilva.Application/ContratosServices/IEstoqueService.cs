using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface IEstoqueService
    {        
        Task<Estoque> UpdateEstoque(int empresaId, int estoqueId, EstoqueDTO model);
        Task<bool> DeleteEstoque(int empresaId, int estoqueId);
        Task<IEnumerable<Estoque>> GetAllEstoquesAsync(int empresaId);
        Task<Estoque> GetEstoqueByIdAsync(int empresaId, int estoqueId);
    }
}
