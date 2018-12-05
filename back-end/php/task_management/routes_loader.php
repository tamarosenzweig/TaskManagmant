<?php

class routes_loader {

    var $methods;
    var $user_controller;
    var $project_controller;
    var $customer_controller;
    var $department_controller;
    var $worker_hours_controller;
    var $presence_hours_controller;

    public function __construct() {
        $this->user_controller = new user_controller();
        $this->project_controller = new project_controller();
        $this->customer_controller = new cusomer_controller();
        $this->department_controller = new department_controller();
        $this->worker_hours_controller = new worker_hours_controllere();
        $this->presence_hours_controller = new presence_hours_controller();

        $this->methods = array(
            'customer' => $this->get_customers_methods(),
            'user' => $this->get_users_methods(),
            'project' => $this->get_projects_methods(),
            'department' => $this->get_departments_methods(),
            'workerHours' => $this->get_worker_hours_methods(),
            'presenceHours' => $this->get_presence_hours_methods()
        );
    }

    function invoke($controller_name, $method_name, $params) {
        if (array_key_exists($controller_name, $this->methods) && array_key_exists($method_name, $this->methods[$controller_name])) {
            $data = $this->methods[$controller_name][$method_name]($params);
            echo json_encode($data);
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
                return $this->project_controller->has_projects($params['team_leader_id']);
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
                return $this->worker_hours_controller->getAllWorkerHours($params['workerId']);
            }
        );
    }

    function get_presence_hours_methods() {
        return array(
            'GetPresenceStatusPerWorkers' => function ($params) {

                return $this->$presence_hours_controller->get_presence_status_per_workers($params['teamLeaderId']);
            }
        );
    }

}
