<?php

class user_controller {

    var $user_service;

    function __construct() {
        $this->user_service = new user_service();
    }

    //post
    function login($login) {
        return $this->user_service->login($login);
    }

    //get
    function get_all_users($manager_id) {
        return $this->user_service->get_all_users($manager_id);
    }

    //get
    function get_all_team_users($team_leader_id) {
        return $this->user_service->get_all_team_users($team_leader_id);
    }

    //get
    function get_all_team_leaders($manager_id) {
        return $this->user_service->get_all_team_leaders($manager_id);
    }

    //get
    function get_user_by_id($user_id) {
        return $this->user_service->get_user_by_id($user_id);
    }

    //post
    function add_user($user) {
        return $this->user_service->add_user($user);
    }

    //put
    function edit_user($user) {
        return $this->user_service->edit_user($user);
    }

    //put
    function delete_user($user_id) {
        return $this->user_service->delete_user($user_id);
    }

    //get
    function has_workes($team_leader_id) {
        return $this->user_service->has_workes($team_leader_id);
    }

    //post- form data
    function send_email($email, $user) {
        return $this->user_service->send_email($email, $user);
    }

    function check_unique_validations($user) {
        return $this->user_service->check_unique_validations($user);
    }

    function upload_image_profile($file) {
        return $this->user_service->upload_image_profile($file);
    }

    function remove_uploaded_image($profile_image_name, $move_to_archives) {
        return $this->user_service->remove_uploaded_image($profile_image_name, $move_to_archives);
    }

    function get_user_by_email($email) {
        return $this->user_service->get_user_by_email($email);
    }

    function forgot_password($email) {
        return $this->user_service->forgot_password($email);
    }
    function confirm_token($change_password){
        return $this->user_service->confirm_token($change_password);
    }
            function change_password($user){
        return $this->user_service->change_password($user);
    }
}
