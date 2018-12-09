import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import * as sha256 from 'async-sha256';
import { MenuService, Login,User, eStatus, Email, ChangePassword,Global } from '../../imports';

@Injectable()
export class UserService {

    //----------------PROPERTIRS-------------------

    basicURL: string = Global.BASE_ENDPOINT + `/user`;
    basicPhpURL: string = Global.PHP_HOST + `/user`;

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
        let url: string = `${this.basicPhpURL}/login`;
        let data =new Login(email, password);
        return this.http.post(url,data);
    }

    //GET
    getAllUsers(): Observable<any> {
        let managerId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;
        let url: string = `${this.basicPhpURL}/getAllUsers?managerId=${managerId}`;
        return this.http.get(url);
    }

    //GET
    getAllTeamUsers(teamLeaderId: number): Observable<any> {
        let url: string = `${this.basicPhpURL}/getAllTeamUsers?teamLeaderId=${teamLeaderId}`;
        return this.http.get(url);
    }

    //GET
    getAllTeamLeaders(): Observable<any> {
        let managerId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;
        let url: string = `${this.basicPhpURL}/getAllTeamLeaders?managerId=${managerId}`;
        return this.http.get(url);
    }

    //GET
    getUserById(userId: number): Observable<any> {
        let url: string = `${this.basicPhpURL}/getUserById?userId=${userId}`;
        return this.http.get(url);
    }
    //GET
    hasWorkes(teamLeaderId: number): Observable<any> {
        let url: string = `${this.basicPhpURL}/hasWorkes?teamLeaderId=${teamLeaderId}`;
        return this.http.get(url);
    }

    //POST
    addUser(user: User): Observable<any> {
        let url: string = `${this.basicPhpURL}/addUser`;
        return this.http.post(url,JSON.stringify(user));
    }

    //PUT
    editUser(user: User): Observable<any> {
        let url: string = `${this.basicPhpURL}/editUser`;
        return this.http.post(url, JSON.stringify(user));
    }

    //POST
    deleteUser(user: User): Observable<any> {
        //move user profile image to archives if exist
        if (user.profileImageName)
            this.removeUploadedImage(user.profileImageName, true);
        let url: string = `${this.basicPhpURL}/deleteUser?userId=${user.userId}`;
        return this.http.post(url, null);
    }

    //POST
    uploadImageProfile(image: any): Observable<any> {
        let url: string = `${this.basicPhpURL}/uploadImageProfile`;
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
        let url: string = this.basicPhpURL + `/sendEmail`;
        let formData: FormData = new FormData();
        formData.append('email', JSON.stringify(email));
        formData.append('user', localStorage.getItem(Global.USER));
        return this.http.post(url, formData);
    }

    //POST
    checkUniqueValidations(user: User): Observable<any> {
        let url: string = `${this.basicPhpURL}/checkUniqueValidations`;
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
    confirmToken(changePassword:ChangePassword): Observable<any> {
        let url: string = `${this.basicURL}/confirmToken`;
        return this.http.post(url, changePassword);
    }

    //POST
    changePassword(user: User): Observable<any> {
        let url: string = `${this.basicURL}/changePassword`;
        return this.http.put(url, user);
    }


}