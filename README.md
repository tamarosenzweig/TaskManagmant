# Cross app - Task Managmant

## Using this technologies:

* Web api
* WinForms
* Angular
* MySql

## Authors

* **Efart Zadok** - *a depeloper* - (efrat0879@gmail.com)
* **Tamar Yankelevich- rosenzweig** - *a depeloper* - (tamary9097@gmail.com)

## Development server

To install your app in your computer you have to:
  1. Run the `mySql` code. (To see some data in the live demo, you should add data to your tabels or run the data- script code.)
     *don't forget to run the `xampp` before using this app.* 

  2. Run the `back-end` project. This is the server. Navigate to `http://localhost:4722/`. The app will automatically reload if you change any     of the source files. The details on the server you can see also in the `environments` file  in the angular app, or in the `app config` file   in the cs project (win form) in the `appSetting` attribute.

  3.  Run `ng serve` for a dev server, if you want to run the angular project. Navigate to `http://localhost:4200/`. The app will automatically     reload if you change any of the source files. Or just run the `cs` project.


## System diagram:
![picture](step1.png)

***
## Web api

### Models
* User:

    * UserId - int, auto increament,primary key
    * UserName - string - minLength: 2, maxLength:15, reqiered
    * Email - string -  reqiered ,pattern
    * Password - string - minLength: 2, maxLength:20, reqiered
    * IsManager - boolean - reqiered
    * DepartmentId - int, required
    * TeamLeaderId - int
    * Navigation  properties:
        * Department - `Department` type
        * TeamLeader - `User` type

* Project:

    * ProjectId - int, auto increament,primary key
    * ProjectName - string - minLength: 2, maxLength:15, reqiered
    * TotalHours - int, required
    * TotalHours - int, required
    * StartDate - dateTime, required
    * endDate - dateTime, required
    * CustomerId - int, required
    * TeamLeaderId - int, required 
    * Navigation  properties:
        * Customer - `Customer` type
        * TeamLeader - `User` type

* DepartmentHours:

    * DepartmentHoursId - int, auto increament,primary key
    * ProjectId - int
    * DepartmentId -int
    * numHours -int
     * Navigation  properties:
        * Project - `Project` type
        * Department - `Department` type

* WorkerHours:

    * WorkerHours - int, auto increament,primary key
    * ProjectId - int
    * WorkerId -int
    * numHours -int
     * Navigation  properties:
        * Project - `Project` type
        * Worker - `User` type

* PresenceHours:

    * PresenceHours - int, auto increament,primary key
    * ProjectId - int
    * WorkerId -int
    * Date- dateTime
    * numHours -int
     * Navigation  properties:
        * Project - `Project` type
        * Worker - `User` type       

* Department:

    * DepartmentId - int, auto increament,primary key
    * DepartmentName - string - minLength: 2, maxLength:15, reqiered 

* Customer:

    * CustomerId - int, auto increament,primary key
    * CustomerName - string - minLength: 2, maxLength:15, reqiered 

### Global Properties


### Controllers

* User controller:
    * Login - sign in to the system    
    requierd data: a `Login` object
    If the user is valid - we will check his status and navigate him to the currect main page, else a suitable message will be send to him.

* Manager screens:

   * Users managmant:
     * GetAllUsers- get all the workers in this company.
     * The manager can manage his workers:
         * Add user - add a new user    
              requierd data: a `User` object
              If the user details is valid - we will add the user to the UsersList, and return true, Else - we will return a matching error
         * Edit user- edit worker's details 
           requierd data: a `User` object
           If the update was successful - we will return true, else a suitable message will be send to him.
         * Delete user- the manager can delete worker
           requierd data:`user id` 
           If the delete prompt was successful - we will return true, else a suitable message will be send to him.
         * Edit pemission - allow the worker to work in other projects, not in his team leader's group. 
                             requierd data:`Permission` 
                             If the permission details is valid - we will add the permission to the PermissionsList, and return true, Else - we will return a matching error

  * Projects managmant:
    * Add project - add a new project   
             requierd data: a `Project` object
             If the project details is valid - we will add the project to the ProjectsList, and return true, Else - we will return a matching error
    * GetProjectsReports-  get all the details that the manager needs to the report. The manager can also filter the report assign to his needs
     and to exporet it into an Excel file.

  * Teams managmant:
    * GetAllTeamLeaders- get all the team leaders in this company.
    * Manage the teams: allow editing the team of a specific team leader, remove or add workers to his team.We call to `Edit user` method, to    edit the `team leader id` propert in the `User` members. (see details above.)

* TeamLeader screens:
   
* Worker screens:
 

***
## WinForms +  Angular
### login 
### Manager page
![picture](add_project.png)  
![picture](team_management.png) 
![picture](add_worker.png)  
![picture](edit_worker.png)
### Team leader page
![picture](worker_list.png) 
![picture](graph_hours_status.png) 
### Worker page 
![picture](home_page.png)  

 