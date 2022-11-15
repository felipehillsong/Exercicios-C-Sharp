﻿using RetaguardaESilva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }       
        public DateTime? DataCadastroUsuario { get; set; }
        public bool Ativo { get; set; }
        public int FuncionarioId { get; set; }
        public int EmpresaId { get; set; }
        public string NomeEmpresa { get; set; }
        public List<PermissaoDTO> Permissoes { get; set; }
    }

    public class UsuarioComPermissoesDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastroUsuario { get; set; }
        public bool Ativo { get; set; }
        public int FuncionarioId { get; set; }
        public int EmpresaId { get; set; }
        public string NomeEmpresa { get; set; }
        public List<PermissaoDTO> Permissoes { get; set; }
    }

    public class UsuarioCreateDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }       
        public DateTime? DataCadastroUsuario { get; set; }
        public bool Ativo { get; set; }
        public int FuncionarioId { get; set; }
        public int EmpresaId { get; set; }
    }

    public class UsuarioUpdateDTO
    {        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastroUsuario { get; set; }
        public bool Ativo { get; set; }
        public int FuncionarioId { get; set; }
        public int EmpresaId { get; set; }
        public string NomeEmpresa { get; set; }
        public List<PermissaoDTO> Permissoes { get; set; }
    }

    public class UsuariosRetornoDTO
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastroUsuario { get; set; }
        public bool Ativo { get; set; }
        public int FuncionarioId { get; set; }
        public int EmpresaId { get; set; }
    }

    public class UsuarioLoginDTO
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastroUsuario { get; set; }
        public bool Ativo { get; set; }
        public int FuncionarioId { get; set; }
        public int EmpresaId { get; set; }
        public List<PermissaoDTO> Permissoes { get; set; }
    }
}
