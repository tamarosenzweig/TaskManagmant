<?php

class project_controller extends controller_singletone {

    //post
    //route=addProject
    public function add_project($params) {
        return $this->service->add_project($params);
    }

    //get
    //route=getProjectById
    public function get_project_by_id($params) {
        return $this->service->get_project_by_id($params['projectId']);
    }

    //get
    //route=getAllProjects
    public function get_all_projects($params) {
        return $this->service->get_all_projects();
    }
    
    //get
    //route=getProjectByTeamLeaderId
    public function get_projects_by_team_leader_id($params) {
        return $this->service->get_projects_by_team_leader_id($params['teamLeaderId']);
    }

    //get
    //route=getProjectsReports
    public function get_projects_reports($params) {
        return $this->service->get_projects_reports();
    }

    //get
    //route=hasProjects
    public function has_projects($params) {
        return $this->service->has_projects($params['teamLeaderId']);
    }

    //post
    //checkUniqeValidations
    public function check_unique_validation($params) {
        return $this->service->check_unique_validation($params);
    }

}
