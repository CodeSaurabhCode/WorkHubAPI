import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Basket, BasketItem } from '../shared/models/basket';
import { HttpClient } from '@angular/common/http';
import { BasketModule } from './basket.module';
import { Item } from '../shared/models/items';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUrl = "https://localhost:5001/api/";

  private basketSource = new BehaviorSubject<Basket | null>(null);

  basketSource$ = this.basketSource.asObservable();

  constructor(private http : HttpClient) { }

  getBasket(id:string){
    return this.http.get<Basket>(this.baseUrl + "/Basket?id=" + id).subscribe({
      next: basket => this.basketSource.next(basket)
    })
  }

  setBasket(basket: Basket){
    return this.http.post<Basket>(this.baseUrl + 'basket', basket).subscribe({
      next: basket => this.basketSource.next(basket)
    })

  }

  getCurrentBasketValue(){
    return this.basketSource.value;
  }


  private createBasket(): Basket{
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id)
    return basket

  }

  addItemToBasket(item:Item, quantity=1){
    const itemToAdd = this.mapItemToBasketItem(item);
    const basket = this.getCurrentBasketValue() ?? this.createBasket()
    basket.items = this.addOrUpdate(basket.items, itemToAdd , quantity);
    this.setBasket(basket);

  }

  private addOrUpdate(items: BasketItem[], itemToAdd: BasketItem, quantity: number): BasketItem[] {
    const item = items.find(x => x.id ===itemToAdd.id)
    if (item) item.quantity += quantity
    else {
      itemToAdd.quantity = quantity
      items.push(itemToAdd)
    }
    return items
  }

  private mapItemToBasketItem(item: Item): BasketItem{
    return {
      id : item.id,
      itemName : item.name,
      price : item.price,
      quantity: 0,
      category: item.category
    }

  }
  
}
