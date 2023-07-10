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
      const formValues = this.orderForm.value;
      if(formValues.orderForDate)
      localStorage.setItem('orderForDate', formValues.orderForDate)
      if(formValues.orderType)
      localStorage.setItem('orderType', formValues.orderType)
      this.orderedForm.emit(this.orderForm.value);
    } 
  }

  onReset(){
    localStorage.removeItem('orderForDate')
    localStorage.removeItem('orderType')
    this.orderForm.reset();
    
  }
}
