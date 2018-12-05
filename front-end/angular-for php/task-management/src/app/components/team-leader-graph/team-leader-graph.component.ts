import { Component, OnInit } from '@angular/core';
import { asEnumerable } from 'linq-es2015';
import { FormControl } from '@angular/forms';
import { PresenceHoursService, User, Global } from '../../imports';

@Component({
  selector: 'app-team-leader-graph',
  templateUrl: './team-leader-graph.component.html',
  styleUrls: ['./team-leader-graph.component.css']
})
export class TeamLeaderGraphComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  currMonth: string;

  hoursStatus: { userName: string, projectName: string, projectHours: number, presenceHours: number }[];
  projectsHours: { label: string, y: number }[];
  presenceHours: { label: string, y: number }[];
  titleX:string="workers";

  projects: { projectId: number, projectName: string }[];
  projectControl: FormControl;

  //----------------CONSTRUCTOR------------------

  constructor(private presenceHoursService: PresenceHoursService) {
    this.projectControl = new FormControl();
  }
  //----------------METHODS-------------------

  ngOnInit() {
    this.getPresenceStatusPerWorkers();
  }

  getPresenceStatusPerWorkers() {
    let teamLeaderId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;

    this.presenceHoursService.getPresenceStatusPerWorkers(teamLeaderId)
      .subscribe(
        (data: { userName: string, projectName: string, projectHours: number, presenceHours: number }[]) => {
          this.hoursStatus = data;
          this.initGraphData(null);
          
          //init project list
          let index: number = 0;
          this.projects = asEnumerable(
            data.map(d => {
            return { projectId: index++, projectName: d.projectName };})
          ).Distinct(project=>project.projectName).ToArray();
        },
        err => {
          console.log(err);
        });
  }
  onProjectChange() {
    let projectName: string =this.projectControl.value;
    this.initGraphData(projectName);
  }

  initGraphData(projectName: string) {
    let filterHoursStatus = this.hoursStatus.filter(data => data.projectName == projectName);

    // init projectHours
    this.projectsHours = filterHoursStatus.map(data => {
      return { label: data.userName, y: data.projectHours };
    });

    // init presenceHours
    this.presenceHours = filterHoursStatus.map(data => {
      return { label: data.userName, y: data.presenceHours };
    });
  }
}
