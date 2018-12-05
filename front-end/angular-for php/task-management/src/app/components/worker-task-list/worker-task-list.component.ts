import { Component, OnInit } from '@angular/core';
import {
  WorkerHoursService,
  WorkerHours, User,
  Global
}
  from '../../imports';

@Component({
  selector: 'app-worker-task-list',
  templateUrl: './worker-task-list.component.html',
  styleUrls: ['./worker-task-list.component.css']
})
export class WorkerTaskListComponent implements OnInit {

  workerHours: WorkerHours[] = [];
  isStartedTaskExist: boolean;


  //----------------CONSTRUCTOR------------------

  constructor(private workerHoursService: WorkerHoursService) {
    this.isStartedTaskExist = false;
  }

  //----------------METHODS------------------
  ngOnInit() {
    this.getAllWorkerHours();
  }

  getAllWorkerHours() {
    let workerId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;
    this.workerHoursService.getAllWorkerHours(workerId).subscribe(
      (workerHours: WorkerHours[]) => {
        this.workerHours = workerHours;
      },
      err => {
        console.log(err);
      }
    )
  }
  
  disableButtons(isStarted: boolean) {
    this.isStartedTaskExist = isStarted;
  }

}
