import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserService, eStatus, Global } from '../imports';

@Injectable()
export class AuthGuard implements CanActivate {

    //----------------CONSTRUCTOR------------------

    constructor(private router: Router, private userService: UserService) { }

    //----------------METHODS-------------------

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (state.url=='/'||state.url== '/taskManagement/login') {
            if (localStorage.getItem(Global.USER) == null)
                return true;
            this.userService.navigateByStatus();
            return false;
        }
        if (route.url[0].path == 'manager') {
            let status: eStatus = <eStatus>+localStorage.getItem(Global.STATUS);
            if (status == eStatus.MANAGER)
                return true;
            this.userService.navigateByStatus();
            return false;
        }
        if (route.url[0].path == 'teamLeader') {
            let status: eStatus = <eStatus>+localStorage.getItem(Global.STATUS);
            if (status == eStatus.TEAM_LEADER)
                return true;
            this.userService.navigateByStatus();
            return false;
        }
        if (route.url[0].path == 'worker') {
            let status: eStatus = <eStatus>+localStorage.getItem(Global.STATUS);
            if (status == eStatus.WORKER)
                return true;
            this.userService.navigateByStatus();
            return false;
        }
    }

}