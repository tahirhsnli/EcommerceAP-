import { Component, OnInit } from '@angular/core';
import { AlertifyService, MessageType, Position } from '../../../services/admin/alertify.service';

declare var alertify: any

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {
  constructor(private aleritfy:AlertifyService){}
  
  ngOnInit(): void {
    
    
  }

  message(){
    this.aleritfy.message("Hi",MessageType.Success,Position.BottomRight,5,true)
  }

  dismiss(){
    this.aleritfy.dismiss();
  }

}
