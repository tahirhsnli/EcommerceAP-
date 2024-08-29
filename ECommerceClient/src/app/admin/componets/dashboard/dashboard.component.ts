import { Component, OnInit } from '@angular/core';
import { AlertifyService, MessageType, Position } from '../../../services/admin/alertify.service';
import { BaseComponent, SpinnerType } from '../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';

declare var alertify: any

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent extends BaseComponent implements OnInit {
  constructor(private aleritfy:AlertifyService,spinner:NgxSpinnerService){
    super(spinner);
  }
  
  ngOnInit(): void {
    this.showSpinner(SpinnerType.BallScaleMultiple)
    
  }

  message(){
    this.aleritfy.message({
      message:"Hi",
      messageType:MessageType.Success,
      delay : 5,
      position:Position.BottomLeft,
      dismissOthers:false
    });
  }

  dismiss(){
    this.aleritfy.dismiss();
  }

}
