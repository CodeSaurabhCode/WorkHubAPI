import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountService } from '../account/account.service';
import { Order } from '../shared/models/orders';
import { __values } from 'tslib';
import { Pagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  orders: Order[] = [];
  pageNumber?:number;
  pageSize?:number
  totalCount:number=0


  baseUrl = "https://localhost:5001/api/Orders"

  constructor(private http: HttpClient, private accountService: AccountService){}
  user$ = this.accountService.currentUser$
  data:any;
  
  getOrders(){
    this.accountService.currentUser$.subscribe(__values => this.data == __values)
    const headers = { 'Authorization': 'Bearer ' + this.accountService.token}
    console.log(this.accountService.token)
    this.http.get<Pagination<Order[]>>(this.baseUrl, {headers}).subscribe({
      next : responce => {
        this.orders = responce.data;
        this.pageNumber = responce.pageIndex;
        this.pageSize = responce.pageSize;
        this.totalCount = responce.count;
      },
      error : error => console.log(error)
    })
  }
}
