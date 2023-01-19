using AutoMapper;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Mensagem;
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
        private readonly IProdutoPersist _produtoPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IMapper _mapper;

        public EstoqueService(IGeralPersist geralPersist, IEstoquePersist estoquePersist, IProdutoPersist produtoPersist, IValidacoesPersist validacoesPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _estoquePersist = estoquePersist;
            _produtoPersist = produtoPersist;
            _validacoesPersist = validacoesPersist;
            _mapper = mapper;
        }

        public async Task<EstoqueViewModelUpdateDTO> UpdateEstoque(int empresaId, int estoqueId, int quantidade)
        {
            try
            {
                var estoque = await _estoquePersist.GetEstoqueByIdAsync(empresaId, estoqueId);
                var produto = await _produtoPersist.GetProdutoByIdAsync(empresaId, estoque.ProdutoId);
                if (estoque == null || produto == null)
                {
                    return null;
                }
                else
                {
                    estoque.Quantidade = quantidade;
                    _geralPersist.Update(estoque);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        produto.Quantidade = quantidade;
                        _geralPersist.Update(produto);
                        await _geralPersist.SaveChangesAsync();
                        var estoqueProduto = _validacoesPersist.RetornarProdutosEstoqueId(empresaId, estoqueId);
                        var estoqueProdutoRetorno = new EstoqueViewModelUpdateDTO(estoqueProduto.Id, estoqueProduto.EmpresaId, estoqueProduto.EmpresaNome, estoqueProduto.FornecedorId, estoqueProduto.FornecedorNome, estoqueProduto.ProdutoId, estoqueProduto.ProdutoNome, estoqueProduto.Quantidade);
                        return estoqueProdutoRetorno;
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

        public async Task<EstoqueViewModelUpdateDTO> GetEstoqueByIdAsync(int empresaId, int estoqueId)
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
                    var estoqueProduto = _validacoesPersist.RetornarProdutosEstoqueId(empresaId, estoqueId);
                    var estoqueProdutoRetorno = new EstoqueViewModelUpdateDTO(estoqueProduto.Id, estoqueProduto.EmpresaId, estoqueProduto.EmpresaNome, estoqueProduto.FornecedorId, estoqueProduto.FornecedorNome, estoqueProduto.ProdutoId, estoqueProduto.ProdutoNome, estoqueProduto.Quantidade);
                    return estoqueProdutoRetorno;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
