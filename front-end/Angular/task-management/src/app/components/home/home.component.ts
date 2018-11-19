import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { UserService, Email, SendEmailComponent } from '../../imports';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  //----------------CONSTRUCTOR------------------

  constructor(
    private dialog: MatDialog,
    private userService: UserService
  ) { }

  //----------------METHODS-------------------

  showDialog() {
    const dialogRef = this.dialog.open(SendEmailComponent, {
      width: '50%',
      data: {
        title: 'Send Email',
      }
    });
    dialogRef.afterClosed().subscribe((email: Email) => {
      this.sendEmail(email);
    });
  }

  sendEmail(email: Email) {
    this.userService.sendEmail(email).subscribe(
      (sended: boolean) => {
        alert(sended);
      },
      err => {
        console.log(err);
      }
    );
  }

}

