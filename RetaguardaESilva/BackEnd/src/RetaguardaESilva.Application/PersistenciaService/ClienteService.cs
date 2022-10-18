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
    public class ClienteService : IClienteService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IClientePersist _clientePersist;
        private readonly IMapper _mapper;

        public ClienteService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IClientePersist clientePersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _clientePersist = clientePersist;
            _mapper = mapper;
        }
        public async Task<ClienteDTO> AddCliente(ClienteCreateDTO model)
        {
            try
            {
                if (_validacoesPersist.ExisteCliente(model.EmpresaId, model.CPFCNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, (int)Ids.IdCreate, false, out string mensagem))
                {
                    throw new Exception(mensagem);
                }
                else
                {   
                    var clienteDTOMapper = new ClienteDTO()
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
                        CPFCNPJ = model.CPFCNPJ,
                        InscricaoMunicipal = model.InscricaoMunicipal,
                        InscricaoEstadual = model.InscricaoEstadual,
                        DataCadastroCliente = model.DataCadastroCliente,
                        Ativo = Convert.ToBoolean(Situacao.Ativo),
                        EmpresaId = model.EmpresaId
                    };

                    var clienteDTO = _mapper.Map<Cliente>(clienteDTOMapper);
                    clienteDTO.Nome = _validacoesPersist.AcertarNome(clienteDTO.Nome);
                    _geralPersist.Add<Cliente>(clienteDTO);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        var retornoCliente = await _clientePersist.GetClienteByIdAsync(clienteDTO.EmpresaId, clienteDTO.Id);
                        return _mapper.Map<ClienteDTO>(retornoCliente);
                    }
                    throw new Exception(mensagem);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> UpdateCliente(int empresaId, int clienteId, ClienteUpdateDTO model)
        {           
            try
            { 
                var cliente = await _clientePersist.GetClienteByIdAsync(empresaId, clienteId);
                if (cliente == null)
                {
                    throw new Exception(MensagemDeErro.ClienteNaoEncontradoUpdate);
                }
                else
                {
                    if (_validacoesPersist.ExisteCliente(empresaId, model.CPFCNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, clienteId, true, out string mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {   
                        var clienteDTOMapper = new ClienteDTO()
                        {
                            Id = clienteId,
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
                            CPFCNPJ = model.CPFCNPJ,
                            InscricaoMunicipal = model.InscricaoMunicipal == "" ? "" : model.InscricaoMunicipal,
                            InscricaoEstadual = model.InscricaoEstadual == "" ? "" : model.InscricaoEstadual,
                            DataCadastroCliente = model.DataCadastroCliente,
                            Ativo = model.Ativo,
                            EmpresaId = empresaId
                        };

                        var clienteDTO = _mapper.Map<Cliente>(clienteDTOMapper);
                        clienteDTO.Nome = _validacoesPersist.AcertarNome(clienteDTO.Nome);
                        _geralPersist.Update(clienteDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var retornoCliente = await _clientePersist.GetClienteByIdAsync(clienteDTO.EmpresaId, clienteDTO.Id);
                            return _mapper.Map<ClienteDTO>(retornoCliente);
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
    }
}
