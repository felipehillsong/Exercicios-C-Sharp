using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.PersistenciaService
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEstoquePersist _estoquePersist;

        public EstoqueService(IGeralPersist geralPersist, IEstoquePersist estoquePersist)
        {
            _geralPersist = geralPersist;
            _estoquePersist = estoquePersist;
        }
        public async Task<Estoque> AddEstoque(int empresaId, Estoque model)
        {
            try
            {
                _geralPersist.Add<Estoque>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _estoquePersist.GetEstoqueByIdAsync(empresaId, model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Estoque> UpdateEstoque(int empresaId, int estoqueId, Estoque model)
        {
            try
            {
                var estoque = await _estoquePersist.GetEstoqueByIdAsync(empresaId, estoqueId);
                if (estoque == null)
                {
                    return null;
                }
                else
                {
                    _geralPersist.Update(model);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        model.Id = estoque.Id;
                        return await _estoquePersist.GetEstoqueByIdAsync(model.Id, empresaId);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEstoque(int empresaId, int estoqueId)
        {
            try
            {
                var estoque = await _estoquePersist.GetEstoqueByIdAsync(empresaId, estoqueId);
                if (estoque == null)
                {
                    throw new Exception("Estoque não encontrado para delete");
                }
                else
                {
                    _geralPersist.Delete<Estoque>(estoque);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Estoque>> GetAllEstoquesAsync(int empresaId)
        {
            try
            {
                var estoques = await _estoquePersist.GetAllEstoqueClienteAsync(empresaId);
                if (estoques == null)
                {
                    return null;
                }
                else
                {
                    return estoques;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public async Task<Estoque> GetEstoqueByIdAsync(int empresaId, int estoqueId)
        {
            try
            {
                var estoque = await _estoquePersist.GetEstoqueByIdAsync(empresaId, estoqueId);
                if (estoque == null)
                {
                    return null;
                }
                else
                {
                    return estoque;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
