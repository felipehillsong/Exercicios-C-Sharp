﻿using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> AddProduto(ProdutoCreateDTO model);
        Task<ProdutoDTO> UpdateProduto(int empresaId, int produtoId, ProdutoUpdateDTO model);
        Task<bool> DeleteProduto(int empresaId, int produtoId);
        Task<IEnumerable<ProdutoDTO>> GetAllProdutosAsync(int empresaId);
        Task<ProdutoDTO> GetProdutoByIdAsync(int empresaId, int produtoId);    
    }
}