import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {AccordionModule} from 'primeng/accordion';
import {TreeTableModule} from 'primeng/treetable';

import {
  MatInputModule,
  MatSelectModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatDialogModule,
  MatButtonModule,
  MatCheckboxModule,
  MatCardModule,
  MatMenuModule,
  MatTabsModule,
  MatListModule,
  MatDividerModule,
  MatTooltipModule
} from '@angular/material';

import {
  //services
  BaseService,
  CustomerService,
  DepartmentService,
  ExcelService,
  MenuService,
  PermissionService,
  PresenceHoursService,
  ProjectService,
  UserService,
  ValidatorsService,
  WorkerHoursService,
  AuthGuard,
  Resolver,
  //pipes
  ProjectFilterPipe,
  //components
  AppComponent,
  HeaderComponent,
  FooterComponent,
  MainComponent,
  MenuComponent,
  InputComponent,
  SelectComponent,
  TextareaComponent,
  LoginComponent,
  //Manger Screens
  ManagerComponent,
  UserManagementComponent,
  UserListComponent,
  UserFormComponent,
  AddUserComponent,
  EditUserComponent,
  UploadImgComponent,
  PermissionsComponent,
  PermissionListComponent,
  TmpPermissionComponent,
  AddPermissionComponent,
  // ProjectManagement
  ProjectManagementComponent,
  AddProjectComponent,
  ReportComponent,
  ProjectReportListComponent,
  FilterReportComponent,
  //TeamsManagement
  TeamsManagementComponent,
  TeamManagementComponent,
  // for UserList and TeamsManagement
  TmpUserComponent,
  // for AddProject-add permission and TeamManagement-belong worker to team
  SelectWorkersComponent,
  //TeamLeader Screens
  TeamLeaderComponent,
  TeamWorkersManagementComponent,
  WorkerHoursManagementComponent,
  WorkerHoursListComponent,
  TmpWorkerHoursComponent,
  AddWorkerHoursComponent,
  WorkersHoursStatusComponent,
  ProjectListComponent,
  TmpProjectComponent,
  //Worker Screens
  WorkerComponent,
  HomeComponent,
  SendEmailComponent,
  DateAndTimeComponent,
  WorkerTaskListComponent,
  TmpWorkerTaskComponent,
  TimerComponent,
  ProjectsGraphComponent,
  HoursGraphComponent,
  DatePickerComponent,
  DialogComponent,
  TreeTableComponent,
  //routing
  routing
}
  from './imports';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainComponent,
    MenuComponent,
    InputComponent,
    SelectComponent,
    TextareaComponent,
    LoginComponent,
    ManagerComponent,
    UserManagementComponent,
    UserListComponent,
    UserFormComponent,
    AddUserComponent,
    EditUserComponent,
    UploadImgComponent,
    PermissionsComponent,
    PermissionListComponent,
    TmpPermissionComponent,
    AddPermissionComponent,
    ProjectManagementComponent,
    AddProjectComponent,
    ReportComponent,
    ProjectReportListComponent,
    FilterReportComponent,
    TeamsManagementComponent,
    TeamManagementComponent,
    TmpUserComponent,
    SelectWorkersComponent,
    TeamLeaderComponent,
    TeamWorkersManagementComponent,
    WorkerHoursManagementComponent,
    WorkerHoursListComponent,
    TmpWorkerHoursComponent,
    AddWorkerHoursComponent,
    WorkersHoursStatusComponent,
    ProjectListComponent,
    TmpProjectComponent,
    WorkerComponent,
    HomeComponent,
    SendEmailComponent,
    DateAndTimeComponent,
    WorkerTaskListComponent,
    TmpWorkerTaskComponent,
    TimerComponent,
    ProjectsGraphComponent,
    HoursGraphComponent,
    DatePickerComponent,
    DialogComponent,
    TreeTableComponent,
    ProjectFilterPipe
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    routing,
    HttpClientModule,
    BrowserAnimationsModule,
    AccordionModule,
    TreeTableModule,

    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule,
    MatButtonModule,
    MatCheckboxModule,
    MatCardModule,
    MatMenuModule,
    MatTabsModule,
    MatListModule,
    MatDividerModule,
    MatTooltipModule
  ],
  providers: [
    BaseService,
    CustomerService,
    DepartmentService,
    ExcelService,
    MenuService,
    PermissionService,
    PresenceHoursService,
    ProjectService,
    UserService,
    ValidatorsService,
    WorkerHoursService,
    AuthGuard,
    Resolver

  ],
  entryComponents: [
    DialogComponent, SendEmailComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }