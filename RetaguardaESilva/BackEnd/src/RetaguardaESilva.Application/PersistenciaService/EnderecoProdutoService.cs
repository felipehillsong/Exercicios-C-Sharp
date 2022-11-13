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
    public class EnderecoProdutoService : IEnderecoProdutoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IEnderecoProdutoPersist _enderecoProdutoServicePersist;

        public EnderecoProdutoService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IEnderecoProdutoPersist enderecoProdutoServicePersist)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _enderecoProdutoServicePersist = enderecoProdutoServicePersist;
        }
        public async Task<EnderecoProduto> AddEnderecoProduto(int empresaId, EnderecoProduto model)
        {
            try
            {
                var endereco = await _validacoesPersist.ExisteEnderecoProduto(empresaId, model.NomeEndereco, false);
                if (endereco == true)
                {
                    throw new Exception("Endereço existente!");
                }
                else
                {
                    _geralPersist.Add<EnderecoProduto>(model);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        return await _enderecoProdutoServicePersist.GetEnderecoProdutoByIdAsync(empresaId, model.Id);
                    }
                    return null;
                }               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoProduto> UpdateEnderecoProduto(int empresaId, int enderecoProdutoId, EnderecoProduto model)
        {
            try
            {
                var enderecoProduto = await _enderecoProdutoServicePersist.GetEnderecoProdutoByIdAsync(empresaId, enderecoProdutoId);
                if (enderecoProduto == null)
                {
                    return null;
                }
                else
                {
                    if (await _validacoesPersist.ExisteEnderecoProduto(empresaId, model.NomeEndereco, true))
                    {
                        throw new Exception("Você esta tentando atualizar para um endereço existente!");
                    }
                    else
                    {
                        _geralPersist.Update(model);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            model.Id = enderecoProduto.Id;
                            return await _enderecoProdutoServicePersist.GetEnderecoProdutoByIdAsync(empresaId, model.Id);
                        }
                        return null;
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEnderecoProduto(int empresaId, int enderecoProdutoId)
        {
            try
            {
                var enderecoProduto = await _enderecoProdutoServicePersist.GetEnderecoProdutoByIdAsync(empresaId, enderecoProdutoId);
                if (enderecoProduto == null)
                {
                    throw new Exception("Endereço do produto não encontrado para delete");
                }
                else
                {
                    _geralPersist.Delete<EnderecoProduto>(enderecoProduto);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EnderecoProduto>> GetAllEnderecosProdutosAsync(int empresaId)
        {
            try
            {
                var enderecosProdutos = await _enderecoProdutoServicePersist.GetAllEnderecosProdutosAsync(empresaId);
                if (enderecosProdutos == null)
                {
                    return null;
                }
                else
                {
                    return enderecosProdutos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public async Task<EnderecoProduto> GetEnderecoProdutoByIdAsync(int empresaId, int enderecoProdutoId)
        {
            try
            {
                var enderecoProduto = await _enderecoProdutoServicePersist.GetEnderecoProdutoByIdAsync(empresaId, enderecoProdutoId);
                if (enderecoProduto == null)
                {
                    return null;
                }
                else
                {
                    return enderecoProduto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoProduto> GetEnderecoProdutoByProdutoIdAsync(int empresaId, int produtoId)
        {
            try
            {
                var enderecoProduto = await _enderecoProdutoServicePersist.GetEnderecoProdutoByProdutoIdAsync(empresaId, produtoId);
                if (enderecoProduto == null)
                {
                    return null;
                }
                else
                {
                    return enderecoProduto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      
    }
}
