import { Component, OnInit } from '@angular/core';
import { Item } from '../shared/models/items';
import { OrderService } from './order.service';
import { Category } from '../shared/models/category';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  Items:Item[] = [];
  Categories:Category[] = [];
  CategoryIdSelected = 0;
  sortSelected = "name";
  sortOptions = [
    {name : "Aplhabetically", value: "name"},
    {name : "Price: Low to High", value: "priceAsc"},
    {name : "Price: High to Low", value: "PriceDesc"}
  ]

  constructor(private orderService : OrderService){}

  ngOnInit(): void {
    this.getItems();
    this.getCategory()
  }

  getItems(){
    this.orderService.getItems(this.CategoryIdSelected, this.sortSelected).subscribe({
      next : responce => this.Items = responce.data,
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
    this.CategoryIdSelected = categoryId;
    this.getItems();
  }

  onSortSelected(event: any){
    this.sortSelected = event.target.value;
    this.getItems();

  }

}
