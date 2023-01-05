using RetaguardaESilva.Domain.Models;
using RetaguardaESilva.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Persistence.Contratos
{
    public interface IValidacoesPersist
    {
        bool ExisteCliente(int empresaId, string cnpjCpf, string inscricaoMunicipal, string inscricaoEstadual, int clienteId, bool isUpdate, out string mensagem);
        bool ExisteFornecedor(int empresaId, string cnpjCpf, string inscricaoMunicipal, string inscricaoEstadual, int fornecedorId, bool isUpdate, out string mensagem);
        bool ExisteFuncionario(int empresaId, string cpf, int funcionarioId, bool isUpdate, out string mensagem);
        bool ExisteTransportador(int empresaId, string cnpjCpf, string inscricaoMunicipal, string inscricaoEstadual, int transportadorId, bool isUpdate, out string mensagem);
        bool ExisteUsuario(int empresaId, int usuarioId, string email, bool isUpdate, out string mensagem);
        Produto ExisteProduto(int empresaId, string nomeProduto, decimal precoCompra, decimal precoVenda, double codigo, out string mensagem);
        bool ExisteProdutoUpdate(Produto produtoBanco, Produto produtoView, out Produto produtoAtualizaQuantidade, out string mensagem);
        Task<bool> ExisteEnderecoProduto(int empresaId, string nomeEndereco, bool isUpdate);
        bool ExisteEmpresa(int empresaId, int id, string CPFCNPJ, string inscricaoMunicipal, string inscricaoEstadual, bool isUpdate, out string mensagem);
        bool ExisteEmpresaCadastrada(int empresaId);
        bool VerificaAdministrador(int empresaId, out string mensagem);
        string AcertarNome(string nome);
        UsuarioViewModel Login(string email, string senha, out string mensagem);
        IEnumerable<UsuarioViewModel> RetornarUsuario(int empresaId);
        UsuarioViewModel RetornarUsuarioId(int usuarioId);
        UsuarioViewModel RetornarFuncionarioUsuarioId(int funcionarioId);
        IEnumerable<FuncionariosUsuariosViewModel> RetornarFuncionariosUsuario(int empresaId);
    }
}
