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
                    var clientes = await _relatorioPersist.GetAllClientesAtivosInativosAsync(empresaId, dataInicioConvertida, dataFinalConvertida);
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
    }
}
