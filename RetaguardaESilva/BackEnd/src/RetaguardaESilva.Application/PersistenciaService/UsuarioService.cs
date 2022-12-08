﻿using AngleSharp.Dom;
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
using RetaguardaESilva.Persistence.Persistencias;
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
        private readonly IMapper _mapper;

        public UsuarioService(IGeralPersist geralPersist, IValidacoesPersist validacoesPersist, IUsuarioPersist usuarioPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _validacoesPersist = validacoesPersist;
            _usuarioPersist = usuarioPersist;
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

        public async Task<UsuarioDTO> UpdateUsuario(int usuarioId, UsuarioUpdateDTO model)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(model.EmpresaId, usuarioId);
                var funcionario = await _usuarioPersist.GetFuncionarioUsuarioByIdAsync(model.EmpresaId, model.FuncionarioId);
                if (usuario == null || funcionario == null)
                {
                    throw new Exception(MensagemDeErro.UsuarioNaoEncontradoUpdate);
                }
                else
                {
                    string mensagem = "";
                    model.Email = _validacoesPersist.AcertarNome(model.Email);
                    model.Senha = _validacoesPersist.AcertarNome(model.Senha);

                    if (_validacoesPersist.ExisteUsuario(model.EmpresaId, usuarioId, model.Email, true, out mensagem))
                    {
                        throw new Exception(mensagem);
                    }
                    else
                    {
                        var usuarioDTOMapper = new UsuarioDTO()
                        {
                            Id = usuarioId,
                            Email = model.Email,
                            Senha = model.Senha,
                            DataCadastroUsuario = model.DataCadastroUsuario,
                            Ativo = model.Ativo,
                            FuncionarioId = model.FuncionarioId,
                            EmpresaId = model.EmpresaId
                        };
                        var usuarioDTO = _mapper.Map<Usuario>(usuarioDTOMapper);
                        _geralPersist.Update<Usuario>(usuarioDTO);
                        if (await _geralPersist.SaveChangesAsync())
                        {
                            var funcionarioUpdate = new Funcionario()
                            {
                                Id = model.FuncionarioId,
                                Nome = model.Nome,
                                Endereco = funcionario.Endereco,
                                Bairro = funcionario.Bairro,
                                Numero = funcionario.Numero,
                                Municipio = funcionario.Municipio,
                                UF = funcionario.UF,
                                Pais = funcionario.Pais,
                                CEP = funcionario.CEP,
                                Complemento = funcionario.Complemento,
                                Telefone = funcionario.Telefone,
                                Email = model.Email,
                                CPF = funcionario.CPF,
                                DataCadastroFuncionario = funcionario.DataCadastroFuncionario,
                                Ativo = funcionario.Ativo,
                                EmpresaId = model.EmpresaId
                            };
                            _geralPersist.Update<Funcionario>(funcionarioUpdate);
                            if (await _geralPersist.SaveChangesAsync())
                            {
                                var permissoes = model.Permissoes;
                                var permissoesUsuario = UpdatePermissao(permissoes, out string mensagemRetorno);
                                if (mensagemRetorno == MensagemDeSucesso.UsuarioSemPermissao)
                                {
                                    _geralPersist.Add<Permissao>(permissoesUsuario);
                                    if (await _geralPersist.SaveChangesAsync())
                                    {
                                        var usuarioRetorno = await GetUsuarioByIdAsync(model.EmpresaId, usuarioId);
                                        return usuarioRetorno;
                                    }
                                }
                                else if (mensagemRetorno == MensagemDeSucesso.UsuarioDadosDiferente)
                                {
                                    _geralPersist.Update<Permissao>(permissoesUsuario);
                                    if (await _geralPersist.SaveChangesAsync())
                                    {
                                        var usuarioRetorno = await GetUsuarioByIdAsync(model.EmpresaId, usuarioId);
                                        return usuarioRetorno;
                                    }
                                }
                                else if (mensagemRetorno == MensagemDeSucesso.UsuarioMesmoDado)
                                {
                                    var usuarioRetorno = await GetUsuarioByIdAsync(model.EmpresaId, usuarioId);
                                    return usuarioRetorno;
                                }
                            }
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
                    if(await _geralPersist.SaveChangesAsync())
                    {
                        var permissao = await _usuarioPersist.GetPermissaoUsuarioByIdAsync(empresaId, usuarioId);
                        if(permissao != null)
                        {
                            _geralPersist.Delete<Permissao>(permissao);
                            return await _geralPersist.SaveChangesAsync();
                        }

                        return true;
                    }
                    else
                    {
                        throw new Exception(MensagemDeErro.UsuarioErroDelete);
                    }
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
                    var retornoUsuario = _validacoesPersist.RetornarUsuarioId(usuario.Id);
                    var resultadoUsuario = _mapper.Map<UsuarioDTO>(retornoUsuario);
                    var usuarioPermissao = GetPermissaoByIdAsync(empresaId, usuarioId);
                    resultadoUsuario.Permissoes = usuarioPermissao.Result;
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

        public Permissao UpdatePermissao(List<PermissaoDTO> model, out string mensagem)
        {
            try
            {
                var permissao = _usuarioPersist.GetPermissaoByIdAsync(model[0].EmpresaId, model[0].UsuarioId, model[0].Id);                
                if (permissao.Result == null)
                {
                    var permissoes = PreenchePermissoes(model[0]);
                    var Permissao = _mapper.Map<Permissao>(permissoes);
                    mensagem = MensagemDeSucesso.UsuarioSemPermissao;
                    return Permissao;
                }
                else
                {
                    var permissoes = VerificaPermissoes(permissao.Result, model[0]);
                    if (permissoes)
                    {
                        mensagem = MensagemDeSucesso.UsuarioMesmoDado;
                        return permissao.Result;
                    }
                    else
                    {
                        var permissoesAlterar = PreenchePermissoes(model[0]);
                        var permissaoRetorno = _mapper.Map<Permissao>(permissoesAlterar);
                        mensagem = MensagemDeSucesso.UsuarioDadosDiferente;
                        return permissaoRetorno;
                    }
                   
                    throw new Exception(MensagemDeErro.ErroAoAtualizarCriar);
                }

                throw new Exception(MensagemDeErro.ErroAoAtualizarCriar);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PermissaoDTO>> GetPermissaoByIdAsync(int empresaId, int usuarioId)
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
                            EstoqueCadastro = false,
                            EstoqueEditar = false,
                            EstoqueDetalhe = false,
                            EstoqueExcluir = false,
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
                            VisualizarRelatorio = false,
                            RelatorioCadastro = false,
                            RelatorioEditar = false,
                            RelatorioDetalhe = false,
                            RelatorioExcluir = false,
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
                            VisualizarVenda = false,
                            VendaCadastro = false,
                            VendaEditar = false,
                            VendaDetalhe = false,
                            VendaExcluir = false,
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
                            EstoqueCadastro = usuarioPermissao.EstoqueCadastro,
                            EstoqueEditar = usuarioPermissao.EstoqueEditar,
                            EstoqueDetalhe = usuarioPermissao.EstoqueDetalhe,
                            EstoqueExcluir = usuarioPermissao.EstoqueExcluir,
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
                            VisualizarRelatorio = usuarioPermissao.VisualizarRelatorio,
                            RelatorioCadastro = usuarioPermissao.RelatorioCadastro,
                            RelatorioEditar = usuarioPermissao.RelatorioEditar,
                            RelatorioDetalhe = usuarioPermissao.RelatorioDetalhe,
                            RelatorioExcluir = usuarioPermissao.RelatorioExcluir,
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
                            VisualizarVenda = usuarioPermissao.VisualizarVenda,
                            VendaCadastro = usuarioPermissao.VendaCadastro,
                            VendaEditar = usuarioPermissao.VendaEditar,
                            VendaDetalhe = usuarioPermissao.VendaDetalhe,
                            VendaExcluir = usuarioPermissao.VendaExcluir,
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

        public bool VerificaPermissoes(Permissao permissaoBD, PermissaoDTO permissaoDTO)
        {
            if (permissaoBD.Id == permissaoDTO.Id
            &&permissaoBD.VisualizarCliente == permissaoDTO.VisualizarCliente
            &&permissaoBD.ClienteCadastro == permissaoDTO.ClienteCadastro
            &&permissaoBD.ClienteEditar == permissaoDTO.ClienteEditar
            &&permissaoBD.ClienteDetalhe == permissaoDTO.ClienteDetalhe
            &&permissaoBD.ClienteExcluir == permissaoDTO.ClienteExcluir
            &&permissaoBD.VisualizarEmpresa == permissaoDTO.VisualizarEmpresa
            &&permissaoBD.EmpresaCadastro == permissaoDTO.EmpresaCadastro
            &&permissaoBD.EmpresaEditar == permissaoDTO.EmpresaEditar
            &&permissaoBD.EmpresaDetalhe == permissaoDTO.EmpresaDetalhe
            &&permissaoBD.EmpresaExcluir == permissaoDTO.EmpresaExcluir
            &&permissaoBD.VisualizarEstoque == permissaoDTO.VisualizarEstoque
            &&permissaoBD.EstoqueCadastro == permissaoDTO.EstoqueCadastro
            &&permissaoBD.EstoqueEditar == permissaoDTO.EstoqueEditar
            &&permissaoBD.EstoqueDetalhe == permissaoDTO.EstoqueDetalhe
            &&permissaoBD.EstoqueExcluir == permissaoDTO.EstoqueExcluir
            &&permissaoBD.VisualizarFornecedor == permissaoDTO.VisualizarFornecedor
            &&permissaoBD.FornecedorCadastro == permissaoDTO.FornecedorCadastro
            &&permissaoBD.FornecedorEditar == permissaoDTO.FornecedorEditar
            &&permissaoBD.FornecedorDetalhe == permissaoDTO.FornecedorDetalhe
            &&permissaoBD.FornecedorExcluir == permissaoDTO.FornecedorExcluir
            &&permissaoBD.VisualizarFuncionario == permissaoDTO.VisualizarFuncionario
            &&permissaoBD.FuncionarioCadastro == permissaoDTO.FuncionarioCadastro
            &&permissaoBD.FuncionarioEditar == permissaoDTO.FuncionarioEditar
            &&permissaoBD.FuncionarioDetalhe == permissaoDTO.FuncionarioDetalhe
            &&permissaoBD.FuncionarioExcluir == permissaoDTO.FuncionarioExcluir
            &&permissaoBD.VisualizarProduto == permissaoDTO.VisualizarProduto
            &&permissaoBD.ProdutoCadastro == permissaoDTO.ProdutoCadastro
            &&permissaoBD.ProdutoEditar == permissaoDTO.ProdutoEditar
            &&permissaoBD.ProdutoDetalhe == permissaoDTO.ProdutoDetalhe
            &&permissaoBD.ProdutoExcluir == permissaoDTO.ProdutoExcluir
            &&permissaoBD.VisualizarRelatorio == permissaoDTO.VisualizarRelatorio
            &&permissaoBD.RelatorioCadastro == permissaoDTO.RelatorioCadastro
            &&permissaoBD.RelatorioEditar == permissaoDTO.RelatorioEditar
            &&permissaoBD.RelatorioDetalhe == permissaoDTO.RelatorioDetalhe
            &&permissaoBD.RelatorioExcluir == permissaoDTO.RelatorioExcluir
            &&permissaoBD.VisualizarTransportador == permissaoDTO.VisualizarTransportador
            &&permissaoBD.TransportadorCadastro == permissaoDTO.TransportadorCadastro
            &&permissaoBD.TransportadorEditar == permissaoDTO.TransportadorEditar
            &&permissaoBD.TransportadorDetalhe == permissaoDTO.TransportadorDetalhe
            &&permissaoBD.TransportadorExcluir == permissaoDTO.TransportadorExcluir
            &&permissaoBD.VisualizarUsuario == permissaoDTO.VisualizarUsuario
            &&permissaoBD.UsuarioCadastro == permissaoDTO.UsuarioCadastro
            &&permissaoBD.UsuarioEditar == permissaoDTO.UsuarioEditar
            &&permissaoBD.UsuarioPermissoes == permissaoDTO.UsuarioPermissoes
            &&permissaoBD.UsuarioExcluir == permissaoDTO.UsuarioExcluir
            &&permissaoBD.VisualizarVenda == permissaoDTO.VisualizarVenda
            &&permissaoBD.VendaCadastro == permissaoDTO.VendaCadastro
            &&permissaoBD.VendaEditar == permissaoDTO.VendaEditar
            &&permissaoBD.VendaDetalhe == permissaoDTO.VendaDetalhe
            &&permissaoBD.VendaExcluir == permissaoDTO.VendaExcluir
            &&permissaoBD.EmpresaId == permissaoDTO.EmpresaId
            &&permissaoBD.UsuarioId == permissaoDTO.UsuarioId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public PermissaoDTO PreenchePermissoes(PermissaoDTO permissaoDTO)
        {
            var PermissaoDTOMapper = new PermissaoDTO()
            {
                Id = permissaoDTO.Id,
                VisualizarCliente = permissaoDTO.VisualizarCliente,
                ClienteCadastro = permissaoDTO.ClienteCadastro,                
                ClienteEditar = permissaoDTO.ClienteEditar,
                ClienteDetalhe = permissaoDTO.ClienteDetalhe,
                ClienteExcluir = permissaoDTO.ClienteExcluir,
                VisualizarEmpresa = permissaoDTO.VisualizarEmpresa,
                EmpresaCadastro = permissaoDTO.EmpresaCadastro,
                EmpresaEditar = permissaoDTO.EmpresaEditar,
                EmpresaDetalhe = permissaoDTO.EmpresaDetalhe,
                EmpresaExcluir = permissaoDTO.EmpresaExcluir,
                VisualizarEstoque = permissaoDTO.VisualizarEstoque,
                EstoqueCadastro = permissaoDTO.EstoqueCadastro,
                EstoqueEditar = permissaoDTO.EstoqueEditar,
                EstoqueDetalhe = permissaoDTO.EstoqueDetalhe,
                EstoqueExcluir = permissaoDTO.EstoqueExcluir,
                VisualizarFornecedor = permissaoDTO.VisualizarFornecedor,
                FornecedorCadastro = permissaoDTO.FornecedorCadastro,
                FornecedorEditar = permissaoDTO.FornecedorEditar,
                FornecedorDetalhe = permissaoDTO.FornecedorDetalhe,
                FornecedorExcluir = permissaoDTO.FornecedorExcluir,
                VisualizarFuncionario = permissaoDTO.VisualizarFuncionario,
                FuncionarioCadastro = permissaoDTO.FuncionarioCadastro,
                FuncionarioEditar = permissaoDTO.FuncionarioEditar,
                FuncionarioDetalhe = permissaoDTO.FuncionarioDetalhe,
                FuncionarioExcluir = permissaoDTO.FuncionarioExcluir,
                VisualizarProduto = permissaoDTO.VisualizarProduto,
                ProdutoCadastro = permissaoDTO.ProdutoCadastro,
                ProdutoEditar = permissaoDTO.ProdutoEditar,
                ProdutoDetalhe = permissaoDTO.ProdutoDetalhe,
                ProdutoExcluir = permissaoDTO.ProdutoExcluir,
                VisualizarRelatorio = permissaoDTO.VisualizarRelatorio,
                RelatorioCadastro = permissaoDTO.RelatorioCadastro,
                RelatorioEditar = permissaoDTO.RelatorioEditar,
                RelatorioDetalhe = permissaoDTO.RelatorioDetalhe,
                RelatorioExcluir = permissaoDTO.RelatorioExcluir,
                VisualizarTransportador = permissaoDTO.VisualizarTransportador,
                TransportadorCadastro = permissaoDTO.TransportadorCadastro,
                TransportadorEditar = permissaoDTO.TransportadorEditar,
                TransportadorDetalhe = permissaoDTO.TransportadorDetalhe,
                TransportadorExcluir = permissaoDTO.TransportadorExcluir,
                VisualizarUsuario = permissaoDTO.VisualizarUsuario,
                UsuarioCadastro = permissaoDTO.UsuarioCadastro,
                UsuarioEditar = permissaoDTO.UsuarioEditar,
                UsuarioPermissoes = permissaoDTO.UsuarioPermissoes,
                UsuarioExcluir = permissaoDTO.UsuarioExcluir,
                VisualizarVenda = permissaoDTO.VisualizarVenda,
                VendaCadastro = permissaoDTO.VendaCadastro,
                VendaEditar = permissaoDTO.VendaEditar,
                VendaDetalhe = permissaoDTO.VendaDetalhe,
                VendaExcluir = permissaoDTO.VendaExcluir,
                EmpresaId = permissaoDTO.EmpresaId,
                UsuarioId = permissaoDTO.UsuarioId
            };
            return PermissaoDTOMapper;
        }
    }
}