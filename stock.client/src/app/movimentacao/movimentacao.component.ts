import { Component, OnInit, signal } from '@angular/core';
import { FormsModule, FormBuilder, FormGroup } from '@angular/forms';
//Domain
import { Produto } from '../../domain/produto';
//Service
import { ProdutoService } from '../../service/produto-service';
//PrimeNG
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { CheckboxModule } from 'primeng/checkbox';
import { DatePickerModule } from 'primeng/datepicker';
import { DropdownModule } from 'primeng/dropdown';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { MessageService } from 'primeng/api';
import { PanelModule } from 'primeng/panel';
import { SelectModule } from 'primeng/select';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { MovimentacaoRequest, RelatorioResponse } from '../../domain/movimentacao';

interface City {
    name: string;
    code: string;
}

interface TipoMovimentacao {
    nome: string;
    valor: number;
}

@Component({
    selector: 'movimentacao',
    templateUrl: 'movimentacao.component.html',
    standalone: true,
    imports: [
        ButtonModule, CheckboxModule, InputTextModule, TableModule, FloatLabelModule, FormsModule, DropdownModule, 
        InputGroupModule, InputGroupAddonModule, SelectModule, InputNumberModule, CardModule, PanelModule, ToastModule,
        DatePickerModule
    ],
    providers: [ProdutoService, MessageService]
})
export class MovimentacaoComponent implements OnInit {

    request = new MovimentacaoRequest(1, 0, '');
    movimentacaoSelecionada: TipoMovimentacao = { nome: '', valor: 0 };
    tiposMovimentacao: TipoMovimentacao[] = [
        { nome: 'Entrada', valor: 1 },
        { nome: 'Saída', valor: 2 }
    ];
    diaEstoque: Date = new Date();
    codigoProduto: string = '';
    relatorioResponse: RelatorioResponse[] = [];
    //
    visible = signal(true);
    value: string = '';
    formGroup!: FormGroup;
    checked: boolean = false;
    produtos: Produto[] = [];
    value1: string = '';
    value2: string = '';
    value3: string = '';
    text1: string = '';
    text2: string = '';
    text3: string = '';
    quantidade: number = 0;
    inputNumber1: number = 42723;
    inputNumber2: number = 58151;
    inputNumber3: number = 2351.35;
    inputNumber4: number = 50;
    selectedCity: City | undefined;

    cities: City[] = [
        { name: 'New York', code: 'NY' },
        { name: 'Rome', code: 'RM' },
        { name: 'London', code: 'LDN' },
        { name: 'Istanbul', code: 'IST' },
        { name: 'Paris', code: 'PRS' },
    ];

    constructor(
        private produtoService: ProdutoService,
        private fb: FormBuilder,
        private messageService: MessageService
    ) { }

    ngOnInit() {
        this.getEstoque();     
    }

    showError(message: string) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: message, life: 5000  });
    }

    showInfo(message: string) {
        this.messageService.add({ severity: 'success', summary: 'Sucesso', detail: message, life: 5000 });
    }

    showMessage() {
        this.visible.set(true);
        setTimeout(() => {
            this.visible.set(false);
        }, 3500);
    }

    createMovimentacao() {
        this.produtoService.createMovimentacao(this.request).subscribe(
            (response) => {
                this.showInfo('Movimentação criada com sucesso!');
            },
            (error) => {
                this.showError('Erro ao criar movimentação: \n' + (error.error || error.message));
            }
        );
    }

    getEstoque() {
        this.produtoService.getEstoque(this.diaEstoque, this.codigoProduto).subscribe(
            (response) => {
                this.relatorioResponse = response;
                console.log(response);
            },
            (error) => {
                this.showError('Erro ao gerar o relatório: \n' + (error.error || error.message));
            }
        );
    }

}

