export interface NotaFiscal {
  id:number;
  pedidoId:number;
  clienteId:number;
  nomeCliente:string;
  empresaId:number;
  transportadorId:number;
  quantidadeItens:number;
  precoTotal:number;
  dataCadastroNotaFiscal:string;
  statusNota:string;
}
