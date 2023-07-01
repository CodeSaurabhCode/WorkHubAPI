import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from './basket.service';
import { Observable } from 'rxjs';
import { Basket, BasketItem } from '../shared/models/basket';
import { OrderedForm } from '../shared/models/orderedForm';
import { HomeService } from '../home/home.service';
import { AccountService } from '../account/account.service';
import { CreateOrder } from '../shared/models/createOrder';
import { Item } from '../shared/models/items';
import { OrderType } from '../shared/models/orderType';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  router: any;
  basket$ = this.basketService.basketSource$;
  orderType: OrderType;

  constructor(public basketService: BasketService, private homeService: HomeService,
    public accountService: AccountService) { }
  
  token = this.accountService.token;
  basketId = this.basketService.getCurrentBasketValue()?.id
  ngOnInit() {
    this.basketService.createOrderParams.basketId = this.basketService.getCurrentBasketValue()?.id,
    this.basketService.createOrderParams.orderForDate = this.basketService.orderedFormData?.orderForDate,
    this.basketService.createOrderParams.orderTypeId = this.basketService.orderedFormData?.orderType
    this.getOrderType()
    console.log(this.orderType.typeName)
  }



  removeBasketItem(item: BasketItem) {
    this.basketService.removeItemFromBasket(item);
  }

  createOrder(){
    this.homeService.createOrder(this.basketService.createOrderParams, this.token).subscribe({
      next : () => console.log("OrderPlaced")
    })

    this.basketService.deleteBasket(this.basketId).subscribe({
      next : () => console.log("BasketDeleted")})
    this.basketService.getCurrentBasketValue()
    this.router.navigateByUrl('/');
  }

  getOrderType(){
    this.homeService.getOrderType(this.basketService.createOrderParams.orderTypeId, this.token).subscribe({
      next: responce => this.orderType = responce
    })
  }
}


