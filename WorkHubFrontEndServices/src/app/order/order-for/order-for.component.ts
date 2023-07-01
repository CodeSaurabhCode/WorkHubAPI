import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-order-for',
  templateUrl: './order-for.component.html',
  styleUrls: ['./order-for.component.scss']
})
export class OrderForComponent {
  @Output() orderedForm = new EventEmitter<any>();

  orderForm = new FormGroup({
    orderForDate : new FormControl('', Validators.required),
    orderType : new FormControl('', Validators.required),

  })

  onSubmit(){
    if (this.orderForm.valid) {
      this.orderedForm.emit(this.orderForm.value);
      this.orderForm.reset();
    } 
  }

}
