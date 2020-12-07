import { Identifiers } from '@angular/compiler'

export class PersonPhone {
    businessEntityID?: number;
    phoneNumber!: string;
    phoneNumberTypeID!: number;
    phoneName!:string
    PhoneNumberOld!:string
}

export class PhoneType {
    phoneNumberTypeID!: number;
    name!:string
}