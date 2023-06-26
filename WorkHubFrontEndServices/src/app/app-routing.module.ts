import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { OrderComponent } from './order/order.component';
import { ItemDetailsComponent } from './order/item-details/item-details.component';

const routes: Routes = [
  {path:'', component:HomeComponent, data : {breadcrumb : 'Home'}},
  {path:'order', loadChildren:() => import('./order/order.module').then(m => m.OrderModule)},
  {path:'basket', loadChildren:() => import('./basket/basket.module').then(m => m.BasketModule)},
  {path:'account', loadChildren:() => import('./account/account.module').then(m => m.AccountModule)},
  {path:'**', redirectTo:'', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
