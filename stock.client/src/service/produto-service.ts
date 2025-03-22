import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../domain/produto';

@Injectable()
export class ProdutoService {

    constructor(private http: HttpClient) { }

    listProdutos(): Observable<Produto[]> {
        return this.http.get<Produto[]>('/produto/list');
    }

}

