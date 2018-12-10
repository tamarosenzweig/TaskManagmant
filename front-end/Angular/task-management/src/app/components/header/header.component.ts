import { Component } from '@angular/core';
import { Global } from '../../imports';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  //----------------PROPERTIRS-------------------

  //allow access types via interpolation
  localStorage: Storage = localStorage;
  global: any = Global;
  json = JSON;

}
