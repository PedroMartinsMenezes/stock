import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { Produto } from '../../domain/produto';
import { ProdutoService } from '../../service/produto-service';
import { ButtonModule } from 'primeng/button';
import { FloatLabel } from 'primeng/floatlabel'
import { InputTextModule } from 'primeng/inputtext';

@Component({
    selector: 'movimentacao',
    templateUrl: 'movimentacao.component.html',
    standalone: true,
    imports: [TableModule, ButtonModule],
    providers: [ProdutoService]
})

export class MovimentacaoComponent implements OnInit {

    produtos!: Produto[];

    constructor(private produtoService: ProdutoService) { }

    ngOnInit() {
        this.produtoService.listProdutos().subscribe(
            (produtos) => {
                console.log(produtos);
            },
            (error) => {
                console.error(error);
            }
        );
    }


}

