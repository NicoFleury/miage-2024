import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { BasketItem } from 'src/app/models/BasketItem';
import { Product } from 'src/app/models/Product';
import { BasketService } from 'src/app/services/basket.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  currentUser: string = "test";

  products: Product[] = [];
  items: BasketItem[] = [];
  isLoading = true;

  constructor(
    private producteService: ProductService,
    private basketService: BasketService
  ) { }

  ngOnInit(): void {
    forkJoin({
      products: this.producteService.getAllsProducts(),
      items: this.basketService.getItemFromBasket("user")
    }).subscribe(
      results => {
        this.products = results.products;
        this.items = results.items;
        this.isLoading = false;
      }
    )
  }

  addToBasket(id: string) {
    let item = new BasketItem();
    item.productId = id;
    this.basketService.addToBasket(this.currentUser, item).subscribe(
      () => {
        this.items.push(item);
      }
    )
  }

}
