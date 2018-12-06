<?php

class base_service {

    function init_user($user) {
        $new_user = array();
        $new_user['userId'] = $user['user_id'];
        $new_user['userName'] = $user['user_name'];
        $new_user['email'] = $user['email'];
        $new_user['password'] = $user['password'];
        $new_user['profileImageName'] = $user['profile_image_name'];
        $new_user['departmentId'] = $user['department_id'];
        $new_user['teamLeaderId'] = $user['team_leader_id'];
        $new_user['managerId'] = $user['manager_id'];
        $new_user['isActive'] = $user['is_active'];
        if (array_key_exists('department_name', $user)) {
            $new_user['department'] = array();
            $new_user['department']['departmentName'] = $user['department_name'];
        }
        if (array_key_exists('team_leader_name', $user)) {
            $new_user['teamLeader'] = array();
            $new_user['teamLeader']['userName'] = $user['team_leader_name'];
        }
        return $new_user;
    }

    function init_project($project) {
        $new_project = array();
        $new_project['projectId'] = $project['project_id'];
        $new_project['projectId'] = $project['project_id'];
        $new_project['projectId'] = $project['project_id'];
        $new_project['projectName'] = $project['project_name'];
        $new_project['managerId'] = $project['manager_id'];
        $new_project['customerId'] = $project['customer_id'];
        $new_project['teamLeaderId'] = $project['team_leader_id'];
        $new_project['totalHours'] = $project['total_hours'];
        $new_project['startDate'] = $project['start_date'];
        $new_project['endDate'] = $project['end_date'];
        $new_project['isComplete'] = $project['is_complete'];
        if (array_key_exists('customer_name', $project)) {
            $new_project['customer'] = array();
            $new_project['customer']['customerName'] = $project['customer_name'];
        }
        if (array_key_exists('user_name', $project) && array_key_exists('email', $project)) {
            $new_project['teamLeader'] = array();
            $new_project['teamLeader']['userName'] = $project['user_name'];
            $new_project['teamLeader']['email'] = $project['email'];
        }
        return $new_project;
    }

    function init_customer($customer) {
        $new_customer = array();
        $new_customer['customerId'] = $customer['customer_id'];
        $new_customer['customerName'] = $customer['customer_name'];
        return $new_customer;
    }

    function init_department($department) {
        $new_department = array();
        $new_department['departmentId'] = $department['department_id'];
        $new_department['departmentName'] = $department['department_name'];
        return $new_department;
    }

    function init_worker_hours($worker_hours) {
        $new_worker_hours = array();
        $new_worker_hours['workerHoursId'] = $worker_hours['worker_hours_id'];
        $new_worker_hours['projectId'] = $worker_hours['project_id'];
        $new_worker_hours['workerId'] = $worker_hours['worker_id'];
        $new_worker_hours['numHours'] = $worker_hours['num_hours'];
        $new_worker_hours['isComplete'] = $worker_hours['is_complete'];
        $new_worker_hours['project'] = array();
        $new_worker_hours['project']['projectName'] = $worker_hours['project_name'];
        $new_worker_hours['worker'] = array();
        $new_worker_hours['worker']['userName'] = $worker_hours['user_name'];
        $new_worker_hours['worker']['email'] = $worker_hours['email'];
        $new_worker_hours['worker']['department'] = array();
        $new_worker_hours['worker']['department']['departmentName'] = $worker_hours['department_name'];
        return $new_worker_hours;
    }

    function init_department_hours($department_hours) {
        $new_department_hours = array();
        $new_department_hours['departmentHoursId'] = $department_hours['department_hours_id'];
        $new_department_hours['projectId'] = $department_hours['project_id'];
        $new_department_hours['departmentId'] = $department_hours['department_id'];
        $new_department_hours['numHours'] = $department_hours['num_hours'];
        $new_department_hours['department'] = array();
        $new_department_hours['department']['departmentName'] = $department_hours['department_name'];
        return $new_department_hours;
    }

    function init_permission($permission) {
        $new_permission = array();
        $new_permission['permissionId'] = $permission['permission_id'];
        $new_permission['workerId'] = $permission['worker_id'];
        $new_permission['projectId'] = $permission['project_id'];
        $new_permission['isActive'] = $permission['is_active'];
        $new_permission['worker'] = array();
        $new_permission['worker']['userName'] = $permission['user_name'];
        $new_permission['project'] = array();
        $new_permission['project']['projectName'] = $permission['project_name'];
        return $new_permission;
    }

    function init_presence_hours($presence_hours) {
        $new_presence_hours = array();
        $new_presence_hours['presenceHoursId'] = $presence_hours['presence_hours_id'];
        $new_presence_hours['workerId'] = $presence_hours['worker_id'];
        $new_presence_hours['projectId'] = $presence_hours['project_id'];
        $new_presence_hours['startHour'] = $presence_hours['start_hour'];
        $new_presence_hours['endHour'] = $presence_hours['end_hour'];
        $new_presence_hours['worker'] = array();
        $new_presence_hours['worker'] ['userName'] = $presence_hours['user_name'];
        return $new_presence_hours;
    }

    function format_date($date, $format = 'Y-m-d') {
        $format_date = date($format, strtotime($date));
        return "'$format_date'";
    }

    function get_value_or_null($array, $key) {
        return array_key_exists($key, $array) && isset($array[$key]) ? "'{$array[$key]}'" : 'null';
    }

}
