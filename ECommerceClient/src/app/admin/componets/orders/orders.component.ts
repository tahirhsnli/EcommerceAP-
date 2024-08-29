import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from '../../../base/base.component';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss'
})
export class OrdersComponent extends BaseComponent implements OnInit {
  constructor(spinner:NgxSpinnerService) {
    super(spinner);
    
  }
  ngOnInit(): void {
    this.showSpinner(SpinnerType.BallScaleMultiple);
    
  }
  

}
