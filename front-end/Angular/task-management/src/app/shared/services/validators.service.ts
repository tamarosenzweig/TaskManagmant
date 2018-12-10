import { Injectable } from '@angular/core';
import { asEnumerable } from 'linq-es2015';
import { FormGroup,FormControl,ValidatorFn, AsyncValidatorFn } from '@angular/forms';
import {
    UserService, ProjectService, WorkerHoursService,
    User, Project
} from '../../imports';


@Injectable()
export class ValidatorsService {

    constructor(
        private userSrevice: UserService,
        private projectService: ProjectService,
        private workerHoursService: WorkerHoursService
    ) { }

    stringValidatorArr(cntName: string, min?: number, max?: number, pattern?: RegExp): Array<ValidatorFn> {
        return [
            f => !f.value ? { 'val': `${cntName} is required` } : null,
            f => f.value && max && f.value.length > max ? { 'val': `'${cntName}' is max ${max} chars` } : null,
            f => f.value && min && f.value.length < min ? { 'val': `'${cntName}' is min ${min} chars` } : null,
            f => f.value && pattern && !f.value.match(pattern) ? { 'val': `'${cntName}' format is not correct` } : null
        ];
    }

    numberValidatorArr(cntName: string, min?: number, max?: number): Array<ValidatorFn> {
        return [
            f => f.value == undefined ? { 'val': `${cntName} is required` } : null,
            f => f.value && max != undefined && max != null && f.value > max ? { 'val': `${cntName} can be maximum ${max}` } : null,
            f => f.value && min != undefined && min != null && f.value < min ? { 'val': `${cntName} must be minimum ${min}` } : null,
        ];
    }

    confirmPasswordValidator(fromGroup: FormGroup): Array<ValidatorFn> {
        return [
            f => !f.value ? { 'val': '\'confirmPassword\'  is required' } : null,
            f => f.value && fromGroup.get('password').value != f.value ? { 'val': '\'confirmPassword\' doesn\'t not match to \'password\'' } : null
        ];
    }

    dateValidatorArr(ctrlName: string, formGroup: FormGroup): Array<ValidatorFn> {
        return [
            f => !f.value ? { 'val': `'${ctrlName}'  is required` } : null,
            f => {
                if (ctrlName == 'start date' || !formGroup.get('startDate').value)
                    return f.value && f.value < new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate()) ? { 'val': `'${ctrlName}' can't be before today` } : null;
                return f.value && f.value < formGroup.get('startDate').value ? { 'val': '\'end date\' can\'t be before \'start date\'' } : null;

            },
            f => {
                if (ctrlName == 'end date' || !formGroup.get('endDate').value)
                    return f.value && f.value > new Date(new Date().getFullYear() + 1, new Date().getMonth(), new Date().getDate()) ? { 'val': `'${ctrlName}' can't be greater than a year` } : null;
                return f.value && f.value > formGroup.get('endDate').value ? { 'val': '\'start date\' can\'t be greater than \'end date\'' } : null;
            }
        ];
    }

    uniqueUserValidator(user: User, ctrlName: string): AsyncValidatorFn {
        return async f => {
            if (f.value) {
                user = new User(user.userId, null, null, null, null, null, 0, 0, 0);
                user[ctrlName] = f.value;
                if (ctrlName == 'password')
                    user.password = await this.userSrevice.hashValue(f.value);
                let res = await this.userSrevice.checkUniqueValidations(user).toPromise();
                return res;
            }
            else {
                return null;
            }
        }
    }

    uniqueProjectValidator(ctrlName: string): AsyncValidatorFn {
        return async f => {
            if (f.value) {
                let project: Project = new Project(0, null, 0, 0, 0, 0, null, null, false);
                project[ctrlName] = f.value;
                let res = await this.projectService.checkUniqueValidation(project).toPromise();
                return res;
            }
            else {
                return null;
            }
        }
    }
    requiredValidator(ctrlName: string): ValidatorFn {
        return f =>{ 
            return !f.value ? { 'val': `'${ctrlName}'  is required` } : null};
    }
    workerHoursValidator(presenceHours: number): ValidatorFn {
        return f => f.value && f.value < presenceHours ? { 'val': 'Worker hours can\'t be less than presence hours' } : null;
    }
    workerHoursDepartmentValidator(workerHours: number, departmentHours: number, departmentHoursSum: number): ValidatorFn {
        return f => f.value && departmentHoursSum - workerHours + (+f.value) > departmentHours ? { 'val': 'Hours defined for workers are greater than the hours defined for this department' } : null;
    }

    TeamLeaderValidator(teamLeaderId: number, workerId: number,teamProjectIdList:number[]): AsyncValidatorFn {
        return async f => {
            if (f.value && f.value != teamLeaderId) {
                if (teamLeaderId == null) {
                    let workers: User[] = await this.userSrevice.getAllTeamUsers(workerId).toPromise();
                    return workers.length > 0 ? { 'val': 'Impossible to change the worker\'s status when he has workers' } : null;
                }
                else {
                    let hasUncomletedHours: boolean = await this.workerHoursService.hasUncomletedHours(workerId,teamProjectIdList).toPromise();
                    return hasUncomletedHours ?
                        { 'val': 'Impossible to change the worker\'s status if he has defined hours' } : null;
                }
            }
            return null;
        }
    }

    workerToTeamLeaderValidator(workerId: number,teamProjectIdList:number[]): AsyncValidatorFn {
        return async f => {
            if (f.value) {
                let hasUncomletedHours: boolean = await this.workerHoursService.hasUncomletedHours(workerId,teamProjectIdList).toPromise();
                return hasUncomletedHours ? { 'val': 'Impossible to change a worker to be a team-leader if he has defined hours' } : null;
            }
            return null;
        }
    }
    departmentValidator(departmentId: number, workerId: number,teamProjectIdList:number[]): AsyncValidatorFn {
        return async f => {
            if (f.value && f.value != departmentId) {  
                    let hasUncomletedHours: boolean = await this.workerHoursService.hasUncomletedHours(workerId,teamProjectIdList).toPromise();
                    return hasUncomletedHours ?
                        { 'val': 'Impossible to move a department worker if he has incomplete hours' } : null;
                }
            return null;
        }
    }
    
    sumValidator(ctrlName:string,min:number):ValidatorFn{
       return f=>{
            let sum:number=asEnumerable(Object.values((<FormGroup>f).controls)).Sum(x => Number((<FormControl>x).value));
            return sum<min?{ 'val':`${ctrlName} must be greater than ${min-1}`}:null;
        };

    }

}