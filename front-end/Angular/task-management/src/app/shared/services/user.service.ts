import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import * as sha256 from 'async-sha256';
import { MenuService, Login,User, eStatus, Email,ChangePassword, Global } from '../../imports';

@Injectable()
export class UserService {

    //----------------PROPERTIRS-------------------

    basicURL: string = Global.HOST + `/user`;
    updateUserListSubject: Subject<void>;
    resetPermissionSubject: Subject<void>;

    //----------------CONSTRUCTOR------------------

    constructor(private http: HttpClient, private router: Router, private menuService: MenuService) {
        this.updateUserListSubject = new Subject<void>();
        this.resetPermissionSubject = new Subject<void>();
    }

    //----------------METHODS-------------------

    //POST
    login(email: string, password: string): Observable<any> {
        let url: string = `${this.basicURL}/login`;
        let data = new Login(email, password);
        return this.http.post(url, data);
    }

    //GET
    getAllUsers(): Observable<any> {
        let managerId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;
        let url: string = `${this.basicURL}/getAllUsers?managerId=${managerId}`;
        return this.http.get(url);
    }
    //  //GET
    //php
    // getAllUsers(): Observable<any> {
    //     let url: string = "http://localhost:8080/task_management/web_api.php?funcation=getAllWorkers";        ;
    //     return this.http.get(url);
    // }
    //GET
    getAllTeamUsers(teamLeaderId: number): Observable<any> {
        let url: string = `${this.basicURL}/getAllTeamUsers?teamLeaderId=${teamLeaderId}`;
        return this.http.get(url);
    }

    //GET
    getAllTeamLeaders(): Observable<any> {
        let managerId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;
        let url: string = `${this.basicURL}/getAllTeamLeaders?managerId=${managerId}`;
        return this.http.get(url);
    }

    //GET
    getUserById(userId: number): Observable<any> {
        let url: string = `${this.basicURL}/getUserById?userId=${userId}`;
        return this.http.get(url);
    }
    //GET
    HasWorkers(teamLeaderId: number): Observable<any> {
        let url: string = `${this.basicURL}/HasWorkers?teamLeaderId=${teamLeaderId}`;
        return this.http.get(url);
    }

    //POST
    addUser(user: User): Observable<any> {
        let url: string = `${this.basicURL}/addUser`;
        return this.http.post(url, user);
    }

    //PUT
    editUser(user: User): Observable<any> {
        let url: string = `${this.basicURL}/editUser`;
        return this.http.put(url, user);
    }

    //POST
    deleteUser(user: User): Observable<any> {
        //move user profile image to archives if exist
        if (user.profileImageName)
            this.removeUploadedImage(user.profileImageName, true).subscribe(()=>{});
        let url: string = `${this.basicURL}/deleteUser?userId=${user.userId}`;
        return this.http.post(url, null);
    }

    //POST
    uploadImageProfile(image: any): Observable<any> {
        let url: string = `${this.basicURL}/uploadImageProfile`;
        let formData: FormData = new FormData();
        formData.append('file', image, image.name);
        return this.http.post(url, formData);
    }

    //POST
    removeUploadedImage(profileImageName: string, moveToArchives: boolean): Observable<any> {
        let url: string = this.basicURL + `/removeUploadedImage`;
        let formData: FormData = new FormData();
        formData.append('profileImageName', profileImageName);
        formData.append('moveToArchives', String(moveToArchives));
        return this.http.post(url, formData);
    }

    //POST
    sendEmail(email: Email): Observable<any> {
        let url: string = this.basicURL + `/sendEmail`;
        let formData: FormData = new FormData();
        formData.append('email', JSON.stringify(email));
        formData.append('user', localStorage.getItem(Global.USER));
        return this.http.post(url, formData);
    }

    //POST
    checkUniqueValidations(user: User): Observable<any> {
        let url: string = `${this.basicURL}/checkUniqueValidations`;
        return this.http.post(url, user);
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem(Global.USER);
        localStorage.removeItem(Global.STATUS);
        this.menuService.setMenu(null);
    }
    navigateByStatus() {
        if (localStorage.getItem(Global.STATUS) == null) {
            this.router.navigate(['taskManagement/login']);
        }
        let status: eStatus = <eStatus>+localStorage.getItem(Global.STATUS);
        if (status == eStatus.MANAGER) {
            this.router.navigate(['taskManagement/manager/userManagement']);
        }
        else
            if (status == eStatus.TEAM_LEADER) {
                this.router.navigate(['taskManagement/teamLeader/workerHoursManagement/projectHoursList']);
            }
            else//status == eStatus.WORKER {
                this.router.navigate(['taskManagement/worker/home']);
    }
    async hashValue(val: string) {
        let hashVal = await sha256(val);
        return hashVal;
    }
    //GET
    getUserByEmail(email: string): Observable<any> {
        let url: string = `${this.basicURL}/getUserByEmail?email=${email}`;
        return this.http.get(url);
    }
    //POST
    forgotPassword(email: string): Observable<any> {
        let url: string = `${this.basicURL}/forgotPassword?email=${email}`;
        return this.http.post(url, null);
    }

    //POST
    confirmToken(changePassword: ChangePassword): Observable<any> {
        let url: string = `${this.basicURL}/confirmToken`;
        return this.http.post(url, changePassword);
    }

    //POST
    changePassword(user: User): Observable<any> {
        let url: string = `${this.basicURL}/changePassword`;
        return this.http.put(url, user);
    }


}