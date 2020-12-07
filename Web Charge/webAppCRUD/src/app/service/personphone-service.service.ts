import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { PersonPhone } from '../model/person-phone';
import { HttpHeaders } from '@angular/common/http'; 

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class PersonphoneServiceService {

  constructor(private http: HttpClient) { }  
  baseUrl: string = 'http://localhost:5000/api/';  
  
  getPersonPhones() {  
    return this.http.get<PersonPhone[]>(this.baseUrl+'PersonPhone');  
  } 

  deletePersonPhones(entrada: PersonPhone) {  
    return this.http.post(this.baseUrl+'PersonPhone/Excluir',entrada,httpOptions);  
  }  

  createPersonPhone(entrada: PersonPhone) { 
    if(entrada.businessEntityID == null) {
      entrada.businessEntityID = 1;
    }
    return this.http.post(this.baseUrl+'PersonPhone/Inserir', entrada,httpOptions);  
  }  

  getPersonPhoneById(id: number) {  
    return this.http.get<PersonPhone>(this.baseUrl+'PersonPhone'+'/' + id);  
  }  

  updatePersonPhone(entrada: PersonPhone) {  
    return this.http.put(this.baseUrl+'PersonPhone/Alterar', entrada,httpOptions);  
  }

  getPersonPhoneType(){
    return this.http.get<PersonPhone[]>(this.baseUrl+'PersonPhone/GetPhoneNumberType');  
  }
}
