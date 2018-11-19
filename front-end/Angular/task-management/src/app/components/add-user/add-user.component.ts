import { Component, } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { UserService, User, DialogComponent,Global } from '../../imports';

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
    let managerId:number=(<User>JSON.parse(localStorage.getItem(Global.USER))).userId;
    this.user = new User(0, '', '', '', '', null, false, 0, 0,managerId);
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
    this.addUser();
  }

  async addUser() {
    this.user.password = this.user.confirmPassword = await this.userService.hashValue(this.user.password);
    this.userService.addUser(this.user).subscribe(
      (created: boolean) => {
        if (created) {
          this.showDialog();
        }
      },
      err => console.log(err));
  }

  showDialog() {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '35%',
      data: {
        title: '',
        msg: `${this.user.userName} added succsesully`,
        autoClosing: true
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      this.router.navigate(['taskManagement/manager/userManagement']);
    });
  }
}