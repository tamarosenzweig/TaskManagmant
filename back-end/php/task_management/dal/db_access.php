<?php

//$statementObj->close();
//$connection->close();

class db_access {

    static function get_my_sql_type($query) {
        $str = trim($query);
        return strtoupper(substr($str, 0, strpos($str, ' ')));
    }

    static function run_non_query($query) {
        global $connection;
        $connection->query($query);

        if (self::get_my_sql_type($query) == 'INSERT') {
            if ($connection->affected_rows > 0) {
                return $connection->insert_id;
            }
            return null;
        }
        return $connection->affected_rows;
    }

    static function run_reader($query, $init_model) {

        global $connection;

        $resultObj = $connection->query($query);


        /* create one master array of the records */
        $list = array();

        while ($singleRowFromQuery = $resultObj->fetch_array(MYSQLI_ASSOC)) {
            $list[] = $init_model($singleRowFromQuery);
        }
        return $list;
    }

    static function run_scalar($query) {
        global $connection;
        $resultObj = $connection->query($query);
        return array_values(get_object_vars($resultObj->fetch_object()))[0];
    }

    static function run_transaction($queries) {
        global $connection;
        $connection->autocommit(FALSE);
        $error = 0;

        foreach ($queries as $query) {
            $connection->query($query) ? NULL : $error = 1;
        }
        if ($error == 0) {
            $connection->commit();
            return true;
        } else {
            $connection->rollback();
            return false;
        }

        // $connection->close();
    }

}
