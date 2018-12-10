<?php

class routes_loader {

    private $user_controller;
    private $project_controller;
    private $customer_controller;
    private $department_controller;
    private $worker_hours_controller;
    private $presence_hours_controller;
    private $permission_controller;

    public function __construct() {
        $this->user_controller = user_controller::get_instance();
        $this->project_controller = project_controller::get_instance();
        $this->customer_controller = customer_controller::get_instance();
        $this->department_controller = department_controller::get_instance();
        $this->worker_hours_controller =worker_hours_controller::get_instance();
        $this->presence_hours_controller = presence_hours_controller::get_instance();
        $this->permission_controller = permission_controller::get_instance();
    }

    public function invoke($controller, $method, $params) {
        $controller_name = $this->camel_case_to_underscore($controller) . '_controller';
        $method_name = $this->camel_case_to_underscore($method);
        $data = $this->$controller_name->$method_name($params);
        echo json_encode($data,JSON_NUMERIC_CHECK);
        die();
    }
    private function camel_case_to_underscore($string) {
        preg_match_all('!([A-Z][A-Z0-9]*(?=$|[A-Z][a-z0-9])|[A-Za-z][a-z0-9]+)!', $string, $matches);
        $ret = $matches[0];
        foreach ($ret as &$match) {
            $match = $match == strtoupper($match) ? strtolower($match) : lcfirst($match);
        }
        return implode('_', $ret);
    }
}
