import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';  

import { PersonphoneaddComponent } from './personphoneadd/personphoneadd.component';
import { PersonphonelistComponent } from './personphonelist/personphonelist.component';

// const routes: Routes = [];

const routes: Routes = [  
  { path: '', component: PersonphonelistComponent, pathMatch: 'full' },  
  { path: 'list-personphone', component: PersonphonelistComponent },  
  { path: 'add-personphone', component: PersonphoneaddComponent }  
];  


@NgModule({  
  imports: [  
    CommonModule,  
    RouterModule.forRoot(routes)  
  ],  
  exports: [RouterModule],  
  declarations: []  
})  
export class AppRoutingModule { } 
