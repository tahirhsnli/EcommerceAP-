import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../../../services/common/models/products.service';
import { Create_Product } from '../../../../contracts/create_product';
import { BaseComponent, SpinnerType } from '../../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { AlertifyOptions, AlertifyService, MessageType, Position } from '../../../../services/admin/alertify.service';
import { error } from 'console';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent extends BaseComponent implements OnInit {

  constructor(spinner : NgxSpinnerService,private productService : ProductsService,private aleritfy : AlertifyService){
    super(spinner);
  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  create(Name : HTMLInputElement,Stock : HTMLInputElement,Price : HTMLInputElement){

    this.showSpinner(SpinnerType.BallScaleMultiple)

    const create_product : Create_Product = new Create_Product();

    create_product.name = Name.value;
    create_product.stock = parseInt(Stock.value);
    create_product.price = parseFloat(Price.value);

    this.productService.create(create_product, () => {
      this.hideSpinner(SpinnerType.Ballatom);
      this.aleritfy.message({
        message : "basarili",
        dismissOthers : true,
        messageType : MessageType.Success,
        position : Position.TopRight
      });
    },errorMessage => {
      this.aleritfy.message({
        message:errorMessage,
        dismissOthers:true,
        messageType:MessageType.Error,
        position:Position.TopRight
      })
    });
  }

}
