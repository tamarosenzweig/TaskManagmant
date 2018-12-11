import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserService, User, eStatus, Global } from '../imports';

@Injectable()
export class AuthGuard implements CanActivate {

    //----------------CONSTRUCTOR------------------

    constructor(private userService: UserService) { }

    //----------------METHODS-------------------

    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
        if (state.url == '/' || state.url == '/taskManagement/login') {
            let currentUserId: string = localStorage.getItem(Global.CURRENT_USER_ID);
            if (currentUserId == null) {
                return true;
            }
            await this.userService.navigateByStatus();
            return false;
        }
        let status: eStatus = <eStatus>+localStorage.getItem(Global.STATUS);
        if (route.url[0].path == 'manager') {
            if (status == eStatus.MANAGER) {
                return await this.initCurrentUser();
            }
            await this.userService.navigateByStatus();
            return false;
        }
        if (route.url[0].path == 'teamLeader') {
            if (status == eStatus.TEAM_LEADER) {
                return await this.initCurrentUser();
            }
            await this.userService.navigateByStatus();
            return false;
        }
        if (route.url[0].path == 'worker') {
            if (status == eStatus.WORKER) {
                return await this.initCurrentUser();
            }
            await this.userService.navigateByStatus();
            return false;
        }
    }
    
    async initCurrentUser(): Promise<boolean> {
        let currentUserId: string = localStorage.getItem(Global.CURRENT_USER_ID);
        let user: User = await this.userService.getUserById(+currentUserId).toPromise();
        if (user) {
            Global.CURRENT_USER = user;
            return true;
        }
        else {
            localStorage.clear();
            return false
        }
    }

}