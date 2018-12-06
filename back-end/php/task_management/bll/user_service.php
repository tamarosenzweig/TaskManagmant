<?php

class user_service extends base_service {

    function get_users_query() {
        $query = "SELECT u.*,department_name,tl.user_name as team_leader_name FROM task_management.user u " .
                "LEFT JOIN task_management.department d on u.department_id=d.department_id " .
                "LEFT JOIN task_management.user tl ON u.team_leader_id=tl.user_id " .
                "WHERE u.is_active=1 ";
        return $query;
    }

    function login($login) {
        if (isset($login['email']) and isset($login['password'])) {
            $email = $login['email'];
            $password = $login['password'];

            $query = "SELECT * FROM task_management.user WHERE email='$email' and password='$password'";

            $users = db_access:: run_reader($query, function ($model) {

                        return $this->init_user($model);
                    });
            return count($users) == 1 ? $users[0] : null;
        } else {
            return "error";
        }
    }

    function get_users($query) {
        $users = db_access:: run_reader($query, function ($model) {
                    return $this->init_user($model);
                });
        return $users;
    }

    function get_all_users($manager_id) {
        $query = $this->get_users_query() . " AND u.manager_id=$manager_id;";
        $users = $this->get_users($query);
        $permission_service = new permission_service();
        for ($i = 0; $i < count($users); $i++) {
            $users[i]['permissions'] = $permission_service->get_user_permissions($users[i]['userId']);
        }
        return $users;
    }

    function get_all_team_users($team_leader_id) {
        $query = $this->get_users_query() . " AND u.team_leader_id=$team_leader_id;";
        return $this->get_users($query);
    }

    function get_all_team_leaders($manager_id) {
        $query = $this->get_users_query() . " AND u.team_leader_id IS NULL AND u.manager_id=$manager_id;";
        return $this->get_users($query);
    }

    function get_user_by_id($user_id) {
        $query = $this->get_users_query() . " AND u.user_id=$user_id;";
        $user = $this->get_users($query)[0];
        $permission_service = new permission_service();
        $user['permissions'] = $permission_service->get_user_permissions($user['userId']);
        return $user;
    }

    function add_user($user) {
        $query = "INSERT INTO task_management.user" .
                "(user_name, email, password, profile_image_name, department_id, team_leader_id,manager_id) " .
                "VALUES({$user['UserName']}, {$user['Email']}, {$user['password']}, " .
                "{$user['ProfileImageName']}, " .
                "{$user['DepartmentId']}, " .
                "{$user['TeamLeaderId']}, " .
                "{$user['ManagerId']});" .
                "SELECT @@IDENTITY;";
        $user_id = db_access::run_scalar(query);
        $created = false;
        if (isset($user_id)) {
            $created = true;
            $user['UserId'] = $user_id;
            //add worker hours to worker for projects in his team
            worker_hours_service::add_worker_hours_to_team_projects($user);
        } else {
            $created = false;
        }
        return created;
    }

    function edit_user($user) {
        $query = "UPDATE task_management.user SET user_name={$user['UserName']},email={$user['Email']},profile_image_name={$user['ProfileImageName']}," .
                "department_id={$user['DepartmentId']},team_leader_id={$user['TeamLeaderId']} "
                . "where user_id={$user['UserId']};";
        $edited = db_access::run_non_query(query) == 1;
        if (isset($edited)) {
            //manage worker hours to team-projects if the worker moves team
            $old_user = $this->get_user_by_id($user['UserId']);
            if ($old_user['TeamLeaderId'] != $user['TeamLeaderId'] && $user['TeamLeaderId'] != null) {
                permission_service::delete_unnecessary_permissions($user);
                worker_hours_service::add_worker_hours_to_team_projects($user);
            }
        }
        return $edited;
    }

    function get_department_users_has_project($department_id, $project_id) {
        $query = "{$this->get_users_query()} " .
                "AND u.department_id=$department_id " .
                "AND u.user_id in (SELECT worker_id FROM task_management.worker_hours WHERE project_id=$project_id);";
        return $this->get_users($query);
    }

}
