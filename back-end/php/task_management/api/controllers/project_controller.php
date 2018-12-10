<?php

class project_controller extends controller_singletone {

    public function add_project($params) {
        return $this->service->add_project($params);
    }

    public function get_project_by_id($params) {
        return $this->service->get_project_by_id($params['projectId']);
    }

    public function get_all_projects($params) {
        return $this->service->get_all_projects();
    }
    public function get_projects_by_team_leader_id($params) {
        return $this->service->get_projects_by_team_leader_id($params['teamLeaderId']);
    }

    public function get_projects_reports($params) {
        return $this->service->get_projects_reports();
    }

    public function has_projects($params) {
        return $this->service->has_projects($params['teamLeaderId']);
    }

    public function check_unique_validation($params) {
        return $this->service->check_unique_validation($params);
    }

}
