import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/shared/models/items';
import { OrderService } from '../order.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent implements OnInit{
  item?: Item;

  constructor(private orderService : OrderService, private activatedRoute: ActivatedRoute){

  }

  ngOnInit(): void {
    this.loadItem()
  }

  loadItem(){
    const id = this.activatedRoute.snapshot.paramMap.get('id')
    if (id) this.orderService.getItem(+id).subscribe({
      next: item => this.item = item,
      error: error => console.log(error)
    })

  }

}
