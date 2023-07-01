import { Component, OnInit } from '@angular/core';
import { Item } from '../shared/models/items';
import { OrderService } from './order.service';
import { Category } from '../shared/models/category';
import { OrderParams } from '../shared/models/orderParams';
import { OrderedForm } from '../shared/models/orderedForm';
import { BasketService } from '../basket/basket.service';
import { AccountService } from '../account/account.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  Items:Item[] = [];
  Categories:Category[] = [];
  orderParams = new OrderParams();
  orderedForm? : OrderedForm
  totalCount = 0;

  constructor(private orderService : OrderService, private basketService: BasketService,
    public accountService: AccountService){}

  ngOnInit(): void {

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

  onPageChanged(event:any){
    if (this.orderParams.pageNumber !== event){
      this.orderParams.pageNumber = event;
      this.getItems();
    }
  }

  receiveOrderedForm(data: OrderedForm){
    this.orderedForm = data;
    console.log(this.orderedForm)
    this.getItems()
    this.basketService.getOrderedFormData(data)
    if (this.orderedForm.orderType === 1){
      this.onCategorySelected(1);
    } else{
      this.getCategory()
    }
  }

}
