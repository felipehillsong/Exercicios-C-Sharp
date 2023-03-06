export interface Produto {
    id:number;
    nome:string;
    quantidade:number;
    quantidadeVenda:number;
    ativo:boolean;
    precoCompra:number;
    precoVenda:number;
    precoCompraFormatado:string;
    precoVendaFormatado:string;
    codigo:number;
    dataCadastroProduto:string;
    empresaId:number;
    fornecedorId:number;
}
