import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CustomToastrService {

  constructor(private toastr:ToastrService) { }
  message(message:string,title:string,toastrOptions:Partial<ToastrOptions>){
    this.toastr[toastrOptions.messageType](message,title,{positionClass:toastrOptions.position,timeOut:toastrOptions.delay});
  
  }
  
}

export class ToastrOptions{
  messageType:ToastrMessageType;
  position:ToastrPosition;
  delay:number
}

export enum ToastrMessageType {
  Error = "error",
  Success = "success",
  Warning = "warning",
  Info = "info"
}

export enum ToastrPosition{
  TopRight = "toast-top-right",
  TopCenter = "toast-top-center",
  TopLeft = "toast-top-left",
  BottomRight = "toast-bottom-right",
  BottomCenter = "toast-bottom-center",
  BottomLeft = "toast-bottom-left",
  TopFullWidth ="toast-top-full-width",
  BottomFullWidth ="toast-bottom-full-width"
}