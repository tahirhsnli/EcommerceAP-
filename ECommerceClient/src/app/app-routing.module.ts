import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/componets/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';

const routes: Routes = [
  {
    path:"admin" , component:LayoutComponent , children:[
    { path: "dashboard", loadChildren:() => import("./admin/componets/dashboard/dashboard.module")
     .then(module=>module.DashboardModule) },
    { path:"customers" , loadChildren:()=> import("./admin/componets/customers/customer.module")
     .then(module=>module.CustomerModule) },
    { path:"products" , loadChildren:()=> import("./admin/componets/products/products.module")
     .then(module=>module.ProductsModule) },
    { path:"orders" , loadChildren:()=> import("./admin/componets/orders/orders.module")
     .then(module=>module.OrdersModule) }
     
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
