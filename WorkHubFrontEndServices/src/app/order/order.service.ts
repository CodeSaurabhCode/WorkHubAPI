import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Item } from '../shared/models/items';
import { Category } from '../shared/models/category';
import { OrderParams } from '../shared/models/orderParams';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseUrl = "https://localhost:5001/api/"

  constructor(private http: HttpClient) { }

  getItems(orderParams: OrderParams){
    let params = new HttpParams();
    if (orderParams.categoryId>0) params = params.append('CategoryId', orderParams.categoryId)
    params = params.append('pageIndex', orderParams.pageNumber)
    params = params.append('pageSize', orderParams.pageSize)
    return this.http.get<Pagination<Item[]>>(this.baseUrl + "Menu/items", {params});
  }

  getItem(id:number){
    return this.http.get<Item>(this.baseUrl + "Menu/" + id);
  }

  getCategory(){
    return this.http.get<Category[]>(this.baseUrl + "Menu");
  }
}
