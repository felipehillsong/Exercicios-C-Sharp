﻿using Microsoft.EntityFrameworkCore;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Contratos;
using RetaguardaESilva.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Persistence.Persistencias
{
    public class PedidoNotaPersist : IPedidoNotaPersist
    {
        private readonly RetaguardaESilvaContext _context;
        public PedidoNotaPersist(RetaguardaESilvaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PedidoNota>> GetAllPedidosNotaAsync(int empresaId, int produtoId)
        {
            return await _context.PedidoNota.AsNoTracking().Where(pn => pn.EmpresaId == empresaId && pn.ProdutoId == produtoId).OrderBy(p => p.EmpresaId).ToListAsync();
        }
    }
}