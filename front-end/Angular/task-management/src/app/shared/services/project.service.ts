import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Project,ProjectFilter, Global } from '../../imports';

@Injectable()
export class ProjectService {

    //----------------PROPERTIRS-------------------

    basicURL: string = Global.BASE_ENDPOINT + `/project`;

    filterSubject:Subject<ProjectFilter>;

    project:Project;
    //----------------CONSTRUCTOR------------------

    constructor(private http: HttpClient) { 
        this.filterSubject=new Subject<ProjectFilter>();
    }

    //----------------METHODS-------------------

    //POST
    addProject(project: Project): Observable<any> {
        let url: string = `${this.basicURL}/AddProject`;
        return this.http.post(url, project);
    }

    //GET
    getAllProjects(): Observable<any> {
        let url: string = `${this.basicURL}/getAllProjects`;
        return this.http.get(url);
    }

    //GET
    getProjectsByTeamLeaderId(teamLeaderId: number): Observable<any> {
        let url: string = `${this.basicURL}/getProjectsByTeamLeaderId?teamLeaderId=${teamLeaderId}`;
        return this.http.get(url);
    }

    //GET
    getProjectsReports(): Observable<any> {
        let url: string = `${this.basicURL}/getProjectsReports`;
        return this.http.get(url);
    }

    //POST
    checkUniqueValidation(project: Project): Observable<any> {
        let url: string = `${this.basicURL}/checkUniqueValidation`;
        return this.http.post(url, project);
    }

    initDates(projects: Project[]) {
        projects.forEach(project => {
            project.startDate = new Date(project.startDate);
            project.endDate = new Date(project.endDate);
            if (project.departmentsHours) {
                project.departmentsHours.forEach(departmentHours => {
                    if (departmentHours.department && departmentHours.department.workers) {
                        departmentHours.department.workers.forEach(worker => {
                            if (worker.presenceHours) {
                                worker.presenceHours.forEach(presenceHours => {
                                    presenceHours.startHour = new Date(presenceHours.startHour);
                                    presenceHours.endHour = new Date(presenceHours.endHour);
                                });
                            }
                        });
                    }
                })
            };
        });
    }
}