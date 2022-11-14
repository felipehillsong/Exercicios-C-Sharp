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
    public class TransportadorService : ITransportadorService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly ITransportadorPersist _transportadorPersist;
        private readonly IMapper _mapper;

        public TransportadorService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, ITransportadorPersist transportadorPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _transportadorPersist = transportadorPersist;
            _mapper = mapper;
        }
        public async Task<TransportadorDTO> AddTransportador(TransportadorCreateDTO model)
        {
            try
            {                
                var transportador = _validacoesPersist.ExisteTransportador(model.EmpresaId, model.CNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, (int)Ids.IdCreate, false, out string mensagem);
                if (transportador == true)
                {
                    throw new Exception(mensagem);
                }
                else
                {   
                    var transportadorDTOMapper = new TransportadorDTO()
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
                        DataCadastroTransportador = model.DataCadastroTransportador,
                        Ativo = Convert.ToBoolean(Situacao.Ativo),
                        EmpresaId = model.EmpresaId
                    };

                    var TransportadorDTO = _mapper.Map<Transportador>(transportadorDTOMapper);
                    TransportadorDTO.Nome = _validacoesPersist.AcertarNome(TransportadorDTO.Nome);
                    _geralPersist.Add<Transportador>(TransportadorDTO);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        var retornoTransportador = await _transportadorPersist.GetTransportadorByIdAsync(TransportadorDTO.EmpresaId, TransportadorDTO.Id);
                        return _mapper.Map<TransportadorDTO>(retornoTransportador);
                    }
                    throw new Exception(mensagem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TransportadorDTO> UpdateTransportador(int empresaId, int transportadorId, TransportadorUpdateDTO model)
        {
            try
            {                
                var transportador = await _transportadorPersist.GetTransportadorByIdAsync(empresaId, transportadorId);
                if (transportador == null)
                {
                    throw new Exception(MensagemDeErro.TransportadorNaoEcontradoUpdate);
                }
                else
                {
                    if (_validacoesPersist.ExisteTransportador(empresaId, model.CNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, transportadorId, true, out string mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {
                        var correios = new CorreiosCEP();
                        var endereco = correios.ConsultaCEP(model.CEP);
                        var enderecoDeserialize = endereco == null ? null : JsonConvert.DeserializeObject<CorreiosCEP>(endereco);

                        var transportadorDTOMapper = new TransportadorDTO()
                        {
                            Id = transportadorId,
                            Nome = model.Nome,
                            Endereco = enderecoDeserialize == null ? model.Endereco : enderecoDeserialize.Endereco,
                            Bairro = enderecoDeserialize == null ? model.Bairro : enderecoDeserialize.Bairro,
                            Numero = model.Numero,
                            Municipio = enderecoDeserialize == null ? model.Municipio : enderecoDeserialize.Municipio,
                            UF = enderecoDeserialize == null ? model.UF : enderecoDeserialize.UF,
                            Pais = model.Pais,
                            CEP = enderecoDeserialize == null ? model.CEP : enderecoDeserialize.CEP,
                            Complemento = model.Complemento,
                            Telefone = model.Telefone,
                            Email = model.Email,
                            CNPJ = model.CNPJ,
                            InscricaoMunicipal = model.InscricaoMunicipal,
                            InscricaoEstadual = model.InscricaoEstadual,
                            DataCadastroTransportador = model.DataCadastroTransportador,
                            Ativo = model.Ativo,
                            EmpresaId = empresaId
                        };

                        var TransportadorDTO = _mapper.Map<Transportador>(transportadorDTOMapper);
                        TransportadorDTO.Nome = _validacoesPersist.AcertarNome(TransportadorDTO.Nome);
                        _geralPersist.Update<Transportador>(TransportadorDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var retornoTransportador = await _transportadorPersist.GetTransportadorByIdAsync(TransportadorDTO.EmpresaId, TransportadorDTO.Id);
                            return _mapper.Map<TransportadorDTO>(retornoTransportador);
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

        public async Task<bool> DeleteTransportador(int empresaId, int transportadorId)
        {
            try
            {
                var transportador = await _transportadorPersist.GetTransportadorByIdAsync(empresaId, transportadorId);
                if (transportador == null)
                {
                    throw new Exception(MensagemDeErro.TransportadorNaoEncontradoDelete);
                }
                else
                {
                    _geralPersist.Delete<Transportador>(transportador);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransportadorDTO>> GetAllTransportadoresAsync(int empresaId)
        {
            try
            {
                var transportadoras = await _transportadorPersist.GetAllTransportadoresAsync(empresaId);
                if (transportadoras == null)
                {
                    throw new Exception(MensagemDeErro.TransportadorNaoEncontrado);
                }
                else if (transportadoras.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.TransportadorNaoEncontradoEmpresa);
                }
                else
                {
                    var resultadoTransportadoras = _mapper.Map<IEnumerable<TransportadorDTO>>(transportadoras);
                    return resultadoTransportadoras;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public async Task<TransportadorDTO> GetTransportadorByIdAsync(int empresaId, int transportadorId)
        {
            try
            {
                var transportador = await _transportadorPersist.GetTransportadorByIdAsync(empresaId, transportadorId);
                if (transportador == null)
                {
                    throw new Exception(MensagemDeErro.TransportadorNaoEncontrado);
                }
                else
                {
                    var resultadoTransportador = _mapper.Map<TransportadorDTO>(transportador);
                    return resultadoTransportador;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
