import { Component, OnInit } from '@angular/core';
import { extend } from 'jquery';
import { BaseComponent, SpinnerType } from '../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent extends BaseComponent implements OnInit {
  constructor(spinner:NgxSpinnerService) {
    super(spinner);
    
  }
  ngOnInit(): void {
    this.showSpinner(SpinnerType.BallScaleMultiple);
    
  }
}
