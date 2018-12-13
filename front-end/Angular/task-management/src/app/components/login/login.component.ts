import { Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import {
  UserService, ValidatorsService,
  User, eStatus,
  Global
} from '../../imports';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./../../../form-style.css', './login.component.css']
})
export class LoginComponent {

  //----------------PROPERTIRS-------------------

  loginFormGroup: FormGroup;
  isExistUser: boolean;
  hashPassword: string;

  //allow access 'Object' type via interpolation
  objectHolder: typeof Object = Object;

  //----------------CONSTRUCTOR------------------

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private validatorsService: ValidatorsService,
  ) {
    this.isExistUser = true;
    this.initFormGroup();
  }

  //----------------METHODS-------------------

  initFormGroup() {
    this.loginFormGroup = this.formBuilder.group({
      email: ['', this.validatorsService.stringValidatorArr('email', 15, 30, /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/)],
      password: ['', this.validatorsService.stringValidatorArr('password', 5, 10, /^[A-Za-z0-9]+$/)]
    });
  }

  async onSubmit() {
    this.hashPassword = await this.userService.hashValue(this.password.value);
    this.login();
  }

  login() {
    this.userService.login(this.email.value, this.hashPassword)
      .subscribe(
        (user: User) => {
          if (user != null) {
            //enter user to localStorage
            localStorage.setItem(Global.CURRENT_USER_ID, user.userId.toString());
            Global.CURRENT_USER = user;
            //enter user status to localStorage
            let status: eStatus;
            if (user.managerId == null) {
              status = eStatus.MANAGER;
            }
            else
              if (user.teamLeaderId == null) {
                status = eStatus.TEAM_LEADER;
              }
              else {
                status = eStatus.WORKER;
              }
            localStorage.setItem(Global.STATUS, status.toString());
            this.userService.navigateByStatus();
          }
          else
            this.isExistUser = false;
        },
        err => {
          console.log(err);
        });
  }

  removeValidationMassage() {
    this.isExistUser = true;

  }

  //----------------GETTERS-------------------

  //getters of the form group controls

  get email() {
    return this.loginFormGroup.controls['email'];
  }
  get password() {
    return this.loginFormGroup.controls['password'];
  }
}
