<?php

class permission_controller {

    var $permission_service;

    function __construct() {
        $this->permission_service = new permission_service();
    }
  function add_pemission($permission) {
        $permission_id= $this->permission_service->add_pemission($permission);
        return $permission_id;
    }
 
    function delete_pemission($permission_id) {
       $deleted= $this->permission_service->delete_pemission($permission_id) ;
       return $deleted;
    }
             
}