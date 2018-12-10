<?php

abstract class controller_singletone extends singleton {

    protected $service;

    public function init_service() {
        $controller_name = get_called_class();
        $service_name = str_replace('controller', 'service', $controller_name);
        $this->service = $service_name::get_instance();
    }
    public static function get_instance() {
        $controller_instance= parent::get_instance();
        $controller_instance->init_service();
        return $controller_instance;
    }

}
