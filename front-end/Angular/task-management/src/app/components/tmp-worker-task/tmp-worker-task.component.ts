import { Component, Input, Output, EventEmitter } from '@angular/core';
import {
  PresenceHoursService,
  WorkerHours, PresenceHours, User,
  Global
} from '../../imports';

@Component({
  selector: 'app-tmp-worker-task',
  templateUrl: './tmp-worker-task.component.html',
  styleUrls: ['./tmp-worker-task.component.css']
})
export class TmpWorkerTaskComponent {

  //----------------PROPERTIRS-------------------

  @Input()
  workerHour: WorkerHours;

  @Input()
  disabled: boolean;

  @Output()
  isStartedEvent: EventEmitter<boolean>;

  isStarted: boolean;
  btnMessage: string;
  btnIcon: string;
  presenceHours: PresenceHours;

  //----------------CONSTRUCTOR------------------

  constructor(private presenceHoursService: PresenceHoursService) {
    this.isStarted = false;
    this.btnMessage = 'start your task';
    this.isStartedEvent = new EventEmitter<boolean>();
    this.btnIcon = 'fa fa-play';
  }

  //----------------METHODS-------------------

  btnTaskClick() {
    if (this.isStarted == false) {
      this.isStarted = true;
      this.btnMessage = 'stop your task';
      this.btnIcon='fa fa-pause';
      this.addPresenceHours();
    }

    else {
      this.isStarted = false;
      this.btnMessage = 'start your task';
      this.btnIcon = 'fa fa-play';
      this.editPresenceHours();
    }
    this.isStartedEvent.emit(this.isStarted);
  }

  addPresenceHours() {
    let userId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId
    let startDate = new Date();
    this.presenceHours = new PresenceHours(0, userId, this.workerHour.projectId, startDate, null);
    this.presenceHoursService.addPresenceHours(this.presenceHours).subscribe(
      (presenceHoursId: number) => {
        this.presenceHours.presenceHoursId = presenceHoursId;
      },
      err => {
        console.log(err);
      }
    );
  }

  editPresenceHours() {
    this.presenceHours.endHour = new Date();
    this.presenceHoursService.editPresenceHours(this.presenceHours).subscribe(
      () => {

      },
      err => {
        console.log(err);
      }
    );
  }
}
