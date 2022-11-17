using AutoMapper;
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
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<Estoque, EstoqueDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<FuncionariosUsuariosViewModel, FuncionarioDTO>().ReverseMap();
            CreateMap<Permissao, PermissaoDTO>().ReverseMap();
            CreateMap<Permissao, List<PermissaoDTO>>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoUpdateDTO>().ReverseMap();
            CreateMap<Transportador, TransportadorDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioViewModel, UsuariosRetornoDTO>().ReverseMap();
            CreateMap<UsuarioViewModel, UsuarioLoginDTO>().ReverseMap();
            CreateMap<UsuarioViewModel, UsuarioDTO>().ReverseMap();
        }
    }
}
