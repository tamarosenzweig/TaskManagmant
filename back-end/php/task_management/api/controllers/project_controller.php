<?php

class project_controller {

    var $project_service;

    function __construct() {
        $this->project_service = new project_service();
    }

    function get_all_projects() {
        return $this->project_service->get_all_projects();
    }

    function get_project_by_id($project_id) {
        return $this->project_service->get_project_by_id($project_id);
    }

    function get_project_by_team_leader_id($team_leader_id) {
        return $this->project_service->get_project_by_team_leader_id($team_leader_id);
    }

    function get_projects_reports() {
        return $this->project_service->get_projects_reports();
    }

}
