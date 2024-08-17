import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/componets/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';

const routes: Routes = [
  {
    path:"admin" , component:LayoutComponent , children:[
    {path: "", component:DashboardComponent},
    {path:"customers" , loadChildren:()=> import("./admin/componets/customers/customer.module").then(module=>module.CustomerModule)}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
