import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule, Routes } from '@angular/router';
import { OrderComponent } from './order.component';
import { ItemDetailsComponent } from './item-details/item-details.component';

const routes: Routes = [
  {path:'', component:OrderComponent},
  {path:':id', component:ItemDetailsComponent},
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ], 
  exports : [
    RouterModule
  ]
})
export class OrderRoutingModule { }
