<?php

class department_hours_service extends base_service {

    public function get_departments_hours($project_id) {
        $query = "SELECT department_hours_id,project_id,dh.department_id,num_hours,department_name " .
                "FROM task_management.department_hours dh " .
                "JOIN task_management.department d " .
                "ON dh.department_id = d.department_id " .
                "where project_id = $project_id";
        $departments_hours = db_access::run_reader($query, function($department_hours) {
                    return $this->init_department_hours($department_hours);
                });
        return $departments_hours;
    }

}
