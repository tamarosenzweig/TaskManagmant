<?php

class worker_hours_service extends base_service {

    public function get_all_worker_hours($worker_id) {
        $query = $this->get_worker_hours_query() .
                " WHERE worker_id =$worker_id AND w.is_complete=0;";
        return $this->get_workers_hours($query);
    }

    public function edit_worker_hours($worker_hours) {
        $presence_hours_service = presence_hours_service::get_instance();
        $presence_hours_sum = $presence_hours_service->get_presence_hours_sum($worker_hours['projectId'], $worker_hours['workerId']);
        if ($presence_hours_sum > $worker_hours['numHours']) {
            $worker_hours['isComplete'] = true;
        } else {
            $worker_hours['isComplete'] = false;
        }
        $project_service = project_service::get_instance();
        $project_service->update_project_status($worker_hours['projectId']);
        $query = "UPDATE task_management.worker_hours " .
                "SET num_hours={$worker_hours['numHours']},is_complete={$worker_hours['isComplete']} " .
                "WHERE worker_hours_id={$worker_hours['workerHoursId']};";
        $edited = db_access::run_non_query($query) == 1;
        return $edited;
    }

    public function has_uncomleted_hours($worker_id, $project_id_list) {
        $query = "SELECT COUNT(*) as count FROM task_management.worker_hours " .
                "WHERE worker_id =$worker_id AND is_complete=0";
        if (isset($project_id_list)) {
            $query .= " AND project_id IN(";

            foreach ($project_id_list as $project_id) {
                $query .= "$project_id,";
            }
            $query = substr($query, 0, - 1);
            $query .= ");";
        } else {
            $query .= ";";
        }
        $count = db_access::run_scalar($query);
        return $count > 0;
    }

    public function get_all_worker_hours_per_project($project_id) {
        $query = $this->get_worker_hours_query() . " WHERE w.project_id =$project_id;";
        return $this->get_workers_hours($query);
    }

    public function get_uncompleted_workers_hours($project_id) {
        $query = $this->get_worker_hours_query() . " WHERE w.is_complete=false AND w.project_id =$project_id;";
        return $this->get_workers_hours($query);
    }

    public function get_worker_hours_per_project($worker_id, $project_id) {
        $query = $this->get_worker_hours_query() . " WHERE worker_id =$worker_id AND w.project_id=$project_id;";
        return $this->get_workers_hours($query);
    }

    public function add_worker_hours($worker_hours) {
        $query = "INSERT INTO task_management.worker_hours(project_id,worker_id,num_hours,is_complete) " .
                "VALUES ({$worker_hours['projectId']},{$worker_hours['workerId']},{$worker_hours['numHours']},1);";
        $created = db_access::run_non_query($query) != null;
        return $created;
    }

    public function add_worker_hours_to_team_projects($user) {
        if (isset($user['teamLeaderId'])) {
            $project_service = project_service::get_instance();
            $projects = $project_service->get_projects_in_working_by_team_leader_id($user['teamLeaderId']);
            foreach ($projects as $project) {
                $worker_hours_service = worker_hours_service::get_instance();
                $workers_hours = $worker_hours_service->get_worker_hours_per_project($user['userId'], $project['projectId']);
                if (count($workers_hours) == 0) {
                    $worker_hours = array();
                    $worker_hours['projectId'] = $project['projectId'];
                    $worker_hours['workerId'] = $user['userId'];
                    $worker_hours['numHours'] = 0;
                    $this->add_worker_hours($worker_hours);
                }
            }
        }
    }

    private function get_worker_hours_query() {
        $query = "SELECT w.*,project_name,user_name,email,department_name " .
                "FROM task_management.worker_hours w " .
                "JOIN task_management.project p ON w.project_id=p.project_id " .
                "JOIN task_management.user u ON w.worker_id=u.user_id " .
                "JOIN task_management.department d ON u.department_id=d.department_id";
        return $query;
    }

    private function get_workers_hours($query) {
        $worker_hours_list = db_access::run_reader($query, function ($model) {
                    return $this->init_worker_hours($model);
                });
        return $worker_hours_list;
    }

}
