<?php

class customer_service extends base_service {

    public function get_all_customers() {
        $query = "SELECT * FROM task_management.customer ORDER BY customer_name;";
        $customers = db_access:: run_reader($query, function ($model) {
                    return $this->init_customer($model);
                });
        return $customers;
    }

}
