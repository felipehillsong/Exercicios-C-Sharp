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
    public class EmpresaService : IEmpresaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IEmpresaPersist _empresaPersist;
        private readonly IMapper _mapper;

        public EmpresaService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IEmpresaPersist empresaPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _empresaPersist = empresaPersist;
            _mapper = mapper;
        }
        public async Task<EmpresaDTO> AddEmpresa(EmpresaCreateDTO model)
        {
            try
            {
                var empresa = _validacoesPersist.ExisteEmpresa((int)Ids.IdCreate, model.CNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, false, out string mensagem);
                if (empresa == true)
                {
                    throw new Exception(mensagem);
                }
                else
                {       
                    var empresaDTOMapper = new EmpresaDTO()
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
                        DataCadastroEmpresa = model.DataCadastroEmpresa,
                        Ativo = Convert.ToBoolean(Situacao.Ativo)
                    };

                    var empresaDTO = _mapper.Map<Empresa>(empresaDTOMapper);
                    empresaDTO.Nome = _validacoesPersist.AcertarNome(empresaDTO.Nome);
                    _geralPersist.Add<Empresa>(empresaDTO);
                    if (await _geralPersist.SaveChangesAsync())
                    {
                        var retornoEmpresa = await _empresaPersist.GetEmpresaByIdAsync(empresaDTO.Id);
                        return _mapper.Map<EmpresaDTO>(retornoEmpresa);
                    }                    
                    throw new Exception(MensagemDeErro.ErroSalvarEmpresa);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmpresaDTO> UpdateEmpresa(int id, EmpresaUpdateDTO model)
        {
            try
            {                
                var empresa = await _empresaPersist.GetEmpresaByIdAsync(id);
                if (empresa == null)
                {
                    return null;
                }
                else
                {
                    if (_validacoesPersist.ExisteEmpresa(id, model.CNPJ, model.InscricaoMunicipal, model.InscricaoEstadual, true, out string mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {
                        var empresaDTOMapper = new EmpresaDTO()
                        {
                            Id = id,
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
                            DataCadastroEmpresa = model.DataCadastroEmpresa,
                            Ativo = model.Ativo
                        };

                        var empresaDTO = _mapper.Map<Empresa>(empresaDTOMapper);
                        empresaDTO.Nome = _validacoesPersist.AcertarNome(empresaDTO.Nome);                                               
                        _geralPersist.Update(empresaDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var retornoEmpresa = await _empresaPersist.GetEmpresaByIdAsync(empresaDTO.Id);
                            return _mapper.Map<EmpresaDTO>(retornoEmpresa);
                        }                        
                        throw new Exception(MensagemDeErro.ErroAtualizarEmpresa);
                    }   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEmpresa(int id)
        {
            try
            {
                var empresa = await _empresaPersist.GetEmpresaByIdAsync(id);
                if (empresa == null)
                {
                    throw new Exception(MensagemDeErro.EmpresaNaoEncontradaParaDelete);
                }
                else
                {
                    _geralPersist.Delete<Empresa>(empresa);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EmpresaDTO>> GetAllEmpresasAsync()
        {
            try
            {
                var empresas = await _empresaPersist.GetAllEmpresasAsync();
                if (empresas == null)
                {
                    throw new Exception(MensagemDeErro.EmpresaNaoEncontrada);
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

        public async Task<EmpresaDTO> GetEmpresaByIdAsync(int id)
        {
            try
            {
                var empresa = await _empresaPersist.GetEmpresaByIdAsync(id);
                if (empresa == null)
                {
                    throw new Exception(MensagemDeErro.EmpresaNaoEncontrada);
                }
                else
                {
                    var resultadoEmpresa = _mapper.Map<EmpresaDTO>(empresa);
                    return resultadoEmpresa;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
