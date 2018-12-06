<?php

class project_controller {

    var $project_service;

    function __construct() {
        $this->project_service = new project_service();
    }

    function add_project($new_project) {
        return $this->project_service->add_project($new_project);
    }

    function get_all_projects() {
        return $this->project_service->get_all_projects();
    }

    function get_project_by_team_leader_id($team_leader_id) {
        return $this->project_service->get_project_by_team_leader_id($team_leader_id);
    }

    function get_projects_reports() {
        return $this->project_service->get_projects_reports();
    }

    function get_project_by_id($project_id) {
        return $this->project_service->get_project_by_id($project_id);
    }

    function check_unique_validation($project) {
        return $this->project_service->check_unique_validation($project);
       // return null;
    }

    function has_projects($team_leader_id) {
        return $this->project_service->has_projects($team_leader_id);
    }

}
