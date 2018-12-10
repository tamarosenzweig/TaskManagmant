<?php

class worker_hours_controller extends controller_singletone {

    public function get_all_worker_hours($params) {
        return $this->service->get_all_worker_hours($params['workerId']);
    }

    public function edit_worker_hours($params) {
        return $this->service->edit_worker_hours($params);
    }

    public function has_uncomleted_hours($params) {
        return $this->service->has_uncomleted_hours($params['workerId'], json_decode($params['projectIdList']));
    }

}
