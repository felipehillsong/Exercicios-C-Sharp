using ProAgil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository.IRepository
{
    public interface IProAgilRepository
    {
        //GERAL
        void Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //EVENTOS
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes);

        //PALESTRANTES
        Task<Evento[]> GetAllPalestranteAsyncByName(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllPalestranteAsync(int PalestranteId,bool includePalestrantes);        
    }
}
