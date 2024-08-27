import { Component, OnInit } from '@angular/core';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType, ToastrOptions, ToastrPosition } from './services/ui/custom-toastr.service';
import { Position } from './services/admin/alertify.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent{
  title = 'ECommerceClient';

  constructor(private toastr:CustomToastrService){
    toastr.message("Salaam","Elnur",{
      messageType:ToastrMessageType.Success,position:ToastrPosition.TopLeft,delay:3002
    });
    toastr.message("Salaam","Elnur",{
      messageType:ToastrMessageType.Error,position:ToastrPosition.TopRight,delay:3002
    });
    toastr.message("Saaaaaaalaam","Elnur",{
      messageType:ToastrMessageType.Warning,position:ToastrPosition.BottomLeft,delay:3002
    });
    toastr.message("Salaam","Elnur",{
      messageType:ToastrMessageType.Info,position:ToastrPosition.BottomRight,delay:3002
    });
  }
}

