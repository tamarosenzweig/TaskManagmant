import { Component } from '@angular/core';
import { MenuService, MenuItem } from '../../imports';

@Component({
  selector: 'app-team-leader',
  templateUrl: './team-leader.component.html',
  styleUrls: ['./team-leader.component.css']
})
export class TeamLeaderComponent {

  //----------------PROPERTIRS-------------------

  menu: MenuItem[];

  //----------------CONSTRUCTOR------------------

  constructor(private menuService: MenuService) {
    this.menu = [
      new MenuItem('Worker Hours Management','/taskManagement/teamLeader/workerHoursManagement/projectHoursList'),
      new MenuItem('Follow Your Projects', '/taskManagement/teamLeader/ProjectList'),
      new MenuItem('Workers Hours Status', '/taskManagement/teamLeader/workersHoursStatus')
    ];
    this.menuService.setMenu(this.menu);
  }

}
