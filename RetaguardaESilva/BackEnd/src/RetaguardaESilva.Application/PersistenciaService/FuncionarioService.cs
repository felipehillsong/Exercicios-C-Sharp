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
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IFuncionarioPersist _funcionarioPersist;
        private readonly IMapper _mapper;

        public FuncionarioService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IFuncionarioPersist funcionarioPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _funcionarioPersist = funcionarioPersist;
            _mapper = mapper;
        }
        public async Task<FuncionarioDTO> AddFuncionario(FuncionarioCreateDTO model)
        {   
            if (_validacoesPersist.ExisteFuncionario(model.EmpresaId, model.CPF, model.Id, false, out string mensagem))
            {
                throw new Exception(mensagem);
            }
            else
            {
                var funcionarioDTOMapper = new FuncionarioDTO()
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
                    CPF = model.CPF,
                    DataCadastroFuncionario = model.DataCadastroFuncionario,
                    Ativo = Convert.ToBoolean(Situacao.Ativo),
                    EmpresaId = model.EmpresaId
                };

                var funcionarioDTO = _mapper.Map<Funcionario>(funcionarioDTOMapper);
                funcionarioDTO.Nome = _validacoesPersist.AcertarNome(funcionarioDTO.Nome);
                _geralPersist.Add<Funcionario>(funcionarioDTO);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var retornoFuncionario = await _funcionarioPersist.GetFuncionarioByIdAsync(funcionarioDTO.EmpresaId, funcionarioDTO.Id);
                    return _mapper.Map<FuncionarioDTO>(retornoFuncionario);
                }
                throw new Exception(mensagem);
            }
        }

        public async Task<FuncionarioDTO> UpdateFuncionario(int empresaId, int funcionarioId, FuncionarioUpdateDTO model)
        {
            try
            {                
                var funcionario = await _funcionarioPersist.GetFuncionarioByIdAsync(empresaId, funcionarioId);
                if (funcionario == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioNaoEncontradoUpdate);
                }
                else
                {
                    if (_validacoesPersist.ExisteFuncionario(empresaId, model.CPF, funcionarioId, true, out string mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {
                        var funcionarioDTOMapper = new FuncionarioDTO()
                        {
                            Id = funcionarioId,
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
                            CPF = model.CPF,
                            DataCadastroFuncionario = model.DataCadastroFuncionario,
                            Ativo = model.Ativo,
                            EmpresaId = empresaId
                        };

                        var funcionarioDTO = _mapper.Map<Funcionario>(funcionarioDTOMapper);
                        funcionarioDTO.Nome = _validacoesPersist.AcertarNome(funcionarioDTO.Nome);
                        _geralPersist.Update<Funcionario>(funcionarioDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var retornoFuncionario = await _funcionarioPersist.GetFuncionarioByIdAsync(funcionarioDTO.EmpresaId, funcionarioDTO.Id);
                            return _mapper.Map<FuncionarioDTO>(retornoFuncionario);
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

        public async Task<bool> DeleteFuncionario(int empresaId, int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionarioPersist.GetFuncionarioByIdAsync(empresaId, funcionarioId);
                if (funcionario == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioNaoEncontradoDelete);
                }
                else
                {
                    _geralPersist.Delete<Funcionario>(funcionario);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetAllFuncionariosAsync(int empresaId)
        {
            try
            {
                var funcionarios = await _funcionarioPersist.GetAllFuncionariosAsync(empresaId);
                if (funcionarios == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioNaoEncontrado);
                }
                else if (funcionarios.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FuncionarioNaoEncontradoEmpresa);
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

        public async Task<FuncionarioDTO> GetFuncionarioByIdAsync(int empresaId, int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionarioPersist.GetFuncionarioByIdAsync(empresaId, funcionarioId);
                if (funcionario == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioNaoEncontrado);
                }
                else
                {
                    var resultadoFuncionario = _mapper.Map<FuncionarioDTO>(funcionario);
                    return resultadoFuncionario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FuncionarioDTO> GetFuncionarioByIdLoginAsync(int funcionarioId)
        {
            try
            {
                var funcionario = await _funcionarioPersist.GetFuncionarioLoginByIdAsync(funcionarioId);
                if (funcionario == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioNaoEncontrado);
                }
                else
                {
                    var resultadoFuncionario = _mapper.Map<FuncionarioDTO>(funcionario);
                    return resultadoFuncionario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
