import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Global, WorkerHours } from '../../imports';



@Injectable()
export class WorkerHoursService {

    //----------------PROPERTIRS-------------------

    basicURL: string = Global.BASE_ENDPOINT + `/workerHours`;
    changeWorkerHoursSubject: Subject<WorkerHours>;
    deleteWorkerHoursSubject: Subject<WorkerHours>;
    addWorkerHoursSubject: Subject<WorkerHours>;

    //----------------CONSTRUCTOR------------------

    constructor(private http: HttpClient) {
        this.changeWorkerHoursSubject = new Subject<WorkerHours>();
        this.deleteWorkerHoursSubject = new Subject<WorkerHours>();
        this.addWorkerHoursSubject = new Subject<WorkerHours>();

    }

    //----------------METHODS-------------------

    //GET
    getAllWorkerHours(workerId: number): Observable<any> {
        let url: string = `${this.basicURL}/getAllWorkerHours?workerId=${workerId}`;
        return this.http.get(url);
    }
 
    //PUT
    editWorkersHours(workerHours: WorkerHours): Observable<any> {
        let url: string = `${this.basicURL}/editWorkerHours`;
        return this.http.put(url, workerHours);
    }

}
