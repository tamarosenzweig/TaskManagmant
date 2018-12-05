<?php

class project_service extends base_service {

    function add_project($new_project) {
        $new_project['startDate'] = new DateTime($new_project['startDate']);
        $new_project['endDate'] = new DateTime($new_project['endDate']);

        $query = "START TRANSACTION;";
        $query .= "INSERT INTO task_management.project(project_name,manager_id,customer_id,team_leader_id,total_hours,start_date,end_date) " .
                "VALUES('{$new_project['projectName']}',{$new_project['managerId']},{$new_project['customerId']}," .
                "{$new_project['teamLeaderId']},{$new_project['totalHours']}," .
                // "{$this->format_date($new_project['startDate'])},{$this->format_date($new_project['endDate'])});";
                "'2018-10-10','2018-10-10');";
//take id of the inserted project
        $query .= "SELECT @@IDENTITY INTO @project_id;";
//add the divided hours for each department
        foreach ($new_project['departmentsHours'] as $department_hours) {
            $query .= "INSERT INTO task_management.department_hours(project_id,department_id,num_hours) " .
                    "VALUES(@project_id,{$department_hours['departmentId']},{$department_hours['numHours']});";
        }
//add permission and worker-hours with default value-0 to extra workers if exists
        if (isset($new_project['permissions'])) {
            foreach ($new_project['permissions'] as $permission) {
                $query .= "INSERT INTO task_management.permission(worker_id,project_id) " .
                        "VALUES({$permission['workerId']},@project_id);";
                $query .= "INSERT INTO task_management.worker_hours(project_id,worker_id,is_complete) " .
                        "VALUES (@project_id,{$permission['workerId']},1);";
            }
        }
//add worker-hours with default value-0 to all team workers 
        $user_service = new user_service();
        $team_workers = $user_service->get_all_team_users($new_project['teamLeaderId']);
        foreach ($team_workers as $worker) {
            $query .= "INSERT INTO task_management.worker_hours(project_id,worker_id,is_complete) " .
                    "VALUES (@project_id,{$worker['userId']},1);";
        }
        $query .= "COMMIT;";
        //return $query;
        $affected_rows = db_access::run_non_query($query);
        return $affected_rows >= 4;
    }

    function edit_project($project) {

        $query = "UPDATE task_management.project " .
                "SET is_complete=1 " .
                "WHERE project_id={$project['projectId']};";
        return db_access::run_non_query($query);
    }

    function get_all_projects() {
        $query = $this->get_projects_query();
        return $this->get_projects($query);
    }

    function get_all_projects_with_deadline_tomorrow($date) {
        $tommorow_date = $date->modify('+1 day');
        $query = "{$this->get_all_projects_query()} WHERE end_date={$this->format_date($tommorow_date)} AND is_complete=false;";
        $projectsList = $this->get_projects($query);
        return $projectsList;
    }

    function get_project_by_team_leader_id($team_leader_id) {
        $query = "{$this->get_projects_query()} WHERE p.team_leader_id=$team_leader_id;";
        return $this->get_projects($query);
    }

    function get_projects_in_working_by_team_leader_id($team_leader_id) {

        $query = "{$this->get_projects_query()} " .
                "WHERE p.team_leader_id=$team_leader_id " .
                "AND end_date>={$this->format_date(today)} AND is_complete=0;";
        $project_list = $this->get_projects_with_details($query);
        return $project_list;
    }

    function get_project_by_id($project_id) {
        $query = "{$this->get_projects_query()} WHERE project_id=$project_id;";
        return $this->get_projects($query);
    }

    function get_projects_reports() {
        $query = "{$this->get_projects_query()} ORDER BY project_name;";
        $project_list = $this->get_projects($query);
        return $project_list;
    }

    function update_project_status($project_id) {
        $project = $this->get_project_by_id($project_id);
        $worker_hours_service = new worker_hours_service();
        $worker_hours_list = $worker_hours_service->get_all_worker_hours_per_project($project_id);
        $isComplete = array_search($worker_hours_list, function ($worker_hours) {
                    return !$worker_hours['isComplete'];
                }) == false;
        $project_num_hours = array_sum(array_column($worker_hours_list, 'numHours'));
        if ($isComplete && $project_num_hours >= $project['totalHours']) {
            $this->edit_project($project);
        }
    }

    function check_unique_validation($project) {
        $query = "SELECT COUNT(*) FROM task_management.project WHERE project_name={$project['projecrName']}";
        return db_access::run_scalar($query) == 0;
    }

    function has_projects($team_leader_id) {
        $query = "SELECT COUNT(*) FROM task_management.project " .
                "WHERE team_leader_id=$team_leader_id;";
        $count = db_access::run_scalar($query);
        return $count > 0;
    }

    function get_all_projects_query() {
        $query = "SELECT * FROM task_management.project";
        return $query;
    }

    function get_projects_query() {
        $query = "SELECT " .
                "p.project_id,project_name,p.manager_id,p.customer_id," .
                "p.team_leader_id,total_hours,start_date,end_date,is_complete," .
                "customer_name,user_name,email " .
                "FROM task_management.project p " .
                "JOIN task_management.customer c " .
                "ON p.customer_id = c.customer_id " .
                "JOIN task_management.user u " .
                "ON p.team_leader_id = u.user_id";
        return $query;
    }

    function get_projects($query) {
        $projects = db_access:: run_reader($query, function ($model) {
                    return $this->init_project($model);
                });
        return $projects;
    }

    function get_projects_with_details($query) {
        $projects = db_access:: run_reader($query, function ($model) {
                    $project = $this->init_project($model);
                    $this->add_details_to_project($project);
                    return $project;
                });
        return $projects;
    }

    function add_details_to_project($project) {
        $department_hours_service = new department_hours_service();
        $project['departmentsHours'] = $department_hours_service->get_departments_hours($project['projectId']);
        $user_service = new user_service();
        $worker_hours_service = new worker_hours_service();
        $presence_hours_service = new presence_hours_service();
        foreach ($project['departmentsHours'] as $department_hours) {
            $department_hours['department']['workers'] = $user_service->get_department_users_has_project($department_hours['departmentId'], $project['projectId']);
            foreach ($department_hours['department']['workers'] as $worker) {
                $worker['workerHours'] = $worker_hours_service->get_worker_hours_per_project($worker['userId'], $project['projectId']);
                $worker['presenceHours'] = $presence_hours_service->get_presence_hours($worker['userId'], $project['projectId']);
            }
        }
    }

}
