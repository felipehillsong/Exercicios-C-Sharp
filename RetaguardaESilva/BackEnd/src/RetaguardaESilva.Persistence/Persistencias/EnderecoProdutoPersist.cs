using Microsoft.EntityFrameworkCore;
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
    public class EnderecoProdutoPersist : IEnderecoProdutoPersist
    {
        private readonly RetaguardaESilvaContext _context;
        public EnderecoProdutoPersist(RetaguardaESilvaContext context)
        {
            _context = context;            
        }

        public async Task<IEnumerable<EnderecoProduto>> GetAllEnderecosProdutosAsync(int empresaId)
        {
            return await _context.EnderecoProduto.AsNoTracking().Where(ep => ep.EmpresaId == empresaId).OrderBy(ep => ep.Id).ToListAsync();            
        }      

        public async Task<EnderecoProduto> GetEnderecoProdutoByIdAsync(int empresaId, int enderecoProdutoId)
        {
            return await _context.EnderecoProduto.AsNoTracking().Where(ep => ep.Id == enderecoProdutoId && ep.EmpresaId == empresaId).FirstOrDefaultAsync();
        }

        public async Task<EnderecoProduto> GetEnderecoProdutoByProdutoIdAsync(int empresaId, int produtoId)
        {
            return await _context.EnderecoProduto.AsNoTracking().Where(ep => ep.ProdutoId == produtoId && ep.EmpresaId == empresaId).FirstOrDefaultAsync();
        }
    }
}
