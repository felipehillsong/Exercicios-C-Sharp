using AutoMapper;
using Correios.NET.Models;
using Newtonsoft.Json;
using RetaguardaESilva.Application.ContratosServices;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Application.Helpers;
using RetaguardaESilva.Domain.Enumeradores;
using RetaguardaESilva.Domain.Mensagem;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Persistence.Contratos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.PersistenciaService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IValidacoesPersist _validacoesPersist;
        private readonly IUsuarioPersist _usuarioPersist;
        private readonly IFuncionarioPersist _funcionarioPersist;
        private readonly IMapper _mapper;

        public UsuarioService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IUsuarioPersist usuarioPersist, IFuncionarioPersist funcionarioPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _usuarioPersist = usuarioPersist;
            _funcionarioPersist = funcionarioPersist;
            _mapper = mapper;
        }
        public async Task<UsuarioDTO> AddUsuario(UsuarioCreateDTO model)
        {
            string mensagem = "";
            model.Email = _validacoesPersist.AcertarNome(model.Email);
            model.Senha = _validacoesPersist.AcertarNome(model.Senha);            
            
            if (_validacoesPersist.ExisteUsuario(model.EmpresaId, (int)Ids.IdCreate, model.Email, false, out mensagem))
            {
                throw new Exception(mensagem);
            }
            else
            {
                var usuarioDTOMapper = new UsuarioDTO()
                {
                    Id = (int)Ids.IdCreate,
                    Email = model.Email,
                    Senha = model.Senha,
                    DataCadastroUsuario = model.DataCadastroUsuario,
                    Ativo = Convert.ToBoolean(Situacao.Ativo),
                    FuncionarioId = model.FuncionarioId,
                    EmpresaId = model.EmpresaId
                };

                var usuarioDTO = _mapper.Map<Usuario>(usuarioDTOMapper);
                _geralPersist.Add<Usuario>(usuarioDTO);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var retornoUsuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioDTO.EmpresaId, usuarioDTO.Id);
                    return _mapper.Map<UsuarioDTO>(retornoUsuario);
                }
                throw new Exception(mensagem);
            }
        }

        public async Task<UsuarioDTO> UpdateUsuario(int empresaId, int usuarioId, UsuarioUpdateDTO model)
        {
            try
            {                
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(empresaId, usuarioId);
                if (usuario == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioNaoEncontradoUpdate);
                }
                else
                {
                    string mensagem = "";
                    model.Email = _validacoesPersist.AcertarNome(model.Email);
                    model.Senha = _validacoesPersist.AcertarNome(model.Senha);                    

                    if (_validacoesPersist.ExisteUsuario(empresaId, usuarioId, model.Email, true, out mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {
                        var usuarioDTOMapper = new UsuarioDTO()
                        {
                            Id = (int)Ids.IdCreate,
                            Email = model.Email,
                            Senha = model.Senha,
                            DataCadastroUsuario = model.DataCadastroUsuario,
                            Ativo = model.Ativo,
                            FuncionarioId = model.FuncionarioId,
                            EmpresaId = empresaId
                        };

                        var usuarioDTO = _mapper.Map<Usuario>(usuarioDTOMapper);
                        _geralPersist.Update<Usuario>(usuarioDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var retornoUsuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioDTO.EmpresaId, usuarioDTO.Id);
                            return _mapper.Map<UsuarioDTO>(retornoUsuario);
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

        public async Task<bool> DeleteUsuario(int empresaId, int usuarioId)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(empresaId, usuarioId);
                if (usuario == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioNaoEncontradoDelete);
                }
                else
                {
                    _geralPersist.Delete<Usuario>(usuario);
                    return await _geralPersist.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UsuariosRetornoDTO>> GetAllUsuariosAsync(int empresaId)
        {
            try
            {
                var usuarios = await _usuarioPersist.GetAllUsuariosAsync(empresaId);   
                if (usuarios == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioNaoEncontrado);
                }
                else if (usuarios.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.UsuariosNaoEncontradoEmpresa);
                }
                else
                {
                    var resultadoUsuarios = _validacoesPersist.RetornarUsuario(empresaId);
                    var ListaUsuarios = _mapper.Map<IEnumerable<UsuariosRetornoDTO>>(resultadoUsuarios);
                    return ListaUsuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetAllFuncionariosUsuariosAsync(int empresaId)
        {
            try
            {
                var funcionariosUsuarios = await _usuarioPersist.GetAllFuncionariosUsuariosAsync(empresaId);
                if (funcionariosUsuarios == null)
                {
                    throw new Exception(MensagemDeErro.FuncionarioNaoEncontrado);
                }
                else if (funcionariosUsuarios.Count() == 0)
                {
                    throw new Exception(MensagemDeErro.FuncionarioNaoEncontradoEmpresa);
                }
                else
                {
                    var resultadoUsuarios = _validacoesPersist.RetornarFuncionariosUsuario(empresaId);
                    var listaFuncionariosUsuarios = _mapper.Map<IEnumerable<FuncionarioDTO>>(resultadoUsuarios);
                    return listaFuncionariosUsuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> GetUsuarioByIdAsync(int empresaId, int usuarioId)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(empresaId, usuarioId);
                if (usuario == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioNaoEncontrado);
                }
                else
                {
                    var resultadoUsuario = _mapper.Map<UsuarioDTO>(usuario);
                    return resultadoUsuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FuncionarioDTO> GetFuncionarioUsuarioByIdAsync(int empresaId, int funcionarioId)
        {
            try
            {
                var funcionarioUsuario = await _usuarioPersist.GetFuncionarioUsuarioByIdAsync(empresaId, funcionarioId);
                if (funcionarioUsuario == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioNaoEncontrado);
                }
                else
                {
                    var resultadoUsuario = _mapper.Map<FuncionarioDTO>(funcionarioUsuario);
                    return resultadoUsuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> GetUsuarioByIdAlteraLoginAsync(int funcionarioId)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAlteraLoginAsync(funcionarioId);
                if (usuario == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioNaoEncontrado);
                }
                else
                {
                    var resultadoUsuario = _mapper.Map<UsuarioDTO>(usuario);
                    return resultadoUsuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
