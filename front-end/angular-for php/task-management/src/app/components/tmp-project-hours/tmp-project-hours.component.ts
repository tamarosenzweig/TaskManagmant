import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Project, ProjectService } from '../../imports';

@Component({
  selector: 'app-tmp-project-hours',
  templateUrl: './tmp-project-hours.component.html',
  styleUrls: ['./tmp-project-hours.component.css']
})
export class TmpProjectHoursComponent implements OnInit {
  //----------------PROPERTIRS-------------------
  @Input()
  project: Project;

  //----------------CONSTRUCTOR------------------

  constructor(private router: Router, private projectService: ProjectService) {
  }

  //----------------METHODS-------------------

  ngOnInit() {
  }

  updateWorkersHours() {
    this.router.navigate(['taskManagement/teamLeader/workerHoursManagement/workersHours',this.project.projectId]);
  }

}
