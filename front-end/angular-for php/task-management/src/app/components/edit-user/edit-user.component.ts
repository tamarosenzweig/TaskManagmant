import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { UserService, User, DialogComponent } from '../../imports';
import swal from 'sweetalert2';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  userId: number;
  user: User
  caption: string;

  //----------------CONSTRUCTOR------------------

  constructor(
    private userService: UserService,
    public dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.caption = 'Edit User';
  }

  //----------------METHODS-------------------

  ngOnInit() {
    this.activatedRoute.params.subscribe(param => this.userId = param['id']);
    this.userService.getUserById(this.userId).subscribe(
      (user: User) => {
        this.user = user;
      },
      err => console.log(err));
  }

  onSubmit(data: { user: User, imageFile: string }) {
    this.initUser(data.user);
    //remove profile image in the server
    if (this.user.profileImageName != null) {
      this.userService.removeUploadedImage(this.user.profileImageName,false)
        .subscribe(() => {
          this.user.profileImageName = null;
          this.uploadImage(data);
        },
          err => {
            console.log(err);
          });
    }
    else
      this.uploadImage(data);
  }

  initUser(user: User) {
    this.user.userName = user.userName;
    this.user.email = user.email;
    this.user.departmentId = user.departmentId;
    this.user.teamLeaderId = user.teamLeaderId;
    user.department=null;
    user.teamLeader=null;
  }

  uploadImage(data: { user: User, imageFile: string }) {
    //upload profile image in the server
    if (data.imageFile != null) {
      this.userService.uploadImageProfile(data.imageFile)
        .subscribe((newFilename: string) => {
          //placement image name to the user object
          console.log(newFilename);
          this.user.profileImageName = newFilename;
          this.editUser(this.user);
        });
    }
    else
      this.editUser(this.user);
  }

  editUser(user: User) {
    this.userService.editUser(user).subscribe(
      (edited:boolean) => {
        if (edited) {
          swal({
            type: 'success',
            title: `${this.user.userName} added succsesully`,
          })
        }
      },
      err => console.log(err));
  }

 
}
