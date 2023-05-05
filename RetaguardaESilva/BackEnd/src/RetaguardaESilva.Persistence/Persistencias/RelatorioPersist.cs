using Microsoft.EntityFrameworkCore;
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
    public class RelatorioPersist : IRelatorioPersist
    {
        private readonly RetaguardaESilvaContext _context;
        public RelatorioPersist(RetaguardaESilvaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAtivosInativosAsync(int empresaId)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId).OrderBy(c => c.EmpresaId).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesAtivosAsync(int empresaId)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.Ativo == Convert.ToBoolean(Situacao.Ativo)).OrderBy(c => c.EmpresaId).ToListAsync();
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesInativosAsync(int empresaId)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.Ativo == Convert.ToBoolean(Situacao.Inativo)).OrderBy(c => c.EmpresaId).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesExcluidosAsync(int empresaId)
        {
            return await _context.Cliente.AsNoTracking().Where(c => c.EmpresaId == empresaId && c.StatusExclusao == Convert.ToBoolean(Situacao.Excluido)).OrderBy(c => c.EmpresaId).ToListAsync();
        }

       
    }
}
