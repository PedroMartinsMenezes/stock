import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TableBasicDemoComponent } from './table-basic-demo/table-basic-demo.component';
import { MovimentacaoComponent } from './movimentacao/movimentacao.component';

const routes: Routes = [
  { path: '', redirectTo: '/movimentacao', pathMatch: 'full' },
  { path: 'table-basic-demo', component: TableBasicDemoComponent },
  { path: 'movimentacao', component: MovimentacaoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
