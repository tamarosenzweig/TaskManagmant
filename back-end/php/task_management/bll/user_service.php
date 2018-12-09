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
            $users[$i]['permissions'] = $permission_service->get_user_permissions($users[$i]['userId']);
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
                "VALUES('{$user['userName']}', '{$user['email']}', '{$user['password']}', " .
                "{$this->get_value_or_null($user, 'profileImageName')}," .
                "{$this->get_value_or_null($user, 'departmentId')}," .
                "{$this->get_value_or_null($user, 'teamLeaderId')}," .
                "{$this->get_value_or_null($user, 'managerId')});";

        $user_id = db_access::run_non_query($query);
        $created = false;
        if (isset($user_id)) {
            $created = true;
            $user['userId'] = $user_id;
            //add worker hours to worker for projects in his team
            $worker_hours_service=new worker_hours_service();
            $worker_hours_service->add_worker_hours_to_team_projects($user);
        }
        return $created;
    }

    function edit_user($user) {

        $query = "UPDATE task_management.user SET user_name='{$user['userName']}',email='{$user['email']}'," .
                "profile_image_name={$this->get_value_or_null($user, 'profileImageName')}," .
                "department_id={$this->get_value_or_null($user, 'departmentId')}," .
                "team_leader_id={$this->get_value_or_null($user, 'teamLeaderId')}" .
                "where user_id={$user['userId']};";


        $connection = db_access::run_non_query($query);
        $edited = $connection->affected_rows > 0;
//        if($edited)
//        if (isset($edited)) {
        //manage worker hours to team-projects if the worker moves team
//            $old_user = $this->get_user_by_id($user['userId']);
//            if ($old_user['teamLeaderId'] != $user['teamLeaderId'] && $user['teamLeaderId'] != null) {
//                $this->permission_service->delete_unnecessary_permissions($user);
//                $this->worker_hours_service->add_worker_hours_to_team_projects($user);
//            }
//        }
        return $edited;
    }

    function delete_user($user_id) {
        $query = "UPDATE task_management.user SET is_active=0 where user_id=$user_id AND is_active=1;";
        $connection = db_access::run_non_query($query);
        $deleted = $connection->affected_rows > 0;
//        if ($deleted) {
//            $permissions = $this->permission_service->get_user_permissions($user_id);
//            foreach ($permissions as $permission) {
//                $this->permission_service->delete_permission($permission['permission_id']);
//            }
//        }
        return $deleted;
    }

    function get_department_users_has_project($department_id, $project_id) {
        $query = "{$this->get_users_query()} " .
                "AND u.department_id=$department_id " .
                "AND u.user_id in (SELECT worker_id FROM task_management.worker_hours WHERE project_id=$project_id);";
        return $this->get_users($query);
    }

    function check_unique_validations($user) {
        $key;
        if (isset($user['email'])) {
            $key = 'email';
        } else {
            if (isset($user['password'])) {
                $key = 'password';
            }
        }
        if (isset($key)) {
            $query = "SELECT * FROM task_management.user " .
                    "WHERE $key='{$user[$key]}'";
            $users= $this->get_users($query);
            //If there is a user in the database with such a value and this is a different user
            if (count($users) > 0&&$users[0]['userId']!=$user['userId']) {
                $error_message = array();
                $error_message['val'] = "$key must be unique";
                return $error_message;
            }
            return null;
        }
        return null;
    }

    function upload_image_profile($file) {
        $allowed = array('png', 'jpg', 'jpeg');
        $filename = $file['name'];
        $file_extension = pathinfo($filename, PATHINFO_EXTENSION);
        if (!in_array($file_extension, $allowed)) {
            echo 'error';
        }
        $new_file_name = bin2hex(openssl_random_pseudo_bytes(16)) . '.' . $file_extension;

        $destination_path = getcwd() . DIRECTORY_SEPARATOR . 'images/users-profiles/';
        $target_path = $destination_path . basename($new_file_name);
        @move_uploaded_file($file['tmp_name'], $target_path);
        return $new_file_name;
    }

}
