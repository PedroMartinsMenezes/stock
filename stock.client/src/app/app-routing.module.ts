import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TableBasicDemoComponent } from './table-basic-demo/table-basic-demo.component';

const routes: Routes = [
  { path: '', redirectTo: '/table-basic-demo', pathMatch: 'full' },
  { path: 'table-basic-demo', component: TableBasicDemoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
