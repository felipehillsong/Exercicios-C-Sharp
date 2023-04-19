import { Cliente } from "./cliente";
import { Empresa } from "./empresa";
import { Produto } from "./produto";
import { Transportador } from "./transportador";

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
  cliente: Array<Cliente>;
  empresa: Array<Empresa>;
  transportador: Array<Transportador>;
  produto: Array<Produto>;
}
