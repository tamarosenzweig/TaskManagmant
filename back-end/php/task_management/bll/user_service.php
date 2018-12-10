<?php

class user_service extends base_service {

    public function login($login) {
        if (isset($login['email']) and isset($login['password'])) {
            $email = $login['email'];
            $password = $login['password'];

            $query = "{$this->get_simple_users_query()} WHERE email='$email' and password='$password'";

            $users = db_access:: run_reader($query, function ($model) {

                        return $this->init_user($model);
                    });
            return count($users) == 1 ? $users[0] : null;
        } else {
            return "error";
        }
    }

    public function get_all_manager_users($manager_id) {
        $query = $this->get_users_query() . " AND u.manager_id=$manager_id;";
        $users = $this->get_all_users($query);
        return $users;
    }

    public function get_all_team_users($team_leader_id) {
        $query = $this->get_users_query() . " AND u.team_leader_id=$team_leader_id;";
        return $this->get_all_users($query);
    }

    public function get_all_team_leaders($manager_id) {
        $query = $this->get_users_query() . " AND u.team_leader_id IS NULL AND u.manager_id=$manager_id;";
        return $this->get_users($query);
    }

    public function get_user_by_id($user_id) {
        $query = $this->get_users_query() . " AND u.user_id=$user_id;";
        $user = $this->get_users($query)[0];
        $permission_service = permission_service::get_instance();
        $user['permissions'] = $permission_service->get_user_permissions($user['userId']);
        return $user;
    }

    public function get_user_by_email($email) {
        $query = "SELECT * FROM task_management.user WHERE email ='$email';";
        $users = $this->get_users($query);
        if (count($users) > 0) {
            return $users[0];
        }
        return null;
    }

    public function add_user($user) {
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
            $worker_hours_service = worker_hours_service::get_instance();
            $worker_hours_service->add_worker_hours_to_team_projects($user);
        }
        return $created;
    }

    public function edit_user($user) {

        $old_user = $this->get_user_by_id($user['userId']);

        $query = "UPDATE task_management.user SET user_name='{$user['userName']}',email='{$user['email']}'," .
                "profile_image_name={$this->get_value_or_null($user, 'profileImageName')}," .
                "department_id={$this->get_value_or_null($user, 'departmentId')}," .
                "team_leader_id={$this->get_value_or_null($user, 'teamLeaderId')} " .
                "where user_id={$user['userId']};";
        $affected_rows = db_access::run_non_query($query);
        $edited = $affected_rows > 0;
        if ($edited) {
            // manage worker hours to team-projects if the worker moves team
            if ($old_user['teamLeaderId'] != $user['teamLeaderId'] && isset($user['teamLeaderId'])) {
                $permission_service = permission_service::get_instance();
                $permission_service->delete_unnecessary_permissions($user);
                $worker_hours_service = worker_hours_service::get_instance();
                $worker_hours_service->add_worker_hours_to_team_projects($user);
            }
        }
        return $edited;
    }

    public function delete_user($user_id) {
        $query = "UPDATE task_management.user SET is_active=0 where user_id=$user_id AND is_active=1;";
        $affected_rows = db_access::run_non_query($query);
        $deleted = $affected_rows > 0;
        if ($deleted) {
            $permission_service = permission_service::get_instance();
            $permissions = $permission_service->get_user_permissions($user_id);
            foreach ($permissions as $permission) {
                $permission_service->delete_permission($permission['permissionId']);
            }
        }
        return $deleted;
    }

    public function upload_image_profile($file) {
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

    public function remove_uploaded_image($profile_image_name, $move_to_archives) {
        $source_file = getcwd() . DIRECTORY_SEPARATOR . 'images/users-profiles/' . $profile_image_name;
        if (json_decode($move_to_archives) == true) {
            $destination_file = getcwd() . DIRECTORY_SEPARATOR . 'images/archives/users-profiles/' . $profile_image_name;
            rename($source_file, $destination_file);
        } else {
            unlink($source_file);
        }
        return true;
    }

    public function send_email($email, $user) {
        $manager_id = $user['managerId'];
        $manager = $this->get_user_by_id($manager_id);
        $email['to_address'] = $manager['email'];
        $email['body'] .= PHP_EOL . 'from' . $user['userName'];
        return $this->basic_send_email($email);
    }

    public function check_unique_validations($user) {
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
                    "WHERE $key='{$user[$key]}' AND is_active=1";
            $users = $this->get_users($query);
            //If there is a user in the database with such a value and this is a different user
            if (count($users) > 0 && $users[0]['userId'] != $user['userId']) {
                $error_message = array();
                $error_message['val'] = "$key must be unique";
                return $error_message;
            }
            return null;
        }
        return null;
    }

    public function has_workes($team_leader_id) {
        $query = "SELECT COUNT(*) as count FROM task_management.user WHERE team_leader_id=$team_leader_id;";
        $count = db_access::run_scalar($query);
        return $count > 0;
    }

    public function forgot_password($email) {
        $user = $this->get_user_by_email($email);
        if (!isset($user)) {
            return false;
        }
        $my_token = $this->generate_randon_no();
        $created = $this->add_change_password($user['userId'], $my_token);
        if ($created) {
            $email = array();
            $email['to_address'] = $user['email'];
            $email['subject'] = "A verification code has been sent to you";
            ;
            $email['body'] = "Please enter the following verification code:$my_token" .
                    " The code is only valid for an hour.";

            $this->basic_send_email($email);
            return true;
        }
        return false;
    }

    public function confirm_token($change_password) {
        $query = "SELECT COUNT(*) as count FROM task_management.change_password " .
                "WHERE user_id = {$change_password['userId']} AND token = '{$change_password['token']}' AND attemp_num<3;";
        $count = db_access::run_scalar($query);
        if ($count > 0) {
            return true;
        }
        $query = "UPDATE task_management.change_password SET attemp_num=attemp_num+1 WHERE user_id={$change_password['userId']};";
        db_access::run_non_query($query);
        return false;
    }

    public function change_password($user) {
        $user['email'] = null;
        $error_message = $this->check_unique_validations($user);
        if (isset($error_message)) {
            http_response_code(400);
            $errors = array();
            $errors[] = $error_message['val'];
            die(json_encode($errors));
        }
        $query = "UPDATE task_management.user SET password='{$user['password']}' where user_id={$user['userId']};";
        $affected_rows = db_access::run_non_query($query);
        $edited = $affected_rows == 1;
        return $edited;
    }

    public function get_department_users_has_project($department_id, $project_id) {
        $query = "{$this->get_users_query()} " .
                "AND u.department_id=$department_id " .
                "AND u.user_id in (SELECT worker_id FROM task_management.worker_hours WHERE project_id=$project_id);";
        return $this->get_all_users($query);
    }

    private function generate_randon_no() {
        $number = '';
        for ($i = 0; $i < 4; $i++) {
            $number .= mt_rand(0, 9);
        }
        return $number;
    }

    private function add_change_password($user_id, $token) {
        $query = "INSERT INTO task_management.change_password(user_id, token, sending_date) " .
                "VALUES($user_id, $token, {$this->format_date(null, 'Y-m-d H:i:s')});";
        $result = db_access::run_non_query($query);
        return isset($result);
    }

    private function get_simple_users_query() {
        $query = "SELECT * FROM task_management.user";
        return $query;
    }

    private function get_users_query() {
        $query = "SELECT u.*,department_name,tl.user_name as team_leader_name FROM task_management.user u " .
                "LEFT JOIN task_management.department d on u.department_id=d.department_id " .
                "LEFT JOIN task_management.user tl ON u.team_leader_id=tl.user_id " .
                "WHERE u.is_active=1 ";
        return $query;
    }

    private function get_users($query) {
        $users = db_access:: run_reader($query, function ($model) {
                    return $this->init_user($model);
                });
        return $users;
    }

    private function get_all_users($query) {

        $users = $this->get_users($query);
        $permission_service = permission_service::get_instance();
        for ($i = 0; $i < count($users); $i++) {
            $users[$i]['permissions'] = $permission_service->get_user_permissions($users[$i]['userId']);
        }
        return $users;
    }

}
