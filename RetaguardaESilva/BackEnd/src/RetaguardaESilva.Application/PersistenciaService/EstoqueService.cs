using AutoMapper;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Domain.ViewModels;
using RetaguardaESilva.Persistence.Contratos;
using RetaguardaESilva.Persistence.Persistencias;
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
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IMapper _mapper;

        public EstoqueService(IGeralPersist geralPersist, IEstoquePersist estoquePersist, IValidacoesPersist validacoesPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _estoquePersist = estoquePersist;
            _validacoesPersist = validacoesPersist;
            _mapper = mapper;
        }

        public async Task<Estoque> UpdateEstoque(int empresaId, int estoqueId, EstoqueDTO model)
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

        public async Task<IEnumerable<EstoqueViewModelDTO>> GetAllEstoquesAsync(int empresaId)
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
                    List<EstoqueViewModelDTO> EstoqueProdutoRetorno = new List<EstoqueViewModelDTO>();
                    var estoqueProduto = _validacoesPersist.RetornarProdutosEstoque(empresaId);
                    foreach (var produtoEstoque in estoqueProduto)
                    {
                        EstoqueProdutoRetorno.Add(new EstoqueViewModelDTO(produtoEstoque.Id, produtoEstoque.EmpresaId, produtoEstoque.EmpresaNome, produtoEstoque.FornecedorId, produtoEstoque.FornecedorNome, produtoEstoque.ProdutoId, produtoEstoque.ProdutoNome, produtoEstoque.Quantidade));
                    }
                    return EstoqueProdutoRetorno;
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
