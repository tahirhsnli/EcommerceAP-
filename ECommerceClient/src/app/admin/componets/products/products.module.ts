import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component';
import { RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import { CreateComponent } from './create/create.component';
import { ReadComponent } from './read/read.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';



@NgModule({
  declarations: [
    ProductsComponent,
    CreateComponent,
    ReadComponent
  ],
  imports: [
    CommonModule,
    MatSidenavModule, MatFormFieldModule, MatInputModule, MatButtonModule,
    RouterModule.forChild([
      { path:"",component:ProductsComponent }
    ])
  ]
})
export class ProductsModule { }
