using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetaguardaESilva.Domain.Models
{
    public class Permissao
    {
        public int Id { get; set; }
        public bool VisualizarCliente { get; set; }
        public bool ClienteCadastro { get; set; }
        public bool ClienteEditar { get; set; }
        public bool ClienteDetalhe { get; set; }
        public bool ClienteExcluir { get; set; }
        public bool VisualizarEmpresa { get; set; }
        public bool EmpresaCadastro { get; set; }
        public bool EmpresaEditar { get; set; }
        public bool EmpresaDetalhe { get; set; }
        public bool EmpresaExcluir { get; set; }
        public bool VisualizarEstoque { get; set; }
        public bool EstoqueEditar { get; set; }
        public bool EstoqueDetalhe { get; set; }
        public bool EstoqueExcluir { get; set; }
        public bool VisualizarEnderecoProduto { get; set; }
        public bool EnderecoProdutoCadastro { get; set; }
        public bool EnderecoProdutoEditar { get; set; }
        public bool EnderecoProdutoDetalhe { get; set; }
        public bool EnderecoProdutoExcluir { get; set; }
        public bool VisualizarFornecedor { get; set; }
        public bool FornecedorCadastro { get; set; }
        public bool FornecedorEditar { get; set; }
        public bool FornecedorDetalhe { get; set; }
        public bool FornecedorExcluir { get; set; }
        public bool VisualizarFuncionario { get; set; }
        public bool FuncionarioCadastro { get; set; }
        public bool FuncionarioEditar { get; set; }
        public bool FuncionarioDetalhe { get; set; }
        public bool FuncionarioExcluir { get; set; }
        public bool VisualizarProduto { get; set; }
        public bool ProdutoCadastro { get; set; }
        public bool ProdutoEditar { get; set; }
        public bool ProdutoDetalhe { get; set; }
        public bool ProdutoExcluir { get; set; }
        public bool VisualizarRelatorio { get; set; }
        public bool RelatorioCadastro { get; set; }
        public bool RelatorioEditar { get; set; }
        public bool RelatorioDetalhe { get; set; }
        public bool RelatorioExcluir { get; set; }
        public bool VisualizarTransportador { get; set; }
        public bool TransportadorCadastro { get; set; }
        public bool TransportadorEditar { get; set; }
        public bool TransportadorDetalhe { get; set; }
        public bool TransportadorExcluir { get; set; }
        public bool VisualizarUsuario { get; set; }
        public bool UsuarioCadastro { get; set; }
        public bool UsuarioEditar { get; set; }
        public bool UsuarioPermissoes { get; set; }
        public bool UsuarioExcluir { get; set; }
        public bool VisualizarVenda { get; set; }
        public bool VendaCadastro { get; set; }
        public bool VendaEditar { get; set; }
        public bool VendaDetalhe { get; set; }
        public bool VendaExcluir { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
    }
}
