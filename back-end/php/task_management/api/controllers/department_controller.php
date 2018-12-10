<?php

class department_controller extends controller_singletone {

    public function get_all_departments($params) {
        return $this->service->get_all_departments();
    }

}
