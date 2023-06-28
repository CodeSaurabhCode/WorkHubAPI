import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';
import { Order } from 'src/app/shared/models/orders';
import { HomeService } from '../home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    constructor(private homeService: HomeService, public accountService: AccountService){}

    orders = this.homeService.orders
    totalCount = this.homeService.totalCount
    pageSize = this.homeService.pageSize
    pageNumber = this.homeService.pageNumber

    user$ = this.accountService.currentUser$
    ngOnInit(): void {
      this.getOrders()
    }

    getOrders(){
      this.homeService.getOrders()
    }



}
