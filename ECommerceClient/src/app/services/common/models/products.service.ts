import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { create } from 'domain';
import { Create_Product } from '../../../contracts/create_product';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { List_Product } from '../../../contracts/list_product';
import { firstValueFrom, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClientService : HttpClientService) 
  { }

  create(product : Create_Product,successballBack?:any, errorCallBack?: (errorMessage: string) => void){
    this.httpClientService.post({
      controller:"products"
    },product).
    subscribe(result => {
      successballBack();
    }, (errorResponse : HttpErrorResponse) => {
      const _error : Array<{key:string , value : Array<string>}>= errorResponse.error;
      let message = "";
      _error.forEach((v,index) =>{
        v.value.forEach((_v,_index) => {
          message += `${_v}<br>`;
        });
      });
      errorCallBack(message);
    })
  }

  async read(page : number = 0,size : number = 5, successballBack? : () => void,errorCallBack? : (errorMessage:string) => void) : Promise<{totalCount:number;products:List_Product[]}> {
    const promiseData : Promise<{totalCount:number;products:List_Product[]}> = this.httpClientService.get<{totalCount:number;products:List_Product[]}>({
      controller:"products",
      queryString: `page=${page}&size=${size}`
    }).toPromise();

    promiseData.then(d => successballBack())
    .catch((errorResponse : HttpErrorResponse) => errorCallBack(errorResponse.message))

    return await promiseData;
  }

  async delete(id:string){
    const deleteObservable : Observable<any> = this.httpClientService.delete<any>({
      controller:"products",

    },id);

    await firstValueFrom(deleteObservable);
  }
}
 