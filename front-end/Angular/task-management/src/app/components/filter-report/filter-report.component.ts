import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UserService, ProjectService, User, Project } from '../../imports';

@Component({
  selector: 'app-filter-report',
  templateUrl: './filter-report.component.html',
  styleUrls: ['./filter-report.component.css']
})
export class FilterReportComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  filterFormGroup: FormGroup;

  months: { monthId: number, monthName: string }[];
  workers: User[];
  teamLeaders: User[];
  projects: Project[];

  //----------------CONSTRUCTOR------------------

  constructor(
    private userService: UserService,
    private projectService: ProjectService,
    private formBuilder: FormBuilder
  ) { }

  //----------------METHODS-------------------

  ngOnInit() {
    this.initFormGroup();
    //listening to changes
    this.filterFormGroup.valueChanges.subscribe(() => {
      this.projectService.filterSubject.next(this.filterFormGroup.value);
    });

    this.initMonths();
    this.initlWorkersAndTeamLeaders();
    this.initProjects();
  }

  initFormGroup() {
    this.filterFormGroup = this.formBuilder.group({
      monthId: [null],
      workerId: [null],
      teamLeaderId: [null],
      projectId: [null]
    });
  }

  initMonths() {
    this.months = [];
    let locale: string = 'en-US';
    var format = new Intl.DateTimeFormat(locale, { month: 'long' })
    for (let month: number = 0; month < 12; month++) {
      var testDate = new Date(Date.UTC(2000, month, 1, 0, 0, 0));
      this.months.push({ monthId: month + 1, monthName: format.format(testDate) })
    }
  }

  initlWorkersAndTeamLeaders() {
    this.userService.getAllUsers().subscribe(
      (workers: User[]) => {
        this.workers = workers.filter(worker => worker.teamLeaderId != null);
        this.teamLeaders = workers.filter(worker => worker.teamLeaderId == null);
      },
      err => {
        console.log(err);
      }
    );
  }

  initProjects() {
    this.projectService.getAllProjects().subscribe(
      (projects: Project[]) => {
        this.projects = projects;
      },
      err => {
        console.log(err);
      }
    );
  }

  //----------------GETTERS-------------------

  //getters of the form group controls

  get monthId() {
    return this.filterFormGroup.controls['monthId'];
  }

  get workerId() {
    return this.filterFormGroup.controls['workerId'];
  }

  get teamLeaderId() {
    return this.filterFormGroup.controls['teamLeaderId'];
  }

  get projectId() {
    return this.filterFormGroup.controls['projectId'];
  }
}
