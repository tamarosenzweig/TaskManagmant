<?php

//$statementObj->close();
//$connection->close();

class db_access {

    static function run_non_query($query) {
        global $connection;
        return $connection->query($query);
//      return $connection->affected_rows;
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
        return $resultObj;
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
