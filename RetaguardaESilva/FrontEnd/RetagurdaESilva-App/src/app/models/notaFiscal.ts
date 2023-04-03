export interface NotaFiscal {
  id:number;
  pedidoId:number;
  clienteId:number;
  empresaId:number;
  transportadorId:number;
  quantidadeItens:number;
  precoTotal:number;
  dataCadastroNotaFiscal:string;
  status:number;
}
