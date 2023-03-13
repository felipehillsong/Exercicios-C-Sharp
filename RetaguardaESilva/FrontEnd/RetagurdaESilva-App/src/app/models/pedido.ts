import { Produto } from "./produto";
export interface Pedido {
  id:number;
  clienteNome:string;
  clienteId:number;
  transportadorNome:string;
  transportadorId:number;
  usuarioId:number;
  empresaId:number;
  precoTotal:number;
  dataCadastroPedido:string;
  status:string;
  produtos: Array<Produto>;
}
