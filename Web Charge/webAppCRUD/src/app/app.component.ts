import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";  

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'webAppCRUD';

  constructor(private router: Router) { }  

  ngOnInit(): void {

  }  

  /**
   * AddPersonPhone
   */
  public AddPersonPhone() {
    console.log("1");
    localStorage.removeItem('editPersonPhone');
    this.router.navigate(['add-personphone']); 
  }
}
