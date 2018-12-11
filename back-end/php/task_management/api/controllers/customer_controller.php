<?php

class customer_controller extends controller_singletone {

    //get
    //route=getAllCustomers
    public function get_all_customers($params) {
        return $this->service->get_all_customers();
    }

}
