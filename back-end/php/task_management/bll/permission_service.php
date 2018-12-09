<?php

class permission_service extends base_service {

    function get_user_permissions($user_id) {
        $query = "SELECT per.*, u.user_name,pro.project_name " .
                "FROM task_management.permission per " .
                "JOIN task_management.user u ON per.worker_id = u.user_id " .
                "JOIN task_management.project pro ON per.project_id = pro.project_id " .
                "WHERE per.is_active = 1 and per.worker_id = $user_id;";
        return $this->get_permissions($query);
    }

    function get_permissions($query) {
        $permissions = db_access:: run_reader($query, function ($model) {
                    return $this->init_permission($model);
                });
        return $permissions;
    }

    function add_pemission($permission) {
        $query = "INSERT INTO task_management.permission(worker_id,project_id) " .
                "VALUES({$permission['workerId']},{$permission['projectId']});";
        $permission_id = db_access::run_non_query($query);
        $worker_hours_service = new worker_hours_service();
        $workers_hours = $worker_hours_service->get_worker_hours_per_project($permission['workerId'], $permission['projectId']);
        if (count($workers_hours) == 0) {
            $worker_hours = array();
            $worker_hours['projectId'] = $permission['projectId'];
            $worker_hours['workerId'] = $permission['workerId'];
            $worker_hours['numHours'] = 0;
            $worker_hours_service->add_worker_hours($worker_hours);
        }
        return $permission_id;
    }

    function delete_permission($permission_id) {
        $query = "UPDATE task_management.permission SET is_active=0 WHERE permission_id=$permission_id AND is_active=1;";
        $deleted = db_access::run_non_query($query) == 1;
        return $deleted;
    }

    function delete_unnecessary_permissions($user) {
        $worker_permissions = $this->get_worker_permission_to_team_projects($user);
        foreach ($worker_permissions as $permission) {
            $this->delete_pemission($permission['permissionId']);
        }
    }

    function get_worker_permission_to_team_projects($user) {
        $query = "SELECT * FROM task_management.permission " .
                "WHERE worker_id = {$user['userId']} AND project_id IN" .
                "(SELECT project_id FROM task_management.project WHERE team_leader_id = {$user['teamLeaderId']});";
        return $this->get_permissions($query);
    }

}
