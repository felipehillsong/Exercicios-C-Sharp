﻿using RetaguardaESilva.Application.DTO;
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
        Task<EstoqueViewModelUpdateDTO> UpdateEstoque(int empresaId, int estoqueId, int quantidade);
        Task<bool> DeleteEstoque(int empresaId, int estoqueId);
        Task<IEnumerable<EstoqueViewModelDTO>> GetAllEstoquesAsync(int empresaId);
        Task<EstoqueViewModelUpdateDTO> GetEstoqueByIdAsync(int empresaId, int estoqueId);
    }
}
