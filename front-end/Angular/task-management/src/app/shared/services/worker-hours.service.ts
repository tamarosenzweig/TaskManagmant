import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Global, WorkerHours } from '../../imports';



@Injectable()
export class WorkerHoursService {

    //----------------PROPERTIRS-------------------

    basicURL: string = Global.HOST + `/workerHours`;
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

      //POST
      hasUncomletedHours(workerId: number,projectIdList:number[]): Observable<any> {
        let url: string = `${this.basicURL}/hasUncomletedHours`;
        let formData:FormData=new FormData()
        formData.append('workerId',workerId.toString());
        formData.append('projectIdList',JSON.stringify(projectIdList));
        return this.http.post(url,formData);
    }
 
    //PUT
    editWorkerHours(workerHours: WorkerHours): Observable<any> {
        let url: string = `${this.basicURL}/editWorkerHours`;
        return this.http.put(url, workerHours);
    }

}
