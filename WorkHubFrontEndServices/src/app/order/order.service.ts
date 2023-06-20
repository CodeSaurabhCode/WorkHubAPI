import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Item } from '../shared/models/items';
import { Category } from '../shared/models/category';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseUrl = "https://localhost:5001/api/"

  constructor(private http: HttpClient) { }

  getItems(CategoryId?:number, sort?:string){
    let params = new HttpParams();
    if (CategoryId) params = params.append('CategoryId', CategoryId)
    if (sort) params = params.append('sort', sort)
    return this.http.get<Pagination<Item[]>>(this.baseUrl + "Menu/items", {params});
  }

  getCategory(){
    return this.http.get<Category[]>(this.baseUrl + "Menu");
  }
}
