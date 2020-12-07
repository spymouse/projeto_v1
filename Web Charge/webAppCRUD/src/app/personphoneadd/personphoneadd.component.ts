import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";  
import { Router } from "@angular/router"; 

import { PersonphoneServiceService } from '../service/personphone-service.service';  
import { PersonPhone,PhoneType } from '../model/person-phone';

@Component({
  selector: 'app-personphoneadd',
  templateUrl: './personphoneadd.component.html',
  styleUrls: ['./personphoneadd.component.css']
})
export class PersonphoneaddComponent implements OnInit {

  empformlabel: string = 'Add PersonPhone';  
  empformbtn: string = 'Gravar';
  ListaphoneTypes!:PhoneType[];
  selectPhone!:any;
  personphone:any;

  addForm!: FormGroup;  
  btnvisibility: boolean = true;  

  constructor(private formBuilder: FormBuilder, private router: Router, private servicePersonPhone: PersonphoneServiceService) {  
  } 

  ngOnInit() {  

    this.servicePersonPhone.getPersonPhoneType()  
      .subscribe((data: any) => {  
        var resultado = data;

        console.log(resultado.data.phoneNumberTypeObjects);

        this.ListaphoneTypes = resultado.data.phoneNumberTypeObjects;  
      });  
  
    this.addForm = this.formBuilder.group({  
      businessEntityID:[],
      phoneNumber:[] ,
      phoneNumberTypeID:[],
      PhoneNumberOld:[]
    });  
  
    this.personphone = localStorage.getItem('editPersonPhone');  
    if (this.personphone!= null && this.personphone.length > 0) {  
      
      console.log("IF",this.personphone);
      var dados = JSON.parse(this.personphone!);
      this.selectPhone = dados.phoneNumberTypeID;
      this.addForm.patchValue(dados);  

      this.btnvisibility = false;  
      this.empformlabel = 'Edit Person Phone';  
      this.empformbtn = 'Update';  
    }  
  }  

  onSubmit() {  
    console.log('Create fire');  
    this.servicePersonPhone.createPersonPhone(this.addForm.value)  
      .subscribe(data => {  
        this.router.navigate(['list-personphone']);  
      },  
      error => {  
        alert("Erro ao Inserir as informações");  
      });  
  }  

  onUpdate() {  
    console.log('Update fire');  
    console.log(this.addForm.value);
    this.servicePersonPhone.updatePersonPhone(this.addForm.value)  
    .subscribe(data => {  
      this.router.navigate(['list-personphone']);  
    },  
    error => {  
      alert("Erro ao Alterar as informações");  
    });
  }  

}
