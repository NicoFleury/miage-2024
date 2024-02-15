import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/Product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  id: string = '';
  label: string = '';
  price: number = 0;
  description: string = '';

  isLoading = true;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe( params => {
      console.log(params['id']);
      if(params['id']) {
        this.productService.getProduct(params['id']).subscribe(
          result => {
            this.id = result.id;
            this.label = result.label;
            this.description = result.description;
            this.price = result.price;
            this.isLoading = false;
          }
        )
      } else {
        this.isLoading = false;
      }

     });
  }

  saveProduct() {
    let product = new Product();
    product.label = this.label;
    product.price = this.price;
    product.description = this.description;
    if(this.id != '') {
      this.productService.updateProduct(this.id, product).subscribe(
        () => this.router.navigate([''])
      );
    } else {
      this.productService.addProduct(product).subscribe(
        () => this.router.navigate([''])
      );
    }
  }

}
