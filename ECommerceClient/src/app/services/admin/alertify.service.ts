import { Injectable } from '@angular/core';
import exp from 'constants';
declare var alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  // message(message: string,messageType: MessageType,position:Position,delay:number = 3,dismissOthers:boolean = false)
  message(options:Partial<AlertifyOptions>){
    alertify.set('notifier','delay', options.delay);
    alertify.set('notifier','position', options.position);
    const mesage = alertify[options.messageType](options.message);
    if(options.dismissOthers)
      mesage.dismissOthers();
  }

  dismiss(){
    alertify.dismissAll();
  }
}

export class AlertifyOptions{
  message:string = "Null";
  messageType:MessageType = MessageType.Message;
  position:Position = Position.BottomRight;
  delay:Number = 3;
  dismissOthers:boolean = false
}

export enum MessageType {
  Error = "error",
  Message = "message",
  Notify = "notify",
  Success = "success",
  Warning = "warning"
}

export enum Position {

  TopRight = "top-right",
  TopCenter = "top-center",
  TopLeft = "top-left",
  BottomRight = "bottom-right",
  BottomCenter = "bottom-center",
  BottomLeft = "bottom-left"

}
