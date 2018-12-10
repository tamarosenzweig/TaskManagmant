import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import {
  UserService, WorkerHoursService, ProjectService,
  User, eListKind,
  Global, DialogComponent, Project
} from '../../imports';

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
    private userService: UserService,
    private workerHoursService: WorkerHoursService,
    private projectService: ProjectService
  ) { }

  //----------------METHODS-------------------

  ngOnInit(): void {
    //init imageUrl
    this.imageUrl = `${Global.UERS_PROFILES}/`;
    if (this.user.profileImageName)
      this.imageUrl += this.user.profileImageName;
    else
      this.imageUrl += 'guest.jpg';
  }

  edit() {
    this.router.navigate(['taskManagement/manager/userManagement/editUser', this.user.userId]);
  }
  delete() {
    this.showDialog('Are you sure you want to delete this worker?',false);
  }
  showDialog(msg: string,autoClosing:boolean) {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '35%',
      data: {
        title: 'Delete Worker',
        msg,
        autoClosing
      }
    });

    dialogRef.afterClosed().subscribe((isConfirmed: boolean) => {
      console.log(isConfirmed)
      if (isConfirmed)
        this.confirmedDelete();
    });
  }

  async confirmedDelete() {
    //if this user is team-worker and he has incomlete hours we can't delete him
    if (this.user.teamLeaderId != null) {
      let projects: Project[] = await this.projectService.getProjectsByTeamLeaderId(this.user.teamLeaderId).toPromise();
      let teamProjectIdList: number[] = projects.map(project => project.projectId);
      this.workerHoursService.hasUncomletedHours(this.user.userId, teamProjectIdList)
        .subscribe(
          (hasUncomletedHours: boolean) => {
            if (hasUncomletedHours) {
              this.showDialog('Immposible to delete a worker who has incomplete hours',true);
            }
            else {
              this.deleteUser();
            }
          },
          err => {
            console.log(err);
          }
        );
    }
    //if  this user is a team-leader and he has workers or projects we can't delete him
    else {
      let hasWorkes: boolean = await this.userService.hasWorkers(this.user.userId).toPromise();
      if (hasWorkes) {
        let msg: string = 'Impossible to delete team-leader who has workers';
        this.showDialog(msg,true);
        return;
      }
      else {
        let hasProjects: boolean = await this.projectService.hasProjects(this.user.userId).toPromise();
        if (hasProjects) {
          let msg: string = 'Impossible to delete team-leader who has projects';
          this.showDialog(msg,true);
          return;
        }
      }
      this.deleteUser();
    }
  }

  deleteUser() {
    this.userService.deleteUser(this.user).subscribe(
      (deleted: boolean) => {
        if (deleted) {
          console.log(deleted);
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
