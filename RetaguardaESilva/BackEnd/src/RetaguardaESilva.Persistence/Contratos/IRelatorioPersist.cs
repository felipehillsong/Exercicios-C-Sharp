using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Persistence.Contratos
{
    public interface IRelatorioPersist
    {
        Task<IEnumerable<Cliente>> GetAllClientesAtivosInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Cliente>> GetAllClientesAtivosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Cliente>> GetAllClientesInativosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<Cliente>> GetAllClientesExcluidosAsync(int empresaId, DateTime dataInicio, DateTime dataFinal);
    }
}