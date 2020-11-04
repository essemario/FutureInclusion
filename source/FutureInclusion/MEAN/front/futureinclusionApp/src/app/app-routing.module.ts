import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListUsuariosComponent } from './list-usuarios/list-usuarios.component';


const routes: Routes = [
  { path: '', component: ListUsuariosComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
