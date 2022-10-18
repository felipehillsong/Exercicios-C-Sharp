using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface IFuncionarioService
    {
        Task<FuncionarioDTO> AddFuncionario(FuncionarioCreateDTO model);
        Task<FuncionarioDTO> UpdateFuncionario(int empresaId, int funcionarioId, FuncionarioUpdateDTO model);
        Task<bool> DeleteFuncionario(int empresaId, int funcionarioId);
        Task<IEnumerable<FuncionarioDTO>> GetAllFuncionariosAsync(int empresaId);
        Task<FuncionarioDTO> GetFuncionarioByIdAsync(int empresaId, int funcionarioId);
        Task<FuncionarioDTO> GetFuncionarioByIdLoginAsync(int funcionarioId);
    }
}
