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
using RetaguardaESilva.Persistence.Persistencias;
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
        private readonly IUsuarioPersist _usuarioPersist;
        private readonly IRelatorioPersist _relatorioPersist;
        private readonly IMapper _mapper;

        public RelatorioService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IRelatorioPersist relatorioPersist, IUsuarioPersist usuarioPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _usuarioPersist = usuarioPersist;
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

        public async Task<IEnumerable<FuncionarioDTO>> GetFuncionariosAllAsync(int empresaId, string dataIncio, string dataFinal)
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
                    var funcionarios = await _relatorioPersist.GetAllFuncionariosAtivosInativosExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                    if (funcionarios == null)
                    {
                        throw new Exception(MensagemDeErro.FuncionarioRelatorioNaoEncontrado);
                    }
                    else if (funcionarios.Count() == 0)
                    {
                        throw new Exception(MensagemDeErro.FuncionarioRelatorioNaoEncontrado);
                    }
                    else
                    {
                        var resultadoFuncionarios = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
                        return resultadoFuncionarios;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetFuncionariosAtivoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var funcionarios = await _relatorioPersist.GetAllFuncionariosAtivosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (funcionarios == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioRelatorioNaoEncontrado);
                }
                else if (funcionarios.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FuncionarioRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoFuncionarios = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
                    return resultadoFuncionarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetFuncionariosInativoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var funcionarios = await _relatorioPersist.GetAllFuncionariosInativosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (funcionarios == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioRelatorioNaoEncontrado);
                }
                else if (funcionarios.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FuncionarioRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoFuncionarios = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
                    return resultadoFuncionarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetFuncionariosExcluidoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var funcionarios = await _relatorioPersist.GetAllFuncionariosExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (funcionarios == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioRelatorioNaoEncontrado);
                }
                else if (funcionarios.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FuncionarioRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoFuncionarios = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
                    return resultadoFuncionarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransportadorDTO>> GetTransportadoresAllAsync(int empresaId, string dataIncio, string dataFinal)
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
                    var transportadores = await _relatorioPersist.GetAllTransportadoresAtivosInativosExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                    if (transportadores == null)
                    {
                        throw new Exception(MensagemDeErro.TransportadorRelatorioNaoEncontrado);
                    }
                    else if (transportadores.Count() == 0)
                    {
                        throw new Exception(MensagemDeErro.TransportadorRelatorioNaoEncontrado);
                    }
                    else
                    {
                        var resultadoTransportadores = _mapper.Map<IEnumerable<TransportadorDTO>>(transportadores);
                        return resultadoTransportadores;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransportadorDTO>> GetTransportadoresAtivoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var transportadores = await _relatorioPersist.GetAllFuncionariosAtivosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (transportadores == null)
                {
                    throw new Exception(MensagemDeErro.TransportadorRelatorioNaoEncontrado);
                }
                else if (transportadores.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.TransportadorRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoTransportadores = _mapper.Map<IEnumerable<TransportadorDTO>>(transportadores);
                    return resultadoTransportadores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransportadorDTO>> GetTransportadoresInativoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var transportadores = await _relatorioPersist.GetAllTransportadoresInativosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (transportadores == null)
                {
                    throw new Exception(MensagemDeErro.TransportadorRelatorioNaoEncontrado);
                }
                else if (transportadores.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.TransportadorRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoTransportadores = _mapper.Map<IEnumerable<TransportadorDTO>>(transportadores);
                    return resultadoTransportadores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransportadorDTO>> GetTransportadoresExcluidoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var transportadores = await _relatorioPersist.GetAllTransportadoresExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (transportadores == null)
                {
                    throw new Exception(MensagemDeErro.TransportadorRelatorioNaoEncontrado);
                }
                else if (transportadores.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.TransportadorRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoTransportadores = _mapper.Map<IEnumerable<TransportadorDTO>>(transportadores);
                    return resultadoTransportadores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuarioAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var usuarios = await _relatorioPersist.GetAllUsuariosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (usuarios == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioRelatorioNaoEncontrado);
                }
                else if (usuarios.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.UsuarioRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoUsuarios = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
                    foreach (var item in resultadoUsuarios)
                    {
                        item.Permissoes = await GetPermissao(item.EmpresaId, item.Id);
                    }
                    return resultadoUsuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDTO>> GetEmpresasAllAsync(int empresaId, string dataIncio, string dataFinal)
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
                    var empresas = await _relatorioPersist.GetAllEmpresasAtivosInativosExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                    if (empresas == null)
                    {
                        throw new Exception(MensagemDeErro.EmpresaRelatorioNaoEncontrado);
                    }
                    else if (empresas.Count() == 0)
                    {
                        throw new Exception(MensagemDeErro.EmpresaRelatorioNaoEncontrado);
                    }
                    else
                    {
                        var resultadoEmpresas = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);
                        return resultadoEmpresas;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDTO>> GetEmpresasAtivoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var empresas = await _relatorioPersist.GetAllEmpresasAtivosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (empresas == null)
                {
                    throw new Exception(MensagemDeErro.EmpresaRelatorioNaoEncontrado);
                }
                else if (empresas.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.EmpresaRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoEmpresas = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);
                    return resultadoEmpresas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDTO>> GetEmpresasInativoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var empresas = await _relatorioPersist.GetAllEmpresasInativosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (empresas == null)
                {
                    throw new Exception(MensagemDeErro.EmpresaRelatorioNaoEncontrado);
                }
                else if (empresas.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.EmpresaRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoEmpresas = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);
                    return resultadoEmpresas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDTO>> GetEmpresasExcluidoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var empresas = await _relatorioPersist.GetAllEmpresasExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (empresas == null)
                {
                    throw new Exception(MensagemDeErro.EmpresaRelatorioNaoEncontrado);
                }
                else if (empresas.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.EmpresaRelatorioNaoEncontrado);
                }
                else
                {
                    var resultadoEmpresas = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);
                    return resultadoEmpresas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosAllAsync(int empresaId, string dataIncio, string dataFinal)
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
                    var produtos = await _relatorioPersist.GetAllProdutosAtivosInativosExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                    if (produtos == null)
                    {
                        throw new Exception(MensagemDeErro.ProdutoRelatorioNaoEncontrado);
                    }
                    else if (produtos.Count() == 0)
                    {
                        throw new Exception(MensagemDeErro.ProdutoRelatorioNaoEncontrado);
                    }
                    else
                    {
                        var resultadoProdutos = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
                        return resultadoProdutos;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosAtivoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var produtos = await _relatorioPersist.GetAllProdutosAtivosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (produtos == null)
                {
                    throw new Exception(MensagemDeErro.ProdutoRelatorioNaoEncontrado);
                }
                else if (produtos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ProdutoRelatorioNaoEncontrado);
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

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosInativoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var produtos = await _relatorioPersist.GetAllProdutosInativosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (produtos == null)
                {
                    throw new Exception(MensagemDeErro.ProdutoRelatorioNaoEncontrado);
                }
                else if (produtos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ProdutoRelatorioNaoEncontrado);
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

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosExcluidoAsync(int empresaId, string dataIncio, string dataFinal)
        {
            try
            {
                DateTime dataInicioConvertida = DateTime.ParseExact(dataIncio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dataFinalConvertida = DateTime.ParseExact(dataFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var produtos = await _relatorioPersist.GetAllProdutosExcluidosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
                if (produtos == null)
                {
                    throw new Exception(MensagemDeErro.ProdutoRelatorioNaoEncontrado);
                }
                else if (produtos.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ProdutoRelatorioNaoEncontrado);
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

        public async Task<List<PermissaoDTO>> GetPermissao(int empresaId, int usuarioId)
        {
            try
            {
                var usuarioPermissao = await _usuarioPersist.GetPermissaoUsuarioByIdAsync(empresaId, usuarioId);
                var usuarioExistente = await _usuarioPersist.GetUsuarioByIdAsync(empresaId, usuarioId);
                if (usuarioExistente == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioNaoEncontrado);
                }
                else
                {
                    var retornoPermissao = new List<PermissaoDTO>();
                    if (usuarioPermissao == null)
                    {
                        var PermissaoDTOMapper = new PermissaoDTO()
                        {
                            Id = (int)Ids.IdCreate,
                            VisualizarCliente = false,
                            ClienteCadastro = false,
                            ClienteEditar = false,
                            ClienteDetalhe = false,
                            ClienteExcluir = false,
                            VisualizarEmpresa = false,
                            EmpresaCadastro = false,
                            EmpresaEditar = false,
                            EmpresaDetalhe = false,
                            EmpresaExcluir = false,
                            VisualizarEstoque = false,
                            EstoqueEditar = false,
                            EstoqueDetalhe = false,
                            EstoqueExcluir = false,
                            VisualizarEnderecoProduto = false,
                            EnderecoProdutoCadastro = false,
                            EnderecoProdutoEditar = false,
                            EnderecoProdutoDetalhe = false,
                            EnderecoProdutoExcluir = false,
                            VisualizarFornecedor = false,
                            FornecedorCadastro = false,
                            FornecedorEditar = false,
                            FornecedorDetalhe = false,
                            FornecedorExcluir = false,
                            VisualizarFuncionario = false,
                            FuncionarioCadastro = false,
                            FuncionarioEditar = false,
                            FuncionarioDetalhe = false,
                            FuncionarioExcluir = false,
                            VisualizarProduto = false,
                            ProdutoCadastro = false,
                            ProdutoEditar = false,
                            ProdutoDetalhe = false,
                            ProdutoExcluir = false,
                            GerarRelatorio = false,
                            VisualizarTransportador = false,
                            TransportadorCadastro = false,
                            TransportadorEditar = false,
                            TransportadorDetalhe = false,
                            TransportadorExcluir = false,
                            VisualizarUsuario = false,
                            UsuarioCadastro = false,
                            UsuarioEditar = false,
                            UsuarioPermissoes = false,
                            UsuarioExcluir = false,
                            VisualizarPedido = false,
                            PedidoCadastro = false,
                            PedidoEditar = false,
                            PedidoDetalhe = false,
                            PedidoExcluir = false,
                            VisualizarNotaFiscal = false,
                            NotaFiscalCadastro = false,
                            NotaFiscalGerarPDF = false,
                            NotaFiscalCancelar = false,
                            EmpresaId = usuarioExistente.EmpresaId,
                            UsuarioId = usuarioExistente.Id
                        };
                        var resultadoPermissao = _mapper.Map<PermissaoDTO>(PermissaoDTOMapper);
                        retornoPermissao.Add(resultadoPermissao);
                        return retornoPermissao;
                    }
                    else
                    {
                        var PermissaoDTOMapper = new PermissaoDTO()
                        {
                            Id = usuarioPermissao.Id,
                            VisualizarCliente = usuarioPermissao.VisualizarCliente,
                            ClienteCadastro = usuarioPermissao.ClienteCadastro,
                            ClienteEditar = usuarioPermissao.ClienteEditar,
                            ClienteDetalhe = usuarioPermissao.ClienteDetalhe,
                            ClienteExcluir = usuarioPermissao.ClienteExcluir,
                            VisualizarEmpresa = usuarioPermissao.VisualizarEmpresa,
                            EmpresaCadastro = usuarioPermissao.EmpresaCadastro,
                            EmpresaEditar = usuarioPermissao.EmpresaEditar,
                            EmpresaDetalhe = usuarioPermissao.EmpresaDetalhe,
                            EmpresaExcluir = usuarioPermissao.EmpresaExcluir,
                            VisualizarEstoque = usuarioPermissao.VisualizarEstoque,
                            EstoqueEditar = usuarioPermissao.EstoqueEditar,
                            EstoqueDetalhe = usuarioPermissao.EstoqueDetalhe,
                            EstoqueExcluir = usuarioPermissao.EstoqueExcluir,
                            VisualizarEnderecoProduto = usuarioPermissao.VisualizarEnderecoProduto,
                            EnderecoProdutoCadastro = usuarioPermissao.EnderecoProdutoCadastro,
                            EnderecoProdutoEditar = usuarioPermissao.EnderecoProdutoEditar,
                            EnderecoProdutoDetalhe = usuarioPermissao.EnderecoProdutoDetalhe,
                            EnderecoProdutoExcluir = usuarioPermissao.EnderecoProdutoExcluir,
                            VisualizarFornecedor = usuarioPermissao.VisualizarFornecedor,
                            FornecedorCadastro = usuarioPermissao.FornecedorCadastro,
                            FornecedorEditar = usuarioPermissao.FornecedorEditar,
                            FornecedorDetalhe = usuarioPermissao.FornecedorDetalhe,
                            FornecedorExcluir = usuarioPermissao.FornecedorExcluir,
                            VisualizarFuncionario = usuarioPermissao.VisualizarFuncionario,
                            FuncionarioCadastro = usuarioPermissao.FuncionarioCadastro,
                            FuncionarioEditar = usuarioPermissao.FuncionarioEditar,
                            FuncionarioDetalhe = usuarioPermissao.FuncionarioDetalhe,
                            FuncionarioExcluir = usuarioPermissao.FuncionarioExcluir,
                            VisualizarProduto = usuarioPermissao.VisualizarProduto,
                            ProdutoCadastro = usuarioPermissao.ProdutoCadastro,
                            ProdutoEditar = usuarioPermissao.ProdutoEditar,
                            ProdutoDetalhe = usuarioPermissao.ProdutoDetalhe,
                            ProdutoExcluir = usuarioPermissao.ProdutoExcluir,
                            GerarRelatorio = usuarioPermissao.GerarRelatorio,
                            VisualizarTransportador = usuarioPermissao.VisualizarTransportador,
                            TransportadorCadastro = usuarioPermissao.TransportadorCadastro,
                            TransportadorEditar = usuarioPermissao.TransportadorEditar,
                            TransportadorDetalhe = usuarioPermissao.TransportadorDetalhe,
                            TransportadorExcluir = usuarioPermissao.TransportadorExcluir,
                            VisualizarUsuario = usuarioPermissao.VisualizarUsuario,
                            UsuarioCadastro = usuarioPermissao.UsuarioCadastro,
                            UsuarioEditar = usuarioPermissao.UsuarioEditar,
                            UsuarioPermissoes = usuarioPermissao.UsuarioPermissoes,
                            UsuarioExcluir = usuarioPermissao.UsuarioExcluir,
                            VisualizarPedido = usuarioPermissao.VisualizarPedido,
                            PedidoCadastro = usuarioPermissao.PedidoCadastro,
                            PedidoEditar = usuarioPermissao.PedidoEditar,
                            PedidoDetalhe = usuarioPermissao.PedidoDetalhe,
                            PedidoExcluir = usuarioPermissao.PedidoExcluir,
                            VisualizarNotaFiscal = usuarioPermissao.VisualizarNotaFiscal,
                            NotaFiscalCadastro = usuarioPermissao.NotaFiscalCadastro,
                            NotaFiscalGerarPDF = usuarioPermissao.NotaFiscalGerarPDF,
                            NotaFiscalCancelar = usuarioPermissao.NotaFiscalCancelar,
                            EmpresaId = usuarioPermissao.EmpresaId,
                            UsuarioId = usuarioPermissao.UsuarioId
                        };
                        var resultadoPermissao = _mapper.Map<PermissaoDTO>(PermissaoDTOMapper);
                        retornoPermissao.Add(resultadoPermissao);
                        return retornoPermissao;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
