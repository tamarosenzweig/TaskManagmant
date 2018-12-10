import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Global } from '../../imports';



@Injectable()
export class CustomerService {
    
    //----------------PROPERTIRS-------------------

    basicURL: string = Global.HOST + `/customer`;

    //----------------CONSTRUCTOR------------------

    constructor(private http: HttpClient) { }

    //----------------METHODS-------------------
    
    //GET
    getAllCustomers(): Observable<any> {
        let url: string = `${this.basicURL}/getAllCustomers`;
        return this.http.get(url);
    }


}
