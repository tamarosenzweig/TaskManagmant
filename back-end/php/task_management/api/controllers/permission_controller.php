<?php

class permission_controller extends controller_singletone {

    //post
    //route=addPermission
    public function add_permission($params) {
        $permission_id = $this->service->add_permission($params);
        return $permission_id;
    }

    //post
    //route=deletePermission
    public function delete_permission($params) {
        $deleted = $this->service->delete_permission($params['permissionId']);
        return $deleted;
    }
    

}
