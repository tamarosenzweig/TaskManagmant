import { Component, OnInit } from '@angular/core';
import { PresenceHoursService, User ,Global} from '../../imports';

@Component({
  selector: 'app-worker-graph',
  templateUrl: './worker-graph.component.html',
  styleUrls: ['./worker-graph.component.css']
})
export class WorkerGraphComponent implements OnInit {
  //----------------PROPERTIRS-------------------
  
  projectsHours: { label: string, y: number }[];
  presenceHours: { label: string, y: number }[];

  //----------------CONSTRUCTOR------------------

  constructor(private presenceHoursService: PresenceHoursService) { }

  //----------------METHODS-------------------

  async ngOnInit() {
    this.getPresenceStatusPerProjects();
  }

   getPresenceStatusPerProjects() {
    let workerId: number = (<User>JSON.parse(localStorage.getItem(Global.USER))).userId;

    this.presenceHoursService.getPresenceStatusPerProjects(workerId).subscribe(
      (data:{projectName:string,projectHours:number,presenceHours:number}[]) => {
        // init projectHours
        this.projectsHours = data.map(d => {
          return { label: d.projectName, y: d.projectHours };
        });

        // init presenceHours
        this.presenceHours = data.map(d => {
          return { label: d.projectName, y: d.presenceHours };
        });
      },
      err=>{
        console.log(err);
      });
  }

}
