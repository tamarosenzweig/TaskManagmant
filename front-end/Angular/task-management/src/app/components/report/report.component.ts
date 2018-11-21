import { Component, OnInit } from '@angular/core';
import {
  ProjectService, PresenceHoursService, ExcelService,
  Project, ProjectFilter, Global
} from '../../imports';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  //----------------PROPERTIRS-------------------

  projectsReport: Project[];
  conditions: ProjectFilter;
  state: string;

  //----------------CONSTRUCTOR------------------

  constructor(
    private projectService: ProjectService,
    private presenceHoursService: PresenceHoursService,
    private excelService: ExcelService) {
    this.projectService.filterSubject.subscribe(
      (conditions: ProjectFilter) => {
        this.conditions = conditions;
      }
    )
  }

  //----------------METHODS-------------------

  ngOnInit() {
    this.initProjectsReport();
  }

  initProjectsReport() {
    this.projectService.getProjectsReports().subscribe(
      (projects: Project[]) => {
        this.projectService.initDates(projects)
        this.projectsReport = projects;

      },
      err => {
        console.log(err);
      }
    );
  }

  exportToExcel() {
    let data = this.projectsReport.map(project => {
      let presenceHours: number = this.presenceHoursService.getPresenceHoursForProject(project);
      return {
        projectName: project.projectName,
        customerName: project.customer.customerName,
        teamLeaderName: project.teamLeader.userName,
        teamLeaderEmail: project.teamLeader.email,
        startDate: project.startDate,
        endDate: project.endDate,
        projectHours: project.totalHours,
        presenceHours: presenceHours,
        toDoHours: project.totalHours - presenceHours,
        workingPercent: (presenceHours / project.totalHours) * 100 + '%'
      }
    });
    let userName: string = JSON.parse(localStorage.getItem(Global.USER)).userName;
    this.excelService.exportAsExcelFile(data, `${userName}_projects`);
  }

  openRequestForm() {
    this.state = "in";
  }
  closeRequestForm() {
    this.state = "out"
  }
}