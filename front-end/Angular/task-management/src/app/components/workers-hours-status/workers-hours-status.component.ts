import { Component, OnInit } from '@angular/core';
import { PresenceHoursService, User, Global } from '../../imports';

@Component({
  selector: 'app-workers-hours-status',
  templateUrl: './workers-hours-status.component.html',
  styleUrls: ['./workers-hours-status.component.css']
})
export class WorkersHoursStatusComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  presenceStatusPerWorkers: {label:string,y:number}[];
  currMonth: string;
  title: string;

  //----------------CONSTRUCTOR------------------

  constructor(private presenceHoursService: PresenceHoursService) {
    let months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    this.currMonth = months[new Date().getMonth()];
    this.title = 'Presence Hours Status';
  }
  //----------------METHODS-------------------

  ngOnInit() {
    this.getPresenceStatusPerWorkers();
  }
  
  async getPresenceStatusPerWorkers() {
    let teamLeaderId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;
    let data = await this.presenceHoursService.getPresenceStatusPerWorkers(teamLeaderId);
    // init projectHours
    this.presenceStatusPerWorkers = data.map(d => {
      return { label: d.userName, y: d.presenceHours };
    });
  }
}
