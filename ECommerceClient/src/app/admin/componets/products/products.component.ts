import { Component, OnInit } from '@angular/core';
import { data, extend } from 'jquery';
import { BaseComponent, SpinnerType } from '../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { HttpClient } from '@angular/common/http';
import { HttpClientService } from '../../../services/common/http-client.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent extends BaseComponent implements OnInit {
  constructor(spinner:NgxSpinnerService,private httpClientService : HttpClientService) {
    super(spinner);
    
  }
  ngOnInit(): void {
    this.showSpinner(SpinnerType.BallScaleMultiple);
    // this.httpClientService.get({
    //   controller:"products"
    // }).subscribe(data => console.log(data));
    
    // this.httpClientService.post({
    //   controller: "products"    
    // },{
    //   name:"heyva",
    //   stock:20,
    //   price:4
    // }).subscribe();

    // this.httpClientService.put({
    //   controller:"products"
    // },{
    //   id:"1aa69565-fa0a-4b64-9acd-337f26009bf7",
    //   name:"heva",
    //   stock:200
    // }).subscribe();

    // this.httpClientService.delete({
    //   controller:"products"
    // },"1aa69565-fa0a-4b64-9acd-337f26009bf7").subscribe();

    this.httpClientService.get({
      fullEndPoint:"https://jsonplaceholder.typicode.com/posts"
    }).subscribe(data => console.log(data))
  }
}
