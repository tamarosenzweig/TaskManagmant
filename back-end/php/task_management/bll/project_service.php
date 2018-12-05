<?php

class project_service extends base_service {

    function get_projects_query() {
        $query = "SELECT * FROM task_management.project";
        return $query;
    }

    function get_projects($query) {
        //todo:edit details
        $projects = db_access:: run_reader($query, function ($model) {
                    return $this->init_project($model);
                });
        return $projects;
    }

    function get_all_projects() {
        $query = $this->get_projects_query();
        return $this->get_projects($query);
    }

    function get_project_by_id($project_id) {
        $query = $this->get_projects_query() . " WHERE project_id=$project_id;";
        return $this->get_projects($query);
    }

    function get_project_by_team_leader_id($team_leader_id) {
        $query = $this->get_projects_query() . " WHERE p.team_leader_id={teamLeaderId};";
        return $this->get_projects($query);
    }

    function get_projects_reports() {
        
    }
    function update_project_status(){
        
    }
    function get_projects_in_working_by_team_leader_id($team_leader_id){
        
    }
}
