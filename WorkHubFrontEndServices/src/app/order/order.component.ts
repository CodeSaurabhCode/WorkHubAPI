import { Component, OnInit } from '@angular/core';
import { Item } from '../shared/models/items';
import { OrderService } from './order.service';
import { Category } from '../shared/models/category';
import { OrderParams } from '../shared/models/orderParams';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  Items:Item[] = [];
  Categories:Category[] = [];
  orderParams = new OrderParams();
  sortOptions = [
    {name : "Aplhabetically", value: "name"},
    {name : "Price: Low to High", value: "priceAsc"},
    {name : "Price: High to Low", value: "PriceDesc"}
  ]

  totalCount = 0;

  constructor(private orderService : OrderService){}

  ngOnInit(): void {
    this.getItems();
    this.getCategory()
  }

  getItems(){
    this.orderService.getItems(this.orderParams).subscribe({
      next : responce => {
        this.Items = responce.data;
        this.orderParams.pageNumber = responce.pageIndex;
        this.orderParams.pageSize = responce.pageSize;
        this.totalCount = responce.count;
      },
      error : error => console.log(error)
    })
  }

  getCategory(){
    this.orderService.getCategory().subscribe({
      next : responce => this.Categories = [{id:0, name:"All"}, ...responce],
      error : error => console.log(error)
    })
  }

  onCategorySelected(categoryId: number){
    this.orderParams.categoryId = categoryId;
    this.orderParams.pageNumber = 1;
    this.getItems();
  }

  onSortSelected(event: any){
    this.orderParams.sort = event.target.value;
    this.getItems();

  }

  onPageChanged(event:any){
    if (this.orderParams.pageNumber !== event){
      this.orderParams.pageNumber = event;
      this.getItems();
    }
  }

}
