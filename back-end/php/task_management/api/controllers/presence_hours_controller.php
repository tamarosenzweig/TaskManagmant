<?php

class presence_hours_controller extends controller_singletone {

    //post
    //route=addPresenceHours
    public function add_presence_hours($params) {
        return $this->service->add_presence_hours($params);
    }

    //put
    //route=editPresenceHours
    public function edit_presence_hours($params) {
        return $this->service->edit_presence_hours($params);
    }

    //get
    //route=getPresenceStatusPerWorkers
    public function get_presence_status_per_workers($params) {
        return $this->service->get_presence_status_per_workers($params['teamLeaderId']);
    }

    //get
    //route=getPresenceStatusPerProjects
    public function get_presence_status_per_projects($params) {
        return $this->service->get_presence_status_per_projects($params['workerId']);
    }

    //get
    //route=getPresenceHoursSum
    public function get_presence_hours_sum($params) {
        return $this->service->get_presence_hours_sum($params['projectId'], $params['workerId']);
    }

    //get
    //route=getPresenceHours
    public function get_presence_hours($params) {
        return $this->service->get_presence_hours($params['projectId'], $params['workerId']);
    }

}
