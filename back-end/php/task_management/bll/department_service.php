<?php

class department_service extends base_service {

    public function get_all_departments() {
        $query = "SELECT * FROM task_management.department;";
        $departments = db_access:: run_reader($query, function ($model) {
                    return $this->init_department($model);
                });
        return $departments;
    }

}
