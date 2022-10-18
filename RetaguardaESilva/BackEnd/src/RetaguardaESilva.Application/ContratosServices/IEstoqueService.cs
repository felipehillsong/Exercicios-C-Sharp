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
        Task<Estoque> AddEstoque(int empresaId, Estoque model);
        Task<Estoque> UpdateEstoque(int empresaId, int estoqueId, Estoque model);
        Task<bool> DeleteEstoque(int empresaId, int estoqueId);
        Task<IEnumerable<Estoque>> GetAllEstoquesAsync(int empresaId);
        Task<Estoque> GetEstoqueByIdAsync(int empresaId, int estoqueId);
    }
}
