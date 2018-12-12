<?php

//route=user
class user_controller extends controller_singletone {

    //post
    //route=login
    public function login($params) {
        return $this->service->login($params);
    }

    //get
    //route=getAllUsers
    public function get_all_users($params) {
        return $this->service->get_all_manager_users($params['managerId']);
    }

    //get
    //route=getAllTeamUsers
    public function get_all_team_users($params) {
        return $this->service->get_all_team_users($params['teamLeaderId']);
    }

    //get
    //route=getAllTeamLeaders
    public function get_all_team_leaders($params) {
        return $this->service->get_all_team_leaders($params['managerId']);
    }

    //get
    //route=getUserById
    public function get_user_by_id($params) {
        return $this->service->get_user_by_id($params['userId']);
    }

    //get
    //route=getUserByEmail
    public function get_user_by_email($params) {
        return $this->service->get_user_by_email($params['email']);
    }

    //post
    //route=addUser
    public function add_user($params) {
        return $this->service->add_user($params);
    }

    //put
    //route=editUser
    public function edit_user($params) {
        return $this->service->edit_user($params);
    }

    //put
    //route=deleteUser
    public function delete_user($params) {
        return $this->service->delete_user($params['userId']);
    }

    //post
    //route=uploadImageProfile
    public function upload_image_profile($params) {
        $file = array_values($params['files'])[0];
        return $this->service->upload_image_profile($file);
    }

    //post
    //removeUploadImage
    public function remove_uploaded_image($params) {
        return $this->service->remove_uploaded_image($params['profileImageName'], $params['moveToArchives']);
    }

    //post- form data
    //route=sendEmail
    public function send_email($params) {
        return $this->service->send_email(json_decode($params['email'], true), json_decode($params['user'], true));
    }

    //post
    //route=checkUniqueValidations
    public function check_unique_validations($params) {
        return $this->service->check_unique_validations($params);
    }

    //get
    //route=hasWorkers
    public function has_workers($params) {
        return $this->service->has_workers($params['teamLeaderId']);
    }

    //post
    //route=forgotPassword
    public function forgot_password($params) {
        return $this->service->forgot_password($params['email']);
    }

    //post
    //route=confirmToken
    public function confirm_token($params) {
        return $this->service->confirm_token($params);
    }

    //post
    //route=changePassword
    public function change_password($params) {
        return $this->service->change_password($params);
    }

}
