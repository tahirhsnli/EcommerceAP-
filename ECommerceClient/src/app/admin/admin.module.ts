import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './layout/layout.module';
import { ComponetsModule } from './componets/componets.module';
import { MatSidenavModule } from '@angular/material/sidenav';





@NgModule({
  declarations: [
  
   
  ],
  imports: [
    CommonModule,
   
    LayoutModule,
    ComponetsModule,
  
   
  ],
  exports: [
    LayoutModule
  ]
})
export class AdminModule { }
