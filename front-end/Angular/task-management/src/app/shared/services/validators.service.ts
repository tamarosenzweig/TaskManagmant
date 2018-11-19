import { Injectable } from '@angular/core';
import { ValidatorFn, FormGroup, AsyncValidatorFn } from '@angular/forms';
import { UserService,ProjectService,User, Project } from '../../imports';


@Injectable()
export class ValidatorsService {
    
    constructor(private userSrevice: UserService,private projectService:ProjectService) { }

    stringValidatorArr(cntName: string, min?: number, max?: number, pattern?: RegExp): Array<ValidatorFn> {
        return [
            f => !f.value ? { 'val': `${cntName} is required` } : null,
            f => f.value && max && f.value.length > max ? { 'val': `'${cntName}' is max ${max} chars` } : null,
            f => f.value && min && f.value.length < min ? { 'val': `'${cntName}' is min ${min} chars` } : null,
            f => f.value && pattern && !f.value.match(pattern) ? { 'val': `'${cntName}' is contain only english letter` } : null
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

    uniqueUserValidator(user:User,ctrlName: string): AsyncValidatorFn {
        return async f => {
            if (f.value) {
                user=new User(user.userId,null,null,null,null,null,false,0,0,0);
                user[ctrlName.toLowerCase()] = f.value;
                if(ctrlName=='Password')
                user.password= await this.userSrevice.hashValue(f.value);
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
               let project:Project=new Project(0,null,0,0,0,0,null,null);
                project[ctrlName.toLowerCase()] = f.value;
                let res = await this.projectService.checkUniqueValidation(project).toPromise();
                return res;
            }
            else {
                return null;
            }
        }
    }
}