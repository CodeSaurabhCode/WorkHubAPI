import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order.component';
import { MenuItemComponent } from './menu-item/menu-item.component';
import { SharedModule } from '../shared/shared.module';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { RouterModule } from '@angular/router';
import { OrderRoutingModule } from './order-routing.module';
import { OrderForComponent } from './order-for/order-for.component';



@NgModule({
  declarations: [
    OrderComponent,
    MenuItemComponent,
    ItemDetailsComponent,
    OrderForComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    OrderRoutingModule
  ],
  
})
export class OrderModule { }
