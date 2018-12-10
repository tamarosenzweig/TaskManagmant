<?php

class customer_controller extends controller_singletone {

    public function get_all_customers($params) {
        return $this->service->get_all_customers();
    }

}
