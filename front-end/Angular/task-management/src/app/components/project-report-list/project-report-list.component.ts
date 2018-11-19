import { Component, OnInit, Input } from '@angular/core';
import{TreeNode} from 'primeng/api';
import { ProjectService, BaseService, Project } from '../../imports';

@Component({
  selector: 'app-project-report-list',
  templateUrl: './project-report-list.component.html',
  styleUrls: ['./project-report-list.component.css']
})
export class ProjectReportListComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  @Input()
  projects: Project[];

  projectsInfo: TreeNode[];
  colomns: { field: string, header: string }[];

   //----------------CONSTRUCTOR-------------------

  constructor(private projectService: ProjectService, private baseService: BaseService) {
    this.colomns = [  
      { field: 'name', header: 'Name' },
      { field: 'teamLeader', header: 'TeamLeader' },
      { field: 'hours', header: 'Hours' },
      { field: 'presence', header: 'Presence' },
      { field: 'percent', header: 'Percent' },
      { field: 'customer', header: 'Customer' },
      { field: 'startDate', header: 'Start' },
      { field: 'endDate', header: 'End' },
      { field: 'days', header: 'Days' },
      { field: 'workedDays', header: 'Worked' },
      { field: 'daysPercent', header: 'Percent' },
      { field: 'state', header: 'State' }
    ];
  }

  //----------------METHODS-------------------

  ngOnInit() {
    this.initProjectsInfo();
  }

  //  Whenever the data in the parent changes, this method gets triggered. You 
  // can act on the changes here. You will have both the previous value and the 
  // current value here.
  ngOnChanges(changes: any) {
    if (changes.projects.firstChange)
      return;
    this.projects = changes.projects.currentValue;
    this.initProjectsInfo();
  }

  initProjectsInfo() {
    this.projectsInfo = this.projects.map(project => this.getProjectInfo(project));
  }

  getProjectInfo(project: Project): TreeNode {
    let projectDays: number = this.baseService.dateDiffInDays(project.startDate, project.endDate);
    let date = new Date();
    if (date > project.endDate)
      date = project.endDate;
    let workedDays: number = this.baseService.dateDiffInDays(project.startDate, date);
    let daysPercent: number = workedDays / projectDays;

    let projectPresenseHours: number = this.projectService.getPresenceHours(project);
    let projectPercentHours: number = this.projectService.getPercentHours(project);
    let state: string;

    if (projectPercentHours == daysPercent)
      state = "good";
    else
      if (projectPercentHours > daysPercent)
        state = "excellent";
      else
        state = "bad"


    let root = {
      //project details
      data: {
        name:project.projectName,
        teamLeader: project.teamLeader.userName,
        hours: project.totalHours,
        presence: this.baseService.toShortNumber(projectPresenseHours),
        percent: this.baseService.toPercent(projectPercentHours),
        customer: project.customer.customerName,
        startDate: project.startDate.toLocaleDateString(),
        endDate: project.endDate.toLocaleDateString(),
        days: projectDays,
        workedDays: workedDays,
        daysPercent: this.baseService.toPercent(daysPercent),
        state: state
      },
      children: []
    };
    //department details
    project.departmentsHours.forEach(departmentHours => {
      let presenceHoursForDepartment = this.projectService.getPresenceHoursForDepartment(departmentHours.department)
      let departmentNode = {
        data: {
          name: departmentHours.department.departmentName,
          hours: departmentHours.numHours,
          presence: this.baseService.toShortNumber(presenceHoursForDepartment),
          percent: departmentHours.numHours > 0 ? this.baseService.toPercent(presenceHoursForDepartment / departmentHours.numHours) : '-'
        },
        children: [

        ]
      };
      //workers details
      departmentHours.department.workers.forEach(worker => {
        let presenceHoursForWorker = this.projectService.getPresenceHoursForWorker(worker)
        let workerNode = {
          data: {
            name: worker.userName,
              teamLeader: worker.teamLeader.userName,
            hours: worker.workerHours.length ? worker.workerHours[0].numHours : 0,
            presence: this.baseService.toShortNumber(presenceHoursForWorker),
            percent: worker.workerHours.length ? this.baseService.toPercent(presenceHoursForWorker / worker.workerHours[0].numHours) : '-'
          }
        };
        departmentNode.children.push(workerNode);
      })

      root.children.push(departmentNode);
    });
    return <TreeNode>(root);
  }


}
