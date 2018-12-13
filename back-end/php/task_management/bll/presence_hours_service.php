
<?php

class presence_hours_service extends base_service {

    public function add_presence_hours($new_presence_hours) {
//check if date and time is exactly
        $query = "INSERT INTO task_management.presence_hours(worker_id,project_id,start_hour) " .
                "VALUES('{$new_presence_hours['workerId']}', '{$new_presence_hours['projectId']}', " .
                "{$this->format_date($new_presence_hours['startHour'], 'Y-m-d H:i:s')});";

        $presence_hours_id = db_access::run_non_query($query);
        return isset($presence_hours_id) ? $presence_hours_id : -1;
    }

    public function edit_presence_hours($presence_hours) {
        //check if date and time is exactly
        $query = "UPDATE task_management.presence_hours " .
                "SET end_hour={$this->format_date($presence_hours['endHour'], 'Y-m-d H:i:s')} " .
                "WHERE presence_hours_id={$presence_hours['presenceHoursId']};";

        $created = db_access::run_non_query($query) == 1;
        if ($created) {
            $worker_hours_service = worker_hours_service::get_instance();
            $worker_hours = $worker_hours_service->get_worker_hours_per_project($presence_hours['workerId'], $presence_hours['projectId'])[0];
            $worker_hours_service->edit_worker_hours($worker_hours);
        }
        return $created;
    }

    public function get_presence_status_per_workers($team_leader_id) {
        //create view that select presence status
        $query = "CREATE VIEW task_management.presence_status " .
                "AS " .
                "SELECT user_name, pro.project_name,w.num_hours, IFNULL(SUM(TIMESTAMPDIFF(SECOND, start_hour, end_hour) / 3600), 0) AS presence " .
                "FROM task_management.user u " .
                "JOIN task_management.worker_hours w ON w.worker_id = u.user_id " .
                "JOIN task_management.project pro ON w.project_id = pro.project_id " .
                "LEFT JOIN task_management.presence_hours pre ON pre.project_id = pro.project_id AND pre.project_id = w.project_id AND pre.worker_id = u.user_id AND pre.worker_id = w.worker_id " .
                "WHERE u.team_leader_id = $team_leader_id AND(MONTH(start_hour) is null or MONTH(start_hour) = MONTH(CURRENT_DATE())) GROUP BY user_name, pre.project_id;";
        db_access::run_non_query($query);
//select sum of all projects presence status per worker and details of every project
        $query = "SELECT user_name,null AS project_name,sum(num_hours) AS num_hours, sum(presence)  AS presence " .
                "FROM task_management.presence_status " .
                "GROUP BY user_name " .
                "UNION SELECT * FROM task_management.presence_status;";
        $presence_status_list = db_access:: run_reader($query, function ($model) {
                    return $this->init_presence_status($model);
                });
        $query = "DROP VIEW task_management.presence_status";
        db_access::run_non_query($query);

        return $presence_status_list;
    }

    public function get_presence_status_per_projects($worker_id) {
        $query = "SELECT pro.project_name,IFNULL(SUM(TIMESTAMPDIFF(SECOND, start_hour, end_hour) / 3600), 0) AS presence, num_hours " .
                "FROM task_management.worker_hours w " .
                "LEFT JOIN task_management.project pro " .
                "ON pro.project_id = w.project_id " .
                "LEFT JOIN task_management.presence_hours pre " .
                "ON pro.project_id = pre.project_id AND pre.worker_id = $worker_id AND MONTH(start_hour) = MONTH(CURRENT_DATE()) " .
                "WHERE w.worker_id = $worker_id " .
                "AND w.num_hours > 0 " .
                "GROUP BY pre.project_id;";
        $presence_status_list = db_access::run_reader($query, function($model) {
                    return $this->init_presence_status($model);
                });
        return $presence_status_list;
    }

    public function get_presence_hours_sum($project_id, $worker_id) {
        $query = "SELECT IFNULL(SUM(TIMESTAMPDIFF(SECOND, start_hour, end_hour)/3600),0) AS sum " .
                "FROM task_management.presence_hours " .
                "WHERE project_id = $project_id AND worker_id = $worker_id";
        $sum = db_access::run_scalar($query);
        return $sum;
    }

    public function get_presence_hours($worker_id, $project_id) {
        $query = "SELECT p.*,u.user_name FROM task_management.presence_hours p " .
                "JOIN task_management.user u ON p.worker_id=u.user_id " .
                "WHERE end_hour IS NOT NULL AND worker_id=$worker_id AND project_id=$project_id;";
        $presence_hours_list = db_access:: run_reader($query, function ($model) {
                    return $this->init_presence_hours($model);
                });
        return $presence_hours_list;
    }

    private function init_presence_status($presence_status) {
        $new_presence_status = array();
        if (array_key_exists('user_name', $presence_status)) {
            $new_presence_status['userName'] = $presence_status['user_name'];
        }
        $new_presence_status['projectName'] = $presence_status['project_name'];
        $new_presence_status['projectHours'] = $presence_status['num_hours'];
        $new_presence_status['presenceHours'] = $presence_status['presence'];
        return $new_presence_status;
    }

}
