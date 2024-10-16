import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { ProductsService } from '../../services/common/models/products.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../base/base.component';
import { DeleteDialogComponent, DeleteState } from '../../dialogs/delete-dialog/delete-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { after } from 'node:test';

declare var $ : any;

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {


  constructor(
    private element : ElementRef,
    private _rendered : Renderer2,
    private productService : ProductsService,
    public dialog: MatDialog,
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
    this.openDialog( async()=>{
      const td : HTMLTableCellElement = this.element.nativeElement;
      await this.productService.delete(this.id)
    $(td.parentElement).animate({
      opacity: 0,
      left : "+50",
      height: "toogle"
    }, 800,()=>{
      this.callback.emit();
      });
    });
  }
  openDialog(afterClosed : any) : void{
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      data: DeleteState.Yes,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result === DeleteState.Yes) {
        afterClosed();
      }
    });
  }


}
