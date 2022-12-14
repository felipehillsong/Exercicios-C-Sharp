using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Data;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetaguardaESilva.Domain.Mensagem;
using RetaguardaESilva.Application.DTO;
using AutoMapper;
using RetaguardaESilva.Domain.Enumeradores;

namespace RetaguardaESilva.Application.PersistenciaService
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IProdutoPersist _produtoPersist;
        private readonly IEstoquePersist _estoquePersist;
        private readonly IMapper _mapper;

        public ProdutoService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IProdutoPersist produtoPersist, IEstoquePersist estoquePersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _produtoPersist = produtoPersist;
            _estoquePersist = estoquePersist;
            _mapper = mapper;
        }
        public async Task<ProdutoDTO> AddProduto(ProdutoCreateDTO model)
        {
            try
            {
                model.Nome = _validacoesPersist.AcertarNome(model.Nome);
                var produto = _validacoesPersist.ExisteProduto(model.EmpresaId, model.Nome, model.Preco, model.Codigo, out string mensagem);
                if (produto != null)
                {
                    var quantidade = model.Quantidade + produto.Quantidade;
                    var produtoDTOMapper = new ProdutoDTO()
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Quantidade = quantidade,
                        Ativo = Convert.ToBoolean(Situacao.Ativo),
                        Preco = produto.Preco,
                        Codigo = produto.Codigo,
                        DataCadastroProduto = produto.DataCadastroProduto,
                        EmpresaId = produto.EmpresaId,
                        FornecedorId = produto.FornecedorId
                    };
                    var produtoDTO = _mapper.Map<Produto>(produtoDTOMapper);
                    _geralPersist.Update(produtoDTO);
                    if (await _geralPersist.SaveChangesAsync())
                    {                        
                        var produtoRetorno = _produtoPersist.GetProdutoByIdAsync(produtoDTO.EmpresaId, produtoDTO.Id);
                        var estoqueProduto = _estoquePersist.GetEstoqueByProdutoIdAsync(produtoDTO.EmpresaId, produtoDTO.Id);
                        if (estoqueProduto != null)
                        {
                            var estoqueDTOMapper = new EstoqueDTO()
                            {
                                Id = estoqueProduto.Result.Id,
                                ProdutoId = produtoDTO.Id,
                                Quantidade = produtoDTO.Quantidade,
                                EmpresaId = produtoDTO.EmpresaId,
                                FornecedorId = produtoDTO.FornecedorId
                            };
                            var estoqueDTO = _mapper.Map<Estoque>(estoqueDTOMapper);
                            _geralPersist.Update<Estoque>(estoqueDTO);
                            if (await _geralPersist.SaveChangesAsync())
                            {
                                var retornoProduto = await _produtoPersist.GetProdutoByIdAsync(produtoDTO.EmpresaId, produtoDTO.Id);
                                return _mapper.Map<ProdutoDTO>(retornoProduto);
                            }
                            throw new Exception(MensagemDeErro.ErroAoAtualizarQuantidadeProdutoEstoque);
                        }
                        else
                        {
                            throw new Exception(MensagemDeErro.ErroAoAtualizarQuantidadeProdutoEstoque);
                        }
                    }
                    throw new Exception(MensagemDeErro.ErroAoAtualizarQuantidadeProduto);
                }
                else if (produto == null && mensagem == MensagemDeErro.EmpresaProdutoInexistente)
                {
                    throw new Exception(mensagem);
                }
                else if(produto == null && mensagem == MensagemDeSucesso.CadastrarOk)
                {
                    var produtoDTOMapper = new ProdutoDTO()
                    {
                        Id = (int)Ids.IdCreate,
                        Nome = model.Nome,
                        Quantidade = model.Quantidade,
                        Ativo = Convert.ToBoolean(Situacao.Ativo),
                        Preco = model.Preco,
                        Codigo = model.Codigo,
                        DataCadastroProduto = model.DataCadastroProduto,
                        EmpresaId = model.EmpresaId,
                        FornecedorId = model.FornecedorId
                    };
                    var produtoDTO = _mapper.Map<Produto>(produtoDTOMapper);
                    _geralPersist.Add<Produto>(produtoDTO);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        var produtoRetorno = _produtoPersist.GetProdutoByIdAsync(produtoDTO.EmpresaId, produtoDTO.Id);
                        var estoqueDTOMapper = new EstoqueDTO()
                        {
                            ProdutoId = produtoRetorno.Result.Id,
                            Quantidade = produtoRetorno.Result.Quantidade,
                            EmpresaId = produtoRetorno.Result.EmpresaId,
                            FornecedorId = produtoRetorno.Result.FornecedorId
                        };
                        var estoqueDTO = _mapper.Map<Estoque>(estoqueDTOMapper);
                        _geralPersist.Add<Estoque>(estoqueDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var retornoProduto = await _produtoPersist.GetProdutoByIdAsync(produtoDTO.EmpresaId, produtoDTO.Id);
                            return _mapper.Map<ProdutoDTO>(retornoProduto);
                        }
                        throw new Exception(MensagemDeErro.ErroAoCadastrarProduto);
                    }
                    throw new Exception(MensagemDeErro.ErroAoCadastrarProduto);
                }
                else
                {
                    throw new Exception(MensagemDeErro.ErroAoCadastrarProduto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO> UpdateProduto(int empresaId, int produtoId, ProdutoUpdateDTO model)
        {
            try
            {
                var produtoBanco = await _produtoPersist.GetProdutoByIdAsync(empresaId, produtoId);
                if (produtoBanco == null)
                {
                    throw new Exception(MensagemDeErro.ProdutoNaoEncontradoUpdate);
                }
                else
                {
                    model.Nome = _validacoesPersist.AcertarNome(model.Nome);
                    var produtoMapper = new Produto()
                    {
                        Id = produtoBanco.Id,
                        Nome = model.Nome,
                        Quantidade = model.Quantidade,
                        Ativo = model.Ativo,
                        Preco = model.Preco,
                        Codigo = model.Codigo,
                        DataCadastroProduto = model.DataCadastroProduto,
                        FornecedorId = model.FornecedorId,
                        EmpresaId = model.EmpresaId
                    };
                    var produto = _mapper.Map<Produto>(produtoMapper);
                    if (!_validacoesPersist.ExisteProdutoUpdate(produtoBanco, produto, out Produto produtoAtualizaQuantidade, out string mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {
                        if (mensagem == MensagemDeSucesso.AtualizarQuantidadeProduto && produtoAtualizaQuantidade != null)
                        {
                            produtoAtualizaQuantidade.Quantidade += produtoBanco.Quantidade;
                            var estoqueParaDelete = _estoquePersist.GetEstoqueByProdutoIdAsync(produto.EmpresaId, produto.Id);
                            _geralPersist.Update(produtoAtualizaQuantidade);
                            if (await _geralPersist.SaveChangesAsync())
                            {
                                var estoqueProduto = _estoquePersist.GetEstoqueByProdutoIdAsync(produtoAtualizaQuantidade.EmpresaId, produtoAtualizaQuantidade.Id);
                                var estoqueDTOMapper = new EstoqueDTO()
                                {
                                    Id = produtoAtualizaQuantidade.Id,
                                    ProdutoId = produtoAtualizaQuantidade.Id,
                                    Quantidade = produtoAtualizaQuantidade.Quantidade,
                                    EmpresaId = produtoAtualizaQuantidade.EmpresaId,
                                    FornecedorId = produtoAtualizaQuantidade.FornecedorId
                                };

                                var estoqueDTO = _mapper.Map<Estoque>(estoqueDTOMapper);
                                _geralPersist.Update<Estoque>(estoqueDTO);                                
                                if (await _geralPersist.SaveChangesAsync())
                                {
                                    await DeleteProduto(produto.EmpresaId, produto.Id);
                                    var estoqueDeletado = _estoquePersist.GetEstoqueByIdAsync(produto.EmpresaId, produto.Id);
                                    if (estoqueDeletado.Result == null)
                                    {                                        
                                        var retornoProduto = _produtoPersist.GetProdutoByIdAsync(produtoAtualizaQuantidade.EmpresaId, produtoAtualizaQuantidade.Id);
                                        var retornoProdutoMapper = new Produto()
                                        {
                                            Id = retornoProduto.Result.Id,
                                            Nome = retornoProduto.Result.Nome,
                                            Quantidade = retornoProduto.Result.Quantidade,
                                            Ativo = retornoProduto.Result.Ativo,
                                            Preco = retornoProduto.Result.Preco,
                                            Codigo = retornoProduto.Result.Codigo,
                                            DataCadastroProduto = retornoProduto.Result.DataCadastroProduto,
                                            EmpresaId = retornoProduto.Result.EmpresaId,
                                            FornecedorId = retornoProduto.Result.FornecedorId
                                        };
                                        return _mapper.Map<ProdutoDTO>(retornoProdutoMapper);
                                    }
                                    else
                                    {
                                        throw new Exception(MensagemDeErro.ErroAoDeletarEstoqueProduto);
                                    }
                                }
                                throw new Exception(MensagemDeErro.ErroAoAtualizarQuantidadeProduto);
                            }
                            else
                            {
                                throw new Exception(MensagemDeErro.ErroAoAtualizarQuantidadeProduto);
                            }
                        }
                        else
                        {
                            _geralPersist.Update(produto);
                            if (await _geralPersist.SaveChangesAsync())
                            {
                                var estoqueProduto = _estoquePersist.GetEstoqueByProdutoIdAsync(produto.EmpresaId, produto.Id);
                                var estoqueDTOMapper = new EstoqueDTO()
                                {
                                    Id = estoqueProduto.Result.Id,
                                    ProdutoId = produto.Id,
                                    Quantidade = produto.Quantidade,
                                    EmpresaId = produto.EmpresaId,
                                    FornecedorId = produto.FornecedorId
                                };
                                var estoqueDTO = _mapper.Map<Estoque>(estoqueDTOMapper);
                                _geralPersist.Update<Estoque>(estoqueDTO);
                                if (await _geralPersist.SaveChangesAsync())
                                {
                                    var retornoProduto = await _produtoPersist.GetProdutoByIdAsync(produto.EmpresaId, produto.Id);
                                    return _mapper.Map<ProdutoDTO>(retornoProduto);
                                }
                                throw new Exception(MensagemDeErro.ErroAoAtualizarQuantidadeProdutoEstoque);
                            }
                            throw new Exception(MensagemDeErro.ErroAoAtualizar);
                        }
                        throw new Exception(MensagemDeErro.ErroAoAtualizar);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduto(int empresaId, int produtoId)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(empresaId, produtoId);
                if (produto == null)
                {
                    throw new Exception(MensagemDeErro.ProdutoNaoEncontradoDelete);
                }
                else
                {
                    _geralPersist.Delete<Produto>(produto);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAllProdutosAsync(int empresaId)
        {
            try
            {
                var produtos = await _produtoPersist.GetAllProdutosAsync(empresaId);
                if (produtos == null)
                {
                    throw new Exception(MensagemDeErro.ProdutoNaoEncontrado);
                }
                else if (produtos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ProdutoNaoEncontradoEmpresa);
                }
                else
                {
                    var resultadoProdutos = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
                    return resultadoProdutos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO> GetProdutoByIdAsync(int empresaId, int produtoId)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(empresaId, produtoId);
                if (produto == null)
                {
                    throw new Exception(MensagemDeErro.ProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoProduto = _mapper.Map<ProdutoDTO>(produto);
                    return resultadoProduto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
