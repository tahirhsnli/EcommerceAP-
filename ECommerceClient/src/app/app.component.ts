import { Component, OnInit } from '@angular/core';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType, ToastrOptions, ToastrPosition } from './services/ui/custom-toastr.service';
import { Position } from './services/admin/alertify.service';
import { timeout } from 'rxjs';
import { time } from 'console';

import * as $ from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'ECommerceClient';
  ngOnInit(): void {
   
  }

    
}
// $.get("https://localhost:7184/api/products")


