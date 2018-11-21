import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Global, PresenceHours, } from '../../imports';



@Injectable()
export class PresenceHoursService {

    //----------------PROPERTIRS-------------------

    basicURL: string = Global.BASE_ENDPOINT + `/presenceHours`;

    //----------------CONSTRUCTOR------------------

    constructor(private http: HttpClient) { }

    //----------------METHODS-------------------

    //POST
    addPresenceHours(presenceHours: PresenceHours): Observable<any> {
        let url: string = `${this.basicURL}/addPresenceHours`;
        return this.http.post(url, presenceHours);
    }

    //PUT
    editPresenceHours(presenceHours: PresenceHours): Observable<any> {
        let url: string = `${this.basicURL}/editPresenceHours`;
        return this.http.put(url, presenceHours);
    }

    //GET
    getPresenceStatusPerWorkers(teamLeaderId: number):Observable<any> {
        let url: string = `${this.basicURL}/getPresenceStatusPerWorkers?teamLeaderId=${teamLeaderId}`;
        return this.http.get(url);
    }

    //GET
    getPresenceStatusPerProjects(workerId: number): Observable<any> {
        let url: string = `${this.basicURL}/getPresenceStatusPerProjects?workerId=${workerId}`;
        return this.http.get(url);
    }
}