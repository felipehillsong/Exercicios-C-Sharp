using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Persistence.Contratos
{
    public interface IPedidoNotaPersist
    {
        Task<IEnumerable<PedidoNota>> GetAllPedidosNotaAsync(int empresaId, int produto);
    }
}
