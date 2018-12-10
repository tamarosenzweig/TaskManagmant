<?php

abstract class singleton {

    private static $instance_array = array();

    private function __construct() {
        
    }
    public static function get_instance() {

        $sub_class_name = get_called_class();

        if (!isset(self::$instance_array[$sub_class_name])) {

            self::$instance_array[$sub_class_name] = new $sub_class_name();
        }
        $object_instance = self::$instance_array[$sub_class_name];

        return $object_instance;
    }

    final private function __clone() {
        
    }

}
