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
import { Router } from '@angular/router';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  basket:Basket;
  basket$ = this.basketService.basketSource$;
  orderType: OrderType;

  constructor(public basketService: BasketService, private homeService: HomeService,
    public accountService: AccountService, private router: Router) { }
  
  token = localStorage.getItem('token');
  basketId = localStorage.getItem('basket_id')
  orderForDate = localStorage.getItem('orderForDate')
  orderTyped = localStorage.getItem('orderType')
  ngOnInit() {
    if(this.basketId){
      this.basketService.createOrderParams.basketId = this.basketId
    };
    

    if(this.orderForDate){
      this.basketService.createOrderParams.orderForDate = new Date(this.orderForDate);
      
    }
    if(this.orderTyped)
    this.basketService.createOrderParams.orderTypeId = parseInt(this.orderTyped)
    this.getOrderType()
  }


  getBasket(){
    if(this.basketId)
    this.basketService.getBasket(this.basketId)
  }


  removeBasketItem(item: BasketItem) {
    this.basketService.removeItemFromBasket(item);
  }

  createOrder(){
    if(this.token)
    this.homeService.createOrder(this.basketService.createOrderParams, this.token).subscribe({
      next : () => this.router.navigateByUrl('/')
    })  

    // if(this.basketId)
    // this.basketService.deleteBasket(this.basketId).subscribe({
    //   next : () => console.log("BasketDeleted")})
    localStorage.removeItem('basket_id')
    localStorage.removeItem('orderForDate')
    localStorage.removeItem('orderType')
  }

  getOrderType(){
    if(this.token)
    if(this.basketService.createOrderParams.orderTypeId)
    this.homeService.getOrderType(this.basketService.createOrderParams.orderTypeId, this.token).subscribe({
      next: responce => this.orderType = responce
    })
  }
}


