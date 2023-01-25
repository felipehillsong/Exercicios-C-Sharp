﻿using AutoMapper;
using RetaguardaESilva.Application.DTO;
using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Application.Helpers
{
    public class RetaguardaESilvaProfile : Profile
    {
        public RetaguardaESilvaProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteCreateDTO>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaCreateDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaUpdateDTO>().ReverseMap();
            CreateMap<Estoque, EstoqueDTO>().ReverseMap();
            CreateMap<EnderecoProduto, EnderecoProdutoDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorCreateDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorUpdateDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<FuncionarioCreateDTO, Funcionario>().ReverseMap();
            CreateMap<FuncionarioUpdateDTO, Funcionario>().ReverseMap();
            CreateMap<FuncionariosUsuariosViewModel, FuncionarioDTO>().ReverseMap();
            CreateMap<Permissao, PermissaoDTO>().ReverseMap();
            CreateMap<Permissao, List<PermissaoDTO>>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoCreateDTO>().ReverseMap();
            CreateMap<Produto, ProdutoUpdateDTO>().ReverseMap();
            CreateMap<Transportador, TransportadorDTO>().ReverseMap();
            CreateMap<Transportador, TransportadorCreateDTO>().ReverseMap();
            CreateMap<Transportador, TransportadorUpdateDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDTO>().ReverseMap();
            CreateMap<UsuarioViewModel, UsuariosRetornoDTO>().ReverseMap();
            CreateMap<UsuarioViewModel, UsuarioLoginDTO>().ReverseMap();
            CreateMap<UsuarioViewModel, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioDTO, UsuarioUpdateDTO>().ReverseMap();
        }
    }
}
