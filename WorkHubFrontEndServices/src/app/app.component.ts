import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'WorkHub';
  constructor(private basketService: BasketService, private accountService: AccountService){}

  ngOnInit(): void {
    this.loadCurrentUser();
    this.loadBasket()
    console.log(localStorage.getItem('basket_id'))
    console.log(this.basketService.basketSource$)
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    if(token){
      this.accountService.loadCurrentUser(token).subscribe();
    }
  }

  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) this.basketService.getBasket(basketId);
  }

}
