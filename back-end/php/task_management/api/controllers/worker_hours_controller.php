<?php

class worker_hours_controller extends controller_singletone {

    //get
    //route=getAllWorkerHours
    public function get_all_worker_hours($params) {
        return $this->service->get_all_worker_hours($params['workerId']);
    }

    //put
    //route=editWorkerHours
    public function edit_worker_hours($params) {
        return $this->service->edit_worker_hours($params);
    }

    //get
    //route=hasUncompletedHours
    public function has_uncomleted_hours($params) {
        return $this->service->has_uncomleted_hours($params['workerId'], json_decode($params['projectIdList']));
    }

}
