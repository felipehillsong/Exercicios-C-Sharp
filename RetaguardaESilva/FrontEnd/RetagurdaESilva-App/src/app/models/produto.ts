export interface Produto {
    id:number;
    nome:string;
    quantidade:number;
    ativo:boolean;
    preco:number;
    //Para a tela de detalhes
    precoFormatado:string;
    codigo:number;
    dataCadastroProduto:string;
    empresaId:number;
    fornecedorId:number;
}
