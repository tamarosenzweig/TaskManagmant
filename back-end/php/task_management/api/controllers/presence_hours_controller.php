<?php

class presence_hours_controller {

    var $presence_hours_service;

    function __construct() {
        $this->presence_hours_service = new presence_hours_service();
    }

    function add_presence_hours($new_presence_hours) {
        return $this->presence_hours_service->add_presence_hours($new_presence_hours);
    }

    function edit_presence_hours($presence_hours) {
        return $this->presence_hours_service->edit_presence_hours($presence_hours);
    }

    function get_presence_status_per_workers($team_leader_id) {
        return $this->presence_hours_service->get_presence_status_per_workers($team_leader_id);
    }

    function get_presence_status_per_projects($worker_id) {
        return $this->presence_hours_service->get_presence_status_per_projects($worker_id);
    }

    function get_presence_hours_sum($project_id, $worker_id) {
        return $this->presence_hours_service->get_presence_hours_sum($project_id, $worker_id);
    }

    function get_presence_hours($project_id, $worker_id) {
        return $this->presence_hours_service->get_presence_hours( $worker_id,$project_id);
    }

}
