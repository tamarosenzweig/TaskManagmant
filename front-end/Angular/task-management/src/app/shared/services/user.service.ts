import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import * as sha256 from 'async-sha256';
import { MenuService, Login, User, eStatus, Email, ChangePassword, Global } from '../../imports';

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
        let login = new Login(email, password);
        return this.http.post(url, login);
    }

    //GET
    getAllUsers(): Observable<any> {
        let managerId: number = Global.CURRENT_USER.userId;
        let url: string = `${this.basicURL}/getAllUsers?managerId=${managerId}`;
        return this.http.get(url);
    }

    //GET
    getAllTeamUsers(teamLeaderId: number): Observable<any> {
        let url: string = `${this.basicURL}/getAllTeamUsers?teamLeaderId=${teamLeaderId}`;
        return this.http.get(url);
    }

    //GET
    getAllTeamLeaders(): Observable<any> {
        let managerId: number = Global.CURRENT_USER.userId;
        let url: string = `${this.basicURL}/getAllTeamLeaders?managerId=${managerId}`;
        return this.http.get(url);
    }

    //GET
    getUserById(userId: number): Observable<any> {
        let url: string = `${this.basicURL}/getUserById?userId=${userId}`;
        return this.http.get(url);
    }

    //GET
    getUserByEmail(email: string): Observable<any> {
        let url: string = `${this.basicURL}/getUserByEmail?email=${email}`;
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
            this.removeUploadedImage(user.profileImageName, true).subscribe(() => { });
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
        let url: string = `${this.basicURL}/removeUploadedImage`;
        let formData: FormData = new FormData();
        formData.append('profileImageName', profileImageName);
        formData.append('moveToArchives', String(moveToArchives));
        return this.http.post(url, formData);
    }

    //POST
    sendEmail(email: Email): Observable<any> {
        let url: string = `${this.basicURL}/sendEmail`;
        let formData: FormData = new FormData();
        formData.append('email', JSON.stringify(email));
        formData.append('user', JSON.stringify(Global.CURRENT_USER));
        return this.http.post(url, formData);
    }

    //POST
    checkUniqueValidations(user: User): Observable<any> {
        let url: string = `${this.basicURL}/checkUniqueValidations`;
        return this.http.post(url, user);
    }

    //GET
    hasWorkers(teamLeaderId: number): Observable<any> {
        let url: string = `${this.basicURL}/hasWorkers?teamLeaderId=${teamLeaderId}`;
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

    logout() {
        // remove user from global and local storage to log user out
        Global.CURRENT_USER = null;
        localStorage.clear();
        this.menuService.setMenu(null);
    }

    async navigateByStatus() {
        if (localStorage.getItem(Global.STATUS) == null || localStorage.getItem(Global.CURRENT_USER_ID) == null) {
            localStorage.clear();
            this.router.navigate(['taskManagement/login']);
        }
        let currentUserId: string = localStorage.getItem(Global.CURRENT_USER_ID);
        let user: User = await this.getUserById(+currentUserId).toPromise();
        if (user) {
            Global.CURRENT_USER = user;
            let status: eStatus = <eStatus>+localStorage.getItem(Global.STATUS);
            if (status == eStatus.MANAGER) {
                this.router.navigate(['taskManagement/manager/userManagement']);
            }
            else {
                if (status == eStatus.TEAM_LEADER) {
                    this.router.navigate(['taskManagement/teamLeader/workerHoursManagement/projectHoursList']);
                }
                else//status == eStatus.WORKER 
                {
                    this.router.navigate(['taskManagement/worker/home']);
                }
            }

        }
        else {
            localStorage.clear();
            this.router.navigate(['taskManagement/login']);
        }
    }
    
    async hashValue(val: string) {
        let hashVal = await sha256(val);
        return hashVal;
    }

}