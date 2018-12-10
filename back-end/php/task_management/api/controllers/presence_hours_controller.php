<?php

class presence_hours_controller extends controller_singletone {

    public function add_presence_hours($params) {
        return $this->service->add_presence_hours($params);
    }

    public function edit_presence_hours($params) {
        return $this->service->edit_presence_hours($params);
    }

    public function get_presence_status_per_workers($params) {
        return $this->service->get_presence_status_per_workers($params['teamLeaderId']);
    }

    public function get_presence_status_per_projects($params) {
        return $this->service->get_presence_status_per_projects($params['workerId']);
    }

    public function get_presence_hours_sum($params) {
        return $this->service->get_presence_hours_sum($params['projectId'], $params['workerId']);
    }

    public function get_presence_hours($params) {
        return $this->service->get_presence_hours($params['projectId'], $params['workerId']);
    }

}
