import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import AsEnumerable from 'linq-es2015';
import { Global, PresenceHours, Project, Department, User } from '../../imports';

@Injectable()
export class PresenceHoursService {

    //----------------PROPERTIRS-------------------

    basicURL: string = Global.HOST + `/presenceHours`;
    UpdatePresenceSubject: Subject<void>;
    //----------------CONSTRUCTOR------------------

    constructor(private http: HttpClient) {
        this.UpdatePresenceSubject = new Subject<void>();
    }

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
    getPresenceStatusPerWorkers(teamLeaderId: number): Observable<any> {
        let url: string = `${this.basicURL}/getPresenceStatusPerWorkers?teamLeaderId=${teamLeaderId}`;
        return this.http.get(url);
    }

    //GET
    getPresenceStatusPerProjects(workerId: number): Observable<any> {
        let url: string = `${this.basicURL}/getPresenceStatusPerProjects?workerId=${workerId}`;
        return this.http.get(url);
    }
    //GET
    getPresenceHoursSum(projectId: number, workerId: number): Observable<any> {
        let url: string = `${this.basicURL}/getPresenceHoursSum?projectId=${projectId}&workerId=${workerId}`;
        return this.http.get(url);
    }

    getPresenceHoursForProject(project: Project) {
        return AsEnumerable(project.departmentsHours).Sum(departmentHours =>
            this.getPresenceHoursForDepartment(departmentHours.department));
    }

    getPercentHoursForProject(project: Project) {
        return AsEnumerable(project.departmentsHours).Average(departmentHours =>
            departmentHours.numHours != 0 ?
                (this.getPresenceHoursForDepartment(departmentHours.department) / departmentHours.numHours <= 1 ?
                    this.getPresenceHoursForDepartment(departmentHours.department) / departmentHours.numHours : 1) : 1
        );
    }

    getPresenceHoursForDepartment(department: Department): number {
        return AsEnumerable(department.workers).Sum(worker => this.getPresenceHoursForWorker(worker));
    }

    getPresenceHoursForWorker(worker: User): number {
        return AsEnumerable(worker.presenceHours).Sum(presenceHours => (presenceHours.endHour.getTime() - presenceHours.startHour.getTime()) / 36e5);
    }

}