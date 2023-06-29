import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountService } from '../account/account.service';
import { Order } from '../shared/models/orders';
import { __values } from 'tslib';
import { Pagination } from '../shared/models/pagination';
import { OrderParams } from '../shared/models/orderParams';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  baseUrl = "https://localhost:5001/api/Orders"

  constructor(private http: HttpClient){}
  
  getOrders(orderParams: OrderParams, token? : string){
    const headers = { 'Authorization': 'Bearer ' + token }
    let params = new HttpParams();
    params = params.append('pageIndex', orderParams.pageNumber)
    params = params.append('pageSize', orderParams.pageSize)
    return this.http.get<Pagination<Order[]>>(this.baseUrl, {headers, params})
  }
}
