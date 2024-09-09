import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { create } from 'domain';
import { Create_Product } from '../../../contracts/create_product';


@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClientService : HttpClientService) 
  { }

  create(product : Create_Product,successballBack?:any){
    this.httpClientService.post({
      controller:"products"
    },product).
    subscribe(result => {
      successballBack();
    });
  }
}
 