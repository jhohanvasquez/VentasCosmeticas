import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PagesComponent } from './pages.component';
import { ProductosComponent } from './productos/productos.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { VenderComponent } from './vender/vender.component';

const routes: Routes = [
  {
    path: '', component: PagesComponent, children: [
      {path:'dashboard',component:DashboardComponent},
      {path:'usuarios',component:UsuariosComponent},
      {path:'productos',component:ProductosComponent},
      {path:'vender',component:VenderComponent}
    ]
  }
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
