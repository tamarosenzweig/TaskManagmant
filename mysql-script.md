```sql

CREATE DATABASE task_management;

USE task_management;

CREATE TABLE IF NOT EXISTS department(
	department_id INT AUTO_INCREMENT,
	department_name NVARCHAR(16) NOT NULL,
	PRIMARY KEY (department_id)

);

CREATE TABLE IF NOT EXISTS user (
    user_id INT AUTO_INCREMENT,
    user_name NVARCHAR(16) NOT NULL,
    email NVARCHAR(30) NOT NULL,
    password NVARCHAR(65) NOT NULL,
    profile_image_name NVARCHAR(50),
    is_manager BIT NOT NULL DEFAULT 0,
    department_id INT,
    team_leader_id INT, 
	manager_id INT,
	is_active BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (user_id),
	FOREIGN KEY(department_id) REFERENCES department(department_id),
	FOREIGN KEY(team_leader_id) REFERENCES user(user_id),
	FOREIGN KEY(manager_id) REFERENCES user(user_id)

);

CREATE TABLE IF NOT EXISTS customer (
    customer_id INT AUTO_INCREMENT,
    customer_name NVARCHAR(16) NOT NULL,

	PRIMARY KEY (customer_id)
   
);


CREATE TABLE IF NOT EXISTS project (
    project_id INT AUTO_INCREMENT,
    project_name NVARCHAR(16) NOT NULL,
    manager_id INT NOT NULL,
	customer_id INT NOT NULL,
	team_leader_id INT NOT NULL,
	total_hours INT NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    is_complete BIT NOT NULL DEFAULT 0,

	PRIMARY KEY (project_id),
	FOREIGN KEY(manager_id) REFERENCES user(user_id),
	FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
	FOREIGN KEY(team_leader_id) REFERENCES user(user_id)
);

CREATE TABLE IF NOT EXISTS department_hours (
    department_hours_id INT AUTO_INCREMENT,
    project_id INT NOT NULL,
	department_id INT NOT NULL,
	num_hours INT NOT NULL,
	
	PRIMARY KEY (department_hours_id),
	FOREIGN KEY(project_id) REFERENCES project(project_id),
	FOREIGN KEY(department_id) REFERENCES department(department_id)

);

CREATE TABLE IF NOT EXISTS worker_hours (
    worker_hours_id INT AUTO_INCREMENT,
    project_id INT NOT NULL,
	worker_id INT NOT NULL,
	num_hours INT NOT NULL,
	is_complete BIT NOT NULL DEFAULT 0,
	is_active BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (worker_hours_id),
	FOREIGN KEY(project_id) REFERENCES project(project_id),
	FOREIGN KEY(worker_id) REFERENCES user(user_id)

);

CREATE TABLE IF NOT EXISTS presence_hours (
    presence_hours_id INT AUTO_INCREMENT,
	worker_id INT NOT NULL,
    project_id INT NOT NULL,
    start_hour DATETIME NOT NULL,
	end_hour DATETIME,
	
	PRIMARY KEY (presence_hours_id),
    FOREIGN KEY(worker_id) REFERENCES user(user_id),
	FOREIGN KEY(project_id) REFERENCES project(project_id)

);

CREATE TABLE IF NOT EXISTS permission (
    permission_id INT AUTO_INCREMENT,
	worker_id INT NOT NULL,
    project_id INT NOT NULL,
	is_active BIT NOT NULL DEFAULT 1,
	PRIMARY KEY (permission_id),
    FOREIGN KEY(worker_id) REFERENCES user(user_id),
	FOREIGN KEY(project_id) REFERENCES project(project_id)

);

```