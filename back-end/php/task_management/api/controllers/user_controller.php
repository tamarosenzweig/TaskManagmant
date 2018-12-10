<?php

class user_controller extends controller_singletone {

    //post
    public function login($params) {
        return $this->service->login($params);
    }

    //get
    public function get_all_users($params) {
        return $this->service->get_all_manager_users($params['managerId']);
    }

    //get
    public function get_all_team_users($params) {
        return $this->service->get_all_team_users($params['teamLeaderId']);
    }

    //get
    public function get_all_team_leaders($params) {
        return $this->service->get_all_team_leaders($params['managerId']);
    }

    //get
    public function get_user_by_id($params) {
        return $this->service->get_user_by_id($params['userId']);
    }

    public function get_user_by_email($params) {
        return $this->service->get_user_by_email($params['email']);
    }

    //post
    public function add_user($params) {
        return $this->service->add_user($params);
    }

    //put
    public function edit_user($params) {
        return $this->service->edit_user($params);
    }

    //put
    public function delete_user($params) {
        return $this->service->delete_user($params['userId']);
    }

    public function upload_image_profile($params) {
        $file = array_values($params['files'])[0];
        return $this->service->upload_image_profile($file);
    }

    public function remove_uploaded_image($params) {
        return $this->service->remove_uploaded_image($params['profileImageName'], $params['moveToArchives']);
    }

    //post- form data
    public function send_email($params) {
        return $this->service->send_email(json_decode($params['email'], true), json_decode($params['user'], true));
    }

    public function check_unique_validations($params) {
        return $this->service->check_unique_validations($params);
    }

    //get
    public function has_workes($params) {
        return $this->service->has_workes($params['teamLeaderId']);
    }

    public function forgot_password($params) {
        return $this->service->forgot_password($params['email']);
    }

    public function confirm_token($params) {
        return $this->service->confirm_token($params);
    }

    public function change_password($params) {
        return $this->service->change_password($params);
    }

}
