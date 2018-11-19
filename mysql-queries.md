```sql
/*========================= user =========================*/

INSERT INTO task_management.user(user_name, email, password, profile_image_name, is_manager, department_id, team_leader_id)
 VALUES('Tamar', 'tamar@gmail.com', '4f5f5879014d2e337629ead830d8b856fca20e7d58d9576e936873858ab89a1a', null,1,null , null);

INSERT INTO task_management.user(user_name, email, password, profile_image_name, is_manager, department_id, team_leader_id)
 VALUES('Efrat', 'efrat@gmail.com', '5fcf87a66b37c35f1d108accb994b601e4c21a2989b316724875278ca37d802e', null,0,null , null);

INSERT INTO task_management.user(user_name, email, password, profile_image_name, is_manager, department_id, team_leader_id)
 VALUES('Sara', 'sara1@gmail.com', '3d4475a7cfef33bfeb120940a390f305d30dba91acc137d361be2968d0f06111', null,0,1 , 2);

INSERT INTO task_management.user(user_name, email, password, profile_image_name, is_manager, department_id, team_leader_id)
 VALUES('Rivka', 'rivka@gmail.com', '4f1e8255279a6817c64c4d98b9b5bb20d30a77a54051bf04d3e1824bd2dc41bc', null,0,2 , 2);

/*========================= department =========================*/

INSERT INTO task_management.department(department_name)
 VALUES('Developers');
INSERT INTO task_management.department(department_name)
 VALUES('QA');
INSERT INTO task_management.department(department_name)
 VALUES('UI/UX');

/*========================= customers=========================*/

INSERT INTO task_management.customer(customer_name) VALUES('Amdocs');
INSERT INTO task_management.customer(customer_name) VALUES('Microsoft');
INSERT INTO task_management.customer(customer_name) VALUES('Seldat');

/*========================= projects=========================*/

INSERT INTO task_management.presence_hours(worker_id,project_id,start_hour) VALUES(3, 1, '2018-10-29 13:10:45');


/*========================= presence-hours=========================*/

INSERT INTO `task_management`.`project` (`project_id`, `project_name`, `manager_id`, `customer_id`, `team_leader_id`, `total_hours`, `start_date`, `end_date`, `is_complete`) VALUES ('2', 'microsoft', '1', '1', '2', '30', '2018-10-10', '2018-12-12', b'0');

/*========================= worker-hours=========================*/

INSERT INTO worker_hours(project_id, worker_id, num_hours) VALUES (1, 3, 10);








```