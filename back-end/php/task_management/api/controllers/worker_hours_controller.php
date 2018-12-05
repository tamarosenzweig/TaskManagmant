<?php

class worker_hours_controllere {
    
    var $worker_hours_service;
    
    public function __construct() {
        $this->worker_hours_service=new worker_hours_service;
    }
    
    function get_all_worker_hours($worker_id){
        return $this->worker_hours_service->get_all_worker_hours($worker_id);
    }
    function edit_worker_hours($worker_hours){
        return $this->worker_hours_service->edit_worker_hours($worker_hours);
    }
    function has_uncomleted_hours($worker_id, $project_id_list){
        return $this->worker_hours_service->has_uncomleted_hours($worker_id, $project_id_list);
    }

}
