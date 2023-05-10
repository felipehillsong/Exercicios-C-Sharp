using Microsoft.EntityFrameworkCore;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Data;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetaguardaESilva.Domain.Enumeradores;

namespace RetaguardaESilva.Persistence.Persistencias
{
    public class FornecedorPersist : IFornecedorPersist
    {
        private readonly RetaguardaESilvaContext _context;
        public FornecedorPersist(RetaguardaESilvaContext context)
        {
            _context = context;
        }        

        public async Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync(int empresaId)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.EmpresaId == empresaId && f.StatusExclusao != Convert.ToBoolean(Situacao.Excluido)).OrderBy(f => f.Id).ToListAsync();
        }  

        public async Task<Fornecedor> GetFornecedorByIdAsync(int empresaId, int fornecedorId)
        {
            return await _context.Fornecedor.AsNoTracking().Where(f => f.Id == fornecedorId && f.EmpresaId == empresaId && f.StatusExclusao != Convert.ToBoolean(Situacao.Excluido)).OrderBy(f => f.Id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Estoque>> GetFornecedorByEstoqueAsync(int empresaId, int fornecedorId)
        {
            return await _context.Estoque.AsNoTracking().Where(e => e.FornecedorId == fornecedorId && e.EmpresaId == empresaId).OrderBy(f => f.Id).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetFornecedoresProdutosByIdAsync(int empresaId, int fornecedorId)
        {
            return await _context.Produto.AsNoTracking().Where(p => p.EmpresaId == empresaId && p.FornecedorId == fornecedorId).OrderBy(p => p.Id).ToListAsync();            
        }         
      
    }
}
