import { Component, } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { UserService, User, DialogComponent, Global } from '../../imports';
import swal from 'sweetalert2';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})

export class AddUserComponent {

  //----------------PROPERTIRS-------------------

  user: User
  caption: string;

  //----------------CONSTRUCTOR------------------

  constructor(
    private userService: UserService,
    public dialog: MatDialog,
    private router: Router
  ) {
    this.user = new User(0, '', '', '', '', null, 0, 0, 0);
    this.caption = 'Add User';
  }

  //----------------METHODS-------------------

  onSubmit(data: { user: User, imageFile: string }) {
    this.user = data.user;
    //upload profile image in the server
    if (data.imageFile) {
      this.userService.uploadImageProfile(data.imageFile)
        .subscribe((newFilename: string) => {
          //placement image name to the user object
          this.user.profileImageName = newFilename;
          this.addUser();
        });
    }
    else
      this.addUser();
  }

  async addUser() {
    this.user.password = this.user.confirmPassword = await this.userService.hashValue(this.user.password);
    this.user.managerId = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;
    this.userService.addUser(this.user).subscribe(
      (created: boolean) => {
        if (created) {
          swal({
            type: 'success',
            text: `${this.user.userName} added succsesully`,
          }).then(res => {
            this.router.navigate(['taskManagement/manager/userManagement']);
          })
        }
      },
      err => console.log(err));
  }

  
}