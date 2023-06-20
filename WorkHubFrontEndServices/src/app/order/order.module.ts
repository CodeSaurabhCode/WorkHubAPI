import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order.component';
import { MenuItemComponent } from './menu-item/menu-item.component';



@NgModule({
  declarations: [
    OrderComponent,
    MenuItemComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    OrderComponent
  ]
})
export class OrderModule { }
