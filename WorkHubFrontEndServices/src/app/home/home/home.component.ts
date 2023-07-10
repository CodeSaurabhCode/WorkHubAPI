import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';
import { Order } from 'src/app/shared/models/orders';
import { HomeService } from '../home.service';
import { OrderParams } from 'src/app/shared/models/orderParams';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  orders: Order[] = [];
  pageNumber?:number;
  pageSize?:number
  totalCount:number=0
  orderParams = new OrderParams();


  constructor(private homeService: HomeService, public accountService: AccountService){}
  token = localStorage.getItem('token')
  ngOnInit(): void {
    this.getOrders()
    console.log(this.orders)
  }

  getOrders(){
    if(this.token)
    this.homeService.getOrders(this.orderParams, this.token).subscribe({
      next : responce => {
        this.orders = responce.data;
        this.orderParams.pageNumber = responce.pageIndex;
        this.orderParams.pageSize = responce.pageSize;
        this.totalCount = responce.count;
      },
      error : error => console.log(error)
    })  
  }

  onPageChanged(event:any){
    if (this.orderParams.pageNumber !== event){
      this.orderParams.pageNumber = event;
      this.getOrders();
    }
  }

  

  changeDateFormat(){
    
  }
}
