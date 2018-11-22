import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { UserService, User, eListKind, Global, DialogComponent } from '../../imports';

@Component({
  selector: 'app-tmp-user',
  templateUrl: './tmp-user.component.html',
  styleUrls: ['./tmp-user.component.css']
})
export class TmpUserComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  @Input()
  user: User;

  @Input()
  listKind: eListKind;

  imageUrl: string;

  //allow access type via interpolation
  eListKind: typeof eListKind = eListKind;

  //----------------CONSTRUCTOR------------------

  constructor(
    private router: Router,
    public dialog: MatDialog,
    private userService: UserService
  ) { }

  //----------------METHODS-------------------

  ngOnInit(): void {
    //init imageUrl
    this.imageUrl = `${Global.UPLOADS}/UsersProfiles/`;
    if (this.user.profileImageName)
      this.imageUrl += this.user.profileImageName;
    else
      this.imageUrl += 'guest.jpg';
  }

  edit() {
    this.router.navigate(['taskManagement/manager/userManagement/editUser', this.user.userId]);
  }

  showDialog() {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '35%',
      data: {
        title: 'Delete Worker',
        msg: 'Are you sure you want to delete this worker?',
      }
    });

    dialogRef.afterClosed().subscribe((isConfirmed: boolean) => {
      console.log(isConfirmed)
      if (isConfirmed)
        this.deleteUser();
    });
  }

  deleteUser() {
    this.userService.deleteUser(this.user).subscribe(
      (deleted: boolean) => {
        if (deleted) {
          this.userService.updateUserListSubject.next();
        }
      },
      err => {
        console.log(err);
      }
    );
  }

  definePermissions() {
    this.router.navigate(['taskManagement/manager/userManagement/permissions', this.user.userId]);
  }

  teamManagement() {
    this.router.navigate(['taskManagement/manager/teamsManagement/teamManagement', this.user.userId]);
  }

  updateHours() {
    this.router.navigate(['taskManagement/teamLeader/teamWorkers/workerHoursManagement', this.user.userId]);
  }
}
