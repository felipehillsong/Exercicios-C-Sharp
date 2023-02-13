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
    public class PedidoService : IPedidoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IClientePersist _clientePersist;
        private readonly IMapper _mapper;

        public PedidoService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IClientePersist clientePersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _clientePersist = clientePersist;
            _mapper = mapper;
        }
        public async Task<ClienteCreateDTO> AddCliente(ClienteCreateDTO model)
        {
            try
            {
                if (_validacoesPersist.ExisteCliente(model.EmpresaId, model.CPFCNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, model.Id, false, out string mensagem))
                {
                    throw new Exception(mensagem);
                }
                else
                {
                    model.Ativo = Convert.ToBoolean(Situacao.Ativo);
                    var clienteCreateDTO = _mapper.Map<Cliente>(model);
                    clienteCreateDTO.Nome = _validacoesPersist.AcertarNome(clienteCreateDTO.Nome);
                    _geralPersist.Add<Cliente>(clienteCreateDTO);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        var retornoCliente = await _clientePersist.GetClienteByIdAsync(clienteCreateDTO.EmpresaId, clienteCreateDTO.Id);
                        return _mapper.Map<ClienteCreateDTO>(retornoCliente);
                    }
                    throw new Exception(mensagem);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteUpdateDTO> UpdateCliente(ClienteUpdateDTO model)
        {           
            try
            { 
                var cliente = await _clientePersist.GetClienteByIdAsync(model.EmpresaId, model.Id);
                if (cliente == null)
                {
                    throw new Exception(MensagemDeErro.ClienteNaoEncontradoUpdate);
                }
                else
                {
                    if (_validacoesPersist.ExisteCliente(model.EmpresaId, model.CPFCNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, model.Id, true, out string mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {   
                        var clienteUpdateDTO = _mapper.Map<Cliente>(model);
                        clienteUpdateDTO.Nome = _validacoesPersist.AcertarNome(clienteUpdateDTO.Nome);
                        _geralPersist.Update(clienteUpdateDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var retornoCliente = await _clientePersist.GetClienteByIdAsync(clienteUpdateDTO.EmpresaId, clienteUpdateDTO.Id);
                            return _mapper.Map<ClienteUpdateDTO>(retornoCliente);
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

        public async Task<bool> DeleteCliente(int empresaId, int clienteId)
        {
            try
            {
                var cliente = await _clientePersist.GetClienteByIdAsync(empresaId, clienteId);
                if (cliente == null)
                {
                    throw new Exception(MensagemDeErro.ClienteNaoEncontradoDelete);
                }
                else
                {
                    _geralPersist.Delete<Cliente>(cliente);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllClientesAsync(int empresaId)
        {            
            try
            {
                var clientes = await _clientePersist.GetAllClientesAsync(empresaId);                
                if (clientes == null)
                {
                    throw new Exception(MensagemDeErro.ClienteNaoEncontrado);
                }
                else if(clientes.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.ClienteNaoEncontradoEmpresa);
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

        public async Task<ClienteDTO> GetClienteByIdAsync(int empresaId, int clienteId)
        {
            try
            {
                var cliente = await _clientePersist.GetClienteByIdAsync(empresaId, clienteId);
                if (cliente == null)
                {                    
                    throw new Exception(MensagemDeErro.ClienteNaoEncontrado);
                }
                else
                {
                    var resultadoCliente = _mapper.Map<ClienteDTO>(cliente);
                    return resultadoCliente;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<PedidoCreateDTO> AddPedido(PedidoCreateDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoUpdateDTO> UpdatePedido(PedidoUpdateDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePedido(int empresaId, int pedidoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidoDTO>> GetAllPedidosAsync(int empresaId)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDTO> GetPedidoByIdAsync(int empresaId, int pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
