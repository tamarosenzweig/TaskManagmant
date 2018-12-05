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

            $user = db_access:: run_reader($query, function ($model) {

                        return $this->init_user($model);
                    })[0];
            return $user;
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
        return $this->get_users($query);
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
        return $this->get_users($query)[0];
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

}
