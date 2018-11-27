import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {
  UserService, DepartmentService, ValidatorsService,
  User, Department,
  Global
} from '../../imports';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./../../../form-style.css']
})
export class UserFormComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  userFormGroup: FormGroup;

  //allow access from html page to 'Object' type
  objectHolder: typeof Object = Object;

  isExistEmail: boolean;
  isExistPassword: boolean;

  imageFile: any;
  imageUrl: string;

  departments: Department[];
  teamLeaders: User[];
  types: string[];
  placeholders: string[];
  @Input()
  caption: string;

  @Input()
  user: User;

  @Output()
  dataEvent: EventEmitter<{ user: User, imageFile: string }>;

  end: number;

  //----------------CONSTRUCTOR------------------

  constructor(
    private cdr: ChangeDetectorRef,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private departmentService: DepartmentService,
    private validatorsService: ValidatorsService
  ) {
    this.isExistEmail = false;
    this.isExistPassword = false;
    this.imageUrl = null;
    this.types = ['text', 'text', 'password', 'password'];
    this.placeholders = ['Use name', 'Email', 'Password', 'Confirm password'];
    this.dataEvent = new EventEmitter<{ user: User, imageFile: string }>();
  }

  //----------------METHODS-------------------

  ngOnInit() {
    if (this.user.profileImageName != null)
      this.imageUrl = `${Global.UPLOADS}/UsersProfiles/${this.user.profileImageName}`;
    this.initFormGroup();
    this.getAllDepartments();
    this.getAllTeamLeaders();
  }

  initFormGroup() {
    this.userFormGroup = this.formBuilder.group({
      userName: [this.user.userName, this.validatorsService.stringValidatorArr('user name', 2, 15, /^[A-Za-z]+$/)],
      email: [this.user.email, this.validatorsService.stringValidatorArr('email', 15, 30, /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/), [this.validatorsService.uniqueUserValidator(this.user, 'Email')]],
      password: [this.user.password, this.validatorsService.stringValidatorArr('password', 5, 10), [this.validatorsService.uniqueUserValidator(this.user, 'Password')]],
      confirmPassword: [this.user.confirmPassword, this.validatorsService.stringValidatorArr('confirm password', 5, 10)],
      departmentId: [this.user.departmentId],
      teamLeaderId: [this.user.teamLeaderId],
      isTeamLeader: [this.user.teamLeaderId == null],
    });
    if (this.user.userId > 0) {
      this.userFormGroup.removeControl("password");
      this.userFormGroup.removeControl("confirmPassword");
      this.end = 2;
      //team-leader-validation
      if (this.user.teamLeaderId !=null) {
        this.setTeamLeaderAndDepartmentValidators();
        
        this.cdr.detectChanges();
        this.isTeamLeader.setAsyncValidators(this.validatorsService.workerToTeamLeaderValidator(this.user.userId));
      }
    }
    else {
      this.confirmPassword.setValidators(this.validatorsService.confirmPasswordValidator(this.userFormGroup));
      this.end = 4;
    }
  }

  getAllDepartments() {
    this.departmentService.getAllDepartments().then(
      (departments: Department[]) => {
        this.departments = departments;
      },
      err => {
        console.log(err);
      }
    );
  }

  getAllTeamLeaders() {
    this.userService.getAllTeamLeaders().subscribe(
      (teamLeaders: User[]) => {
        this.teamLeaders = teamLeaders;
        if (this.user.userId > 0 && this.user.teamLeaderId == null) {
          let index: number = teamLeaders.findIndex(teamLeader => teamLeader.userId == this.user.userId);
          this.teamLeaders.splice(index, 1);
        }
      },
      err => {
        console.log(err);
      }
    );
  }

  teamLeader() {
    //if the worker is team-leader:
    // the manager doesn't have to enter department and team-leader
    if (this.isTeamLeader.value == true) {
      this.removeTeamLeaderAndDepartmentValidators();
    }
    else {
      this.setTeamLeaderAndDepartmentValidators();
    }

    //reset value of departmentId and teamLeaderId
    this.departmentId.setValue(null);
    this.teamLeaderId.setValue(null);
  }

  onSubmit() {
    this.isExistEmail = false;
    this.isExistPassword = false;
    let user: User = this.userFormGroup.value;
    let imageFile: string = this.imageFile;
    let data = { user, imageFile };
    this.dataEvent.emit(data);
  }

  /**
   * @method
   * get image from event emitter of 'upload-image' component 
   * when user choose his profile image
   */
  getImage(value: any) {
    this.imageFile = value;
  }

  keyUp(controlName: string) {
    if (controlName == 'email')
      this.isExistEmail = false;
    else if (controlName == 'password')
      this.isExistPassword = false;
  }

  setTeamLeaderAndDepartmentValidators() {
    this.teamLeaderId.setAsyncValidators(this.validatorsService.TeamLeaderValidator(this.user.teamLeaderId, this.user.userId));
    this.teamLeaderId.setValidators(this.validatorsService.requiredValidator('team leader'));
    this.departmentId.setAsyncValidators(this.validatorsService.departmentValidator(this.user.teamLeaderId, this.user.userId));
  }
  removeTeamLeaderAndDepartmentValidators() {
    this.teamLeaderId.setAsyncValidators(null);
    this.teamLeaderId.setValidators(null);
    this.departmentId.setAsyncValidators(null);
  }
  //----------------GETTERS-------------------

  //getters of the form group controls

  get userName() {
    return this.userFormGroup.controls['userName'];
  }

  get email() {
    return this.userFormGroup.controls['email'];
  }

  get password() {
    return this.userFormGroup.controls['password'];
  }

  get confirmPassword() {
    return this.userFormGroup.controls['confirmPassword'];
  }

  get departmentId() {
    return this.userFormGroup.controls['departmentId'];
  }

  get teamLeaderId() {
    return this.userFormGroup.controls['teamLeaderId'];
  }

  get isTeamLeader() {
    return this.userFormGroup.controls['isTeamLeader'];
  }
}

