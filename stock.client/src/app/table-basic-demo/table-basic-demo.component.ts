import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { Product } from '../../domain/product';
import { ProductService } from '../../service/productservice';
@Component({
  selector: 'table-basic-demo',
  templateUrl: 'table-basic-demo.component.html',
  standalone: true,
  imports: [TableModule],
  providers: [ProductService]
})

export class TableBasicDemoComponent implements OnInit {
  products!: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.getProductsMini().then((data) => {
      this.products = data;
    });
  }
}

