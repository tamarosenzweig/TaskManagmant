import { Component, OnInit, Input } from '@angular/core';
import { ProjectService, Project } from '../../imports';

@Component({
  selector: 'app-tmp-project',
  templateUrl: './tmp-project.component.html',
  styleUrls: ['./tmp-project.component.css']
})
export class TmpProjectComponent implements OnInit {

  //----------------PROPERTIRS-------------------
  
  @Input()
  project: Project;

  projectPresenseHours: number;
  projectPercentHours: number;

  //----------------CONSTRUCTOR------------------

  constructor(private projectService: ProjectService) { }

  //----------------METHODS-------------------

  ngOnInit() {
    this.projectPresenseHours = this.projectService.getPresenceHours(this.project);
    this.projectPercentHours = this.projectService.getPercentHours(this.project);
  }

}
