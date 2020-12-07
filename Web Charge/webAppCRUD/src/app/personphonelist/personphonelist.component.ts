import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";  

import { PersonphoneServiceService } from '../service/personphone-service.service';
import { PersonPhone } from '../model/person-phone';

@Component({
  selector: 'app-personphonelist',
  templateUrl: './personphonelist.component.html',
  styleUrls: ['./personphonelist.component.css']
})
export class PersonphonelistComponent implements OnInit {


  ListPersonPhone!: PersonPhone[] ;  

  constructor(private ServicepersonPhone: PersonphoneServiceService, private router: Router, ) { }  

  ngOnInit(): void {


    this.ServicepersonPhone.getPersonPhones()  
      .subscribe((data: any) => {  
        var resultado = data;

        console.log(resultado.data.personPhoneObjects);

        this.ListPersonPhone = resultado.data.personPhoneObjects;  
      });  

  }  

  deletePersonPhone(entrada:PersonPhone){
    console.log(entrada);   
    
    this.ServicepersonPhone.deletePersonPhones(entrada).subscribe(()=>{
      this.ListPersonPhone = this.ListPersonPhone.filter(u => u !== entrada);      
    })

  }

  editPersonPhone(entrada:PersonPhone){
    entrada.PhoneNumberOld = entrada.phoneNumber;
    localStorage.removeItem('editPersonPhone');  
    localStorage.setItem('editPersonPhone', JSON.stringify(entrada));  
    this.router.navigate(['add-personphone']);  
  }
  

}
