<?php

//routes
require './routes_loader.php';

//dal
require './dal/db_info.php';
require './dal/db_access.php';

//bll
require './bll/base_service.php';
require './bll/customer_service.php';
require './bll/department_hours_service.php';
require './bll/department_service.php';
require './bll/permission_service.php';
require './bll/presence_hours_service.php';
require './bll/project_service.php';
require './bll/user_service.php';
require './bll/worker_hours_service.php';

//api
require './api/controllers/cusomer_controller.php';
require './api/controllers/department_controller.php';
require './api/controllers/permission_controller.php';
require './api/controllers/presence_hours_controller.php';
require './api/controllers/project_controller.php';
require './api/controllers/user_controller.php';
require './api/controllers/worker_hours_controller.php';

