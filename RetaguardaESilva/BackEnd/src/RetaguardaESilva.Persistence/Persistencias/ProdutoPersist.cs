﻿using Microsoft.EntityFrameworkCore;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Data;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Persistence.Persistencias
{
    public class ProdutoPersist : IProdutoPersist
    {
        private readonly RetaguardaESilvaContext _context;
        public ProdutoPersist(RetaguardaESilvaContext context)
        {
            _context = context;            
        }

        public async Task<IEnumerable<Produto>> GetAllProdutosAsync(int empresaId)
        {
            return await _context.Produto.AsNoTracking().Where(p => p.EmpresaId == empresaId).OrderBy(p => p.EmpresaId).ToListAsync();            
        }            

        public async Task<Produto> GetProdutoByIdAsync(int empresaId, int produtoId)
        {
            return await _context.Produto.AsNoTracking().Where(p => p.Id == produtoId && p.EmpresaId == empresaId).OrderBy(p => p.Id).FirstOrDefaultAsync();
        }

        public async Task<Produto> GetProdutoByNomeAsync(int empresaId, string produtoNome)
        {
            return await _context.Produto.AsNoTracking().Where(p => p.Nome == produtoNome && p.EmpresaId == empresaId).OrderBy(p => p.Id).FirstOrDefaultAsync();
        }
    }
}