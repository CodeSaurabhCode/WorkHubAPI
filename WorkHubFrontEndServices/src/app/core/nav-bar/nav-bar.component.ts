import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { Basket, BasketItem } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit{

  basket:Basket

  basketId = localStorage.getItem('basket_id')

  constructor(public basketService: BasketService, public accountService: AccountService){}
  ngOnInit(): void {
    this.getBasket()
  }

  getBasket(){
    if(this.basketId)
    this.basketService.getBasket(this.basketId)
  }

  logout() {
    this.accountService.logout();
  }


}
