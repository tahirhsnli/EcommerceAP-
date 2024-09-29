import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { ProductsService } from '../../services/common/models/products.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../base/base.component';

declare var $ : any;

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {


  constructor(
    private element : ElementRef,
    private _rendered : Renderer2,
    private productService : ProductsService
  ) 
  {
    const img = _rendered.createElement("img");
    img.setAttribute("src","../../../../../assets/delete.png");
    img.setAttribute("style","cursor:pointer;")
    img.width = 30;
    img.height = 30;
    _rendered.appendChild(element.nativeElement ,img);
  }

  @Input() id : string;
  @Output() callback : EventEmitter<any> = new EventEmitter();
  @HostListener("click")
  async onClick(){
    const td : HTMLTableCellElement = this.element.nativeElement;
    await this.productService.delete(this.id)
    $(td.parentElement).fadeOut(2000 , () => {
      this.callback.emit();
    });
  }


}
