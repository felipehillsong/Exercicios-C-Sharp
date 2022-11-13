﻿using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.ContratosServices
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> AddUsuario(UsuarioCreateDTO model);
        Task<UsuarioDTO> UpdateUsuario(int usuarioId, UsuarioUpdateDTO model);
        Task<bool> DeleteUsuario(int empresaId, int usuarioId);
        Task<IEnumerable<UsuariosRetornoDTO>> GetAllUsuariosAsync(int empresaId);
        Task<IEnumerable<FuncionarioDTO>> GetAllFuncionariosUsuariosAsync(int empresaId);
        Task<UsuarioComPermissoesDTO> GetUsuarioByIdAsync(int empresaId, int usuarioId);
        Task<FuncionarioDTO> GetFuncionarioUsuarioByIdAsync(int empresaId, int funcionarioId);
        Task<UsuarioDTO> GetUsuarioByIdAlteraLoginAsync(int funcionarioId);
        Permissao UpdatePermissao(List<PermissaoDTO> model, out string mensagem);
        Task<List<PermissaoDTO>> GetPermissaoByIdAsync(int empresaId, int usuarioId);
        bool VerificaPermissoes(Permissao permissaoBD, PermissaoDTO permissaoDTO);
        PermissaoDTO PreenchePermissoes(PermissaoDTO permissaoDTO);
    }
}
