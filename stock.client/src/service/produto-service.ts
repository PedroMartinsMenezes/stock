import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../domain/produto';
import { MovimentacaoRequest, RelatorioResponse } from '../domain/movimentacao';

@Injectable()
export class ProdutoService {

    constructor(private http: HttpClient) { }

    listProdutos(): Observable<Produto[]> {
        return this.http.get<Produto[]>('/produto/list');
    }

    createMovimentacao(request: MovimentacaoRequest): Observable<MovimentacaoRequest> {
        return this.http.post<MovimentacaoRequest>('/movimentacao/create', request);
    }

    getEstoque(dia: Date, codigoProduto: string): Observable<RelatorioResponse[]> {
        const formattedDate = dia.toISOString().split('T')[0];
        const url = `/relatorio/getEstoque?dia=${encodeURIComponent(formattedDate)}&codigoProduto=${encodeURIComponent(codigoProduto)}`;
        return this.http.get<RelatorioResponse[]>(url);
    }

}

