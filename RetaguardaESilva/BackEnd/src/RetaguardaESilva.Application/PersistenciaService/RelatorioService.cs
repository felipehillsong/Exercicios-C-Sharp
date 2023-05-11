using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Application.Helpers;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Mensagem;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Domain.ViewModels;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.PersistenciaService
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IRelatorioPersist _relatorioPersist;
        private readonly IMapper _mapper;

        public RelatorioService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IRelatorioPersist relatorioPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _relatorioPersist = relatorioPersist;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClienteDTO>> GetClientesAllAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (dataFinalConvertida < dataInicioConvertida)
                {
                    throw new Exception(MensagemDeErro.DataFinalMaiorFinal);
                }
                else
                {
                    var clientes = await _relatorioPersist.GetAllClientesAtivosInativosExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                    if (clientes == null)
                    {
                        throw new Exception(MensagemDeErro.ClienteNaoEncontrado);
                    }
                    else if (clientes.Count() == 0)
                    {
                        throw new Exception(MensagemDeErro.ClienteNaoEncontradoEmpresa);
                    }
                    else
                    {
                        var resultadoClientes = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                        return resultadoClientes;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   

        public async Task<IEnumerable<ClienteDTO>> GetClientesAtivoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var clientes = await _relatorioPersist.GetAllClientesAtivosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (clientes == null)
                {
                    throw new Exception(MensagemDeErro.ClienteAtivoNaoEncontrado);
                }
                else if (clientes.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ClienteAtivoNaoEncontrado);
                }
                else
                {
                    var resultadoClientes = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                    return resultadoClientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesInativoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var clientes = await _relatorioPersist.GetAllClientesInativosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (clientes == null)
                {
                    throw new Exception(MensagemDeErro.ClienteInativoNaoEncontrado);
                }
                else if (clientes.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ClienteInativoNaoEncontrado);
                }
                else
                {
                    var resultadoClientes = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                    return resultadoClientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesExcluidoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var clientes = await _relatorioPersist.GetAllClientesExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (clientes == null)
                {
                    throw new Exception(MensagemDeErro.ClienteExcluidoNaoEncontrado);
                }
                else if (clientes.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ClienteExcluidoNaoEncontrado);
                }
                else
                {
                    var resultadoClientes = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                    return resultadoClientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorDTO>> GetFornecedoresAllAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (dataFinalConvertida < dataInicioConvertida)
                {
                    throw new Exception(MensagemDeErro.DataFinalMaiorFinal);
                }
                else
                {
                    var fornecedores = await _relatorioPersist.GetAllFornecedoresAtivosInativosExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorDTO>> GetFornecedoresAtivoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var fornecedores = await _relatorioPersist.GetAllFornecedoresAtivosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (fornecedores == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorAtivoNaoEncontrado);
                }
                else if (fornecedores.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorAtivoNaoEncontrado);
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

        public async Task<IEnumerable<FornecedorDTO>> GetFornecedoresInativoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var fornecedores = await _relatorioPersist.GetAllFornecedoresInativosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (fornecedores == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorInativoNaoEncontrado);
                }
                else if (fornecedores.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorInativoNaoEncontrado);
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

        public async Task<IEnumerable<FornecedorDTO>> GetFornecedoresExcluidoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var fornecedores = await _relatorioPersist.GetAllFornecedoresExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (fornecedores == null)
                {
                    throw new Exception(MensagemDeErro.ClienteInativoNaoEncontrado);
                }
                else if (fornecedores.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ClienteInativoNaoEncontrado);
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

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresProdutosAllAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresProdutosAllAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresProdutosAtivoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresProdutosAtivoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresProdutosInativoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresProdutosInativoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresProdutosExcluidoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresProdutosExcluidoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresInativosProdutosAllAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresInativosProdutosAllAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresInativosProdutosAtivoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresInativosProdutosAtivoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresInativosProdutosInativoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresInativosProdutosInativoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresInativosProdutosExcluidoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresInativosProdutosExcluidoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresExcluidosProdutosAllAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresExcluidosProdutosAllAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresExcluidosProdutosAtivoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresExcluidosProdutosAtivoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresExcluidosProdutosInativoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresExcluidosProdutosInativoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<FornecedorProdutoRelatorioDTO>> GetFornecedoresExcluidosProdutosExcluidoAsync(int empresaId)
        {
            try
            {
                var fornecedoresProdutos = await _relatorioPersist.GetFornecedoresExcluidosProdutosExcluidoAsync(empresaId);
                if (fornecedoresProdutos == null)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else if (fornecedoresProdutos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FornecedorProdutoNaoEncontrado);
                }
                else
                {
                    var resultadoFornecedores = _mapper.Map<IEnumerable<FornecedorProdutoRelatorioDTO>>(fornecedoresProdutos);
                    return resultadoFornecedores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
