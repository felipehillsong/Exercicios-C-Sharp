export interface Permissao {
  id:number;
  clienteCadastro: boolean;
  clienteEditar: boolean;
  clienteDetalhe: boolean;
  clienteExcluir: boolean;
  empresaCadastro: boolean;
  empresaEditar: boolean;
  empresaDetalhe: boolean;
  empresaExcluir: boolean;
  estoqueCadastro: boolean;
  estoqueEditar: boolean;
  estoqueDetalhe: boolean;
  estoqueExcluir: boolean;
  fornecedorCadastro: boolean;
  fornecedorEditar: boolean;
  fornecedorDetalhe: boolean;
  fornecedorExcluir: boolean;
  funcionarioCadastro: boolean;
  funcionarioEditar: boolean;
  funcionarioDetalhe: boolean;
  funcionarioExcluir: boolean;
  produtoCadastro: boolean;
  produtoEditar: boolean;
  produtoDetalhe: boolean;
  produtoExcluir: boolean;
  relatorioCadastro: boolean;
  relatorioEditar: boolean;
  relatorioDetalhe: boolean;
  relatorioExcluir: boolean;
  transportadorCadastro: boolean;
  transportadorEditar: boolean;
  transportadorDetalhe: boolean;
  transportadorExcluir: boolean;
  usuarioCadastro: boolean;
  usuarioEditar: boolean;
  usuarioPermissoes: boolean;
  usuarioExcluir: boolean;
  vendaCadastro: boolean;
  vendaEditar: boolean;
  vendaDetalhe: boolean;
  vendaExcluir: boolean;
  visualizarCliente: boolean;
  visualizarEstoque: boolean;
  visualizarFornecedor: boolean;
  visualizarFuncionario: boolean;
  visualizarProduto: boolean;
  visualizarTransportador: boolean;
  visualizarEmpresa: boolean;
  visualizarUsuario: boolean;
  visualizarVenda: boolean;
  visualizarRelatorio: boolean;
  empresaId: number;
  usuarioId: number;
}