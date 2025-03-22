export class MovimentacaoRequest {
    tipo?: number;
    quantidade?: number;
    codigoProduto?: string;

    constructor(tipo?: number, quantidade?: number, codigoProduto?: string) {
        this.tipo = tipo;
        this.quantidade = quantidade;
        this.codigoProduto = codigoProduto;
    }
}

export interface RelatorioResponse {
    nomeProduto?: string;
    codigoProduto?: string;
    entradas?: number;
    saidas?: number;
    saldo?: number;
}

