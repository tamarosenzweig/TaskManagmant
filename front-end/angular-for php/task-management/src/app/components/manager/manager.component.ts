import { Component } from '@angular/core';
import { MenuService, MenuItem } from '../../imports';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent {

  //----------------PROPERTIRS-------------------

  menu: MenuItem[];

  //----------------CONSTRUCTOR------------------

  constructor(private menuService: MenuService){
    this.menu = [
      new MenuItem('Users Managment', '/taskManagement/manager/userManagement'),
      new MenuItem('Projects Managment', '/taskManagement/manager/projectManagement'),
      new MenuItem('Teams Management', '/taskManagement/manager/teamsManagement')
    ];

    this.menuService.setMenu(this.menu);
  }
}
