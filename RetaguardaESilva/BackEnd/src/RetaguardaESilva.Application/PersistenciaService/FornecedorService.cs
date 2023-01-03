using AutoMapper;
using Newtonsoft.Json;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Application.Helpers;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Mensagem;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.PersistenciaService
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IFornecedorPersist _fornecedorPersist;        
        private readonly IMapper _mapper;

        public FornecedorService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IFornecedorPersist fornecedorPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _fornecedorPersist = fornecedorPersist;            
            _mapper = mapper;
        }
        public async Task<FornecedorDTO> AddFornecedor(FornecedorCreateDTO model)
        {
            try
            {   
                if (_validacoesPersist.ExisteFornecedor(model.EmpresaId, model.CNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, (int)Ids.IdCreate, false, out string mensagem))
                {
                    throw new Exception(mensagem);
                }
                else
                {
                    var fornecedorDTOMapper = new FornecedorDTO()
                    {
                        Id = (int)Ids.IdCreate,
                        Nome = model.Nome,
                        Endereco = model.Endereco,
                        Bairro = model.Bairro,
                        Numero = model.Numero,
                        Municipio = model.Municipio,
                        UF = model.UF,
                        Pais = model.Pais,
                        CEP = model.CEP,
                        Complemento = model.Complemento,
                        Telefone = model.Telefone,
                        Email = model.Email,
                        CNPJ = model.CNPJ,
                        InscricaoMunicipal = model.InscricaoMunicipal,
                        InscricaoEstadual = model.InscricaoEstadual,
                        DataCadastroFornecedor = model.DataCadastroFornecedor,
                        Ativo = Convert.ToBoolean(Situacao.Ativo),
                        EmpresaId = model.EmpresaId
                    };

                    var fornecedorDTO = _mapper.Map<Fornecedor>(fornecedorDTOMapper);
                    fornecedorDTO.Nome = _validacoesPersist.AcertarNome(fornecedorDTO.Nome);
                    _geralPersist.Add<Fornecedor>(fornecedorDTO);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        var retornoFornecedor = await _fornecedorPersist.GetFornecedorByIdAsync(fornecedorDTO.EmpresaId, fornecedorDTO.Id);
                        return _mapper.Map<FornecedorDTO>(retornoFornecedor);
                    }
                    throw new Exception(MensagemDeErro.ErroAoAtualizar);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FornecedorDTO> UpdateFornecedor(int empresaId, int fornecedorId, FornecedorUpdateDTO model)
        {
            try
            {                
                var fornecedor = await _fornecedorPersist.GetFornecedorByIdAsync(empresaId, fornecedorId);
                if (fornecedor == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorNaoEcontradoUpdate);
                }
                else
                {                    
                    if (_validacoesPersist.ExisteFornecedor(empresaId, model.CNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, fornecedorId, true, out string mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {         
                        var fornecedorDTOMapper = new FornecedorDTO()
                        {
                            Id = fornecedorId,
                            Nome = model.Nome,
                            Endereco = model.Endereco,
                            Bairro = model.Bairro,
                            Numero = model.Numero,
                            Municipio = model.Municipio,
                            UF = model.UF,
                            Pais = model.Pais,
                            CEP = model.CEP,
                            Complemento = model.Complemento,
                            Telefone = model.Telefone,
                            Email = model.Email,
                            CNPJ = model.CNPJ,
                            InscricaoMunicipal = model.InscricaoMunicipal,
                            InscricaoEstadual = model.InscricaoEstadual,
                            DataCadastroFornecedor = model.DataCadastroFornecedor,
                            Ativo = model.Ativo,
                            EmpresaId = empresaId
                        };

                        var fornecedorDTO = _mapper.Map<Fornecedor>(fornecedorDTOMapper);
                        fornecedorDTO.Nome = _validacoesPersist.AcertarNome(fornecedorDTO.Nome);
                        _geralPersist.Update<Fornecedor>(fornecedorDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var retornoFornecedor = await _fornecedorPersist.GetFornecedorByIdAsync(fornecedorDTO.EmpresaId, fornecedorDTO.Id);
                            return _mapper.Map<FornecedorDTO>(retornoFornecedor);
                        }
                        throw new Exception(mensagem);
                    }                   
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteFornecedor(int empresaId, int fornecedorId)
        {
            try
            {
                var fornecedor = await _fornecedorPersist.GetFornecedorByIdAsync(empresaId, fornecedorId);
                if (fornecedor == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorNaoEncontradoDelete);
                }
                else
                {
                    var fornecedorProduto = await GetFornecedoresProdutosByIdAsync(fornecedor.EmpresaId, fornecedor.Id);
                    if (fornecedorProduto != null)
                    {
                        foreach (var item in fornecedorProduto.ToList())
                        {
                            var zerarIdFornecedorProduto = new Produto()
                            {
                                Id = item.Id,
                                Nome = item.Nome,
                                Quantidade = item.Quantidade,
                                Ativo = item.Ativo,
                                PrecoVenda = item.PrecoVenda,
                                PrecoCompra = item.PrecoCompra,
                                Codigo = item.Codigo,
                                DataCadastroProduto = item.DataCadastroProduto,
                                EmpresaId = item.EmpresaId,
                                FornecedorId = (int)ZerarIdFornecedor.FornecedorId
                            };

                            _geralPersist.Update<Produto>(zerarIdFornecedorProduto);
                            await _geralPersist.SaveChangesAsync();
                        }
                    }

                    var fornecedorEstoque = _fornecedorPersist.GetFornecedorByEstoqueAsync(fornecedor.EmpresaId, fornecedor.Id);
                    if (fornecedorEstoque != null)
                    {
                        foreach (var item in fornecedorEstoque.Result.ToList())
                        {
                            var zerouFornecedorEstoque = new Estoque()
                            {
                                Id = item.Id,
                                EmpresaId = item.EmpresaId,
                                FornecedorId = (int)ZerarIdFornecedor.FornecedorId,
                                ProdutoId = item.ProdutoId,
                                Quantidade = item.Quantidade
                            };

                            _geralPersist.Update<Estoque>(zerouFornecedorEstoque);
                            await _geralPersist.SaveChangesAsync();
                        }
                    }

                    _geralPersist.Delete<Fornecedor>(fornecedor);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorDTO>> GetAllFornecedoresAsync(int empresaId)
        {
            try
            {
                var fornecedores = await _fornecedorPersist.GetAllFornecedoresAsync(empresaId);
                if (fornecedores == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorNaoEncontrado);
                }
                else if (fornecedores.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorNaoEncontradoEmpresa);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorDTO>>(fornecedores);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public async Task<FornecedorDTO> GetFornecedorByIdAsync(int empresaId, int fornecedorId)
        {
            try
            {
                var fornecedor = await _fornecedorPersist.GetFornecedorByIdAsync(empresaId, fornecedorId);
                if (fornecedor == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedor = _mapper.Map<FornecedorDTO>(fornecedor);
                    return resultadoFornecedor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Produto>> GetFornecedoresProdutosByIdAsync(int empresaId, int fornecedorId)
        {
            try
            {
                var produtosFornecedor = await _fornecedorPersist.GetFornecedoresProdutosByIdAsync(empresaId, fornecedorId);
                if (produtosFornecedor == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    return produtosFornecedor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
