<?php

class routes_loader {

    var $methods;
    var $user_controller;
    var $project_controller;
    var $customer_controller;
    var $department_controller;
    var $worker_hours_controller;
    var $presence_hours_controller;
    var $permission_controller;

    public function __construct() {
        $this->user_controller = new user_controller();
        $this->project_controller = new project_controller();
        $this->customer_controller = new cusomer_controller();
        $this->department_controller = new department_controller();
        $this->worker_hours_controller = new worker_hours_controllere();
        $this->presence_hours_controller = new presence_hours_controller();
        $this->permission_controller = new permission_controller();
        $this->methods = array(
            'customer' => $this->get_customers_methods(),
            'user' => $this->get_users_methods(),
            'project' => $this->get_projects_methods(),
            'department' => $this->get_departments_methods(),
            'workerHours' => $this->get_worker_hours_methods(),
            'presenceHours' => $this->get_presence_hours_methods(),
            'permission' => $this->get_permission_methods()
        );
    }

    function invoke($controller_name, $method_name, $params) {
        if (array_key_exists($controller_name, $this->methods) && array_key_exists($method_name, $this->methods[$controller_name])) {
            $data = $this->methods[$controller_name][$method_name]($params);
            echo json_encode($data, JSON_NUMERIC_CHECK);
        } else {
            var_dump(http_response_code(404));
            die("unknown url");
        }
    }

    function get_customers_methods() {
        return array(
            'getAllCustomers' => function ($params) {
                return $this->customer_controller->get_all_customers();
            }
        );
    }

    function get_users_methods() {
        return array(
            'login' => function ($params) {
                return $this->user_controller->login($params);
            },
            'getAllUsers' => function ($params) {

                return $this->user_controller->get_all_users($params['managerId']);
            },
            'getAllTeamUsers' => function ($params) {
                return $this->user_controller->get_all_team_users($params['teamLeaderId']);
            },
            'getAllTeamLeaders' => function ($params) {
                return $this->user_controller->get_all_team_leaders($params['managerId']);
            },
            'getUserById' => function ($params) {
                return $this->user_controller->get_user_by_id($params['userId']);
            },
            'addUser' => function ($params) {
                return $this->user_controller->add_user($params);
            },
            'editUser' => function ($params) {
                return $this->user_controller->edit_user($params);
            },
            'deleteUser' => function ($params) {
                return $this->user_controller->delete_user($params['userId']);
            },
            'checkUniqueValidations' => function ($params) {
                return $this->user_controller->check_unique_validations($params);
            },
            'uploadImageProfile' => function ($params) {
                $file = array_values($params['files'])[0];
                return $this->user_controller->upload_image_profile($file);
            },
            'removeUploadedImage' => function ($params) {
                return $this->user_controller->remove_uploaded_image($params['profileImageName'], $params['moveToArchives']);
            },
            'getUserByEmail' => function ($params) {
                return $this->user_controller->get_user_by_email($params['email']);
            },
            'hasWorkers' => function ($params) {
                return $this->user_controller->has_workes($params['teamLeaderId']);
            },
            'forgotPassword' => function ($params) {
                return $this->user_controller->forgot_password($params['email']);
            },
            'confirmToken' => function ($params) {
                return $this->user_controller->confirm_token($params);
            },
            'changePassword' => function ($params) {
                return $this->user_controller->change_password($params);
            },
            'sendEmail' => function ($params) {
                return $this->user_controller->send_email(json_decode($params['email'], true), json_decode($params['user'], true));
            }
        );
    }

    function get_projects_methods() {
        return array(
            'addProject' => function ($params) {
                return $this->project_controller->add_project($params);
            },
            'getAllProjects' => function ($params) {

                return $this->project_controller->get_all_projects();
            },
            'getProjectsByTeamLeaderId' => function ($params) {
                return $this->project_controller->get_project_by_team_leader_id($params['teamLeaderId']);
            },
            'getProjectsReports' => function ($params) {
                return $this->project_controller->get_projects_reports();
            },
            'getProjectById' => function ($params) {
                return $this->project_controller->get_project_by_id($params['projectId']);
            },
            'checkUniqueValidation' => function ($params) {
                return $this->project_controller->check_unique_validation($params);
            },
            'hasProjects' => function ($params) {
                return $this->project_controller->has_projects($params['teamLeaderId']);
            }
        );
    }

    function get_departments_methods() {
        return array(
            'getAllDepartments' => function ($params) {

                return $this->department_controller->get_all_departments();
            }
        );
    }

    function get_worker_hours_methods() {
        return array(
            'getAllWorkerHours' => function ($params) {
                return $this->worker_hours_controller->get_all_worker_hours($params['workerId']);
            },
            'hasUncomletedHours' => function ($params) {
                return $this->worker_hours_controller->has_uncomleted_hours($params['workerId'], json_decode($params['projectIdList']));
            },
            'editWorkerHours' => function ($params) {
                $this->worker_hours_controller->edit_worker_hours($params);
            }
        );
    }

    function get_presence_hours_methods() {
        return array(
            'addPresenceHours' => function ($params) {

                return $this->presence_hours_controller->add_presence_hours($params);
            },
            'editPresenceHours' => function ($params) {

                return $this->presence_hours_controller->edit_presence_hours($params);
            },
            'getPresenceStatusPerProjects' => function ($params) {

                return $this->presence_hours_controller->get_presence_status_per_projects($params['workerId']);
            },
            'getPresenceStatusPerWorkers' => function ($params) {

                return $this->presence_hours_controller->get_presence_status_per_workers($params['teamLeaderId']);
            },
            'getPresenceHoursSum' => function ($params) {

                return $this->presence_hours_controller->get_presence_hours_sum($params['projectId'], $params['workerId']);
            },
            'getPresenceHours' => function ($params) {

                return $this->presence_hours_controller->get_presence_hours($params['projectId'], $params['workerId']);
            },
        );
    }

    function get_permission_methods() {
        return array(
            'addPemission' => function ($params) {

                return $this->permission_controller->add_pemission($params);
            },
            'deletePemission' => function($params) {
                return $this->permission_controller->delete_pemission($params['permissionId']);
            }
        );
    }

}
