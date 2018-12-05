<?php

class cusomer_controller {

    var $customer_service;

    function __construct() {
        $this->customer_service = new customer_service();
    }
    function get_all_customers() {
        return $this->customer_service->get_all_customers();
    }

}
