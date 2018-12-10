import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import {
  PermissionService, WorkerHoursService,
  Permission,
  DialogComponent
} from '../../imports';
import swal from 'sweetalert2';

@Component({
  selector: 'app-tmp-permission',
  templateUrl: './tmp-permission.component.html',
  styleUrls: ['./tmp-permission.component.css']
})
export class TmpPermissionComponent {

  //----------------PROPERTIRS-------------------

  @Input()
  permission: Permission;

  //----------------CONSTRUCTOR------------------

  constructor(
    private dialog: MatDialog,
    private permissionService: PermissionService,
    private workerHoursService: WorkerHoursService
  ) { }

  //----------------METHODS-------------------

  async deletePermission() {
    let hasUncomletedHours: boolean = await this.workerHoursService.hasUncomletedHours(this.permission.workerId, [this.permission.projectId]).toPromise();
    if (hasUncomletedHours)
     {
     let msg:string= 'It is not possible to remove a worker\'s permission to a project if hours were defined for him to this project';
      swal({
        type: 'error',
        title: 'Oops...',
        text: msg,
      }) 
     } 
    else
      this.permissionService.deletePemission(this.permission.permissionId).subscribe(
        (deleted: boolean) => {
          if (deleted)
            this.permissionService.deletePermissionSubject.next(this.permission);
        },
        err => {
          console.log(err);
        }
      );
  }


}
