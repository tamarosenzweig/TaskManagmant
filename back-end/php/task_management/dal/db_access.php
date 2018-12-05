<?php

//$statementObj->close();
//$connection->close();

class db_access {

    static function run_non_query($query) {
        global $connection;
        $connection->query($query);
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
        return $resultObj;
    }

//    static function run_transaction() {
//        $database = new mysqli("sever", "user", "key", "database");
//        $database->autocommit(FALSE);
//        $error = 0;
//
////asumming we want to delete a users infomation from two table
//        $database->query("delete from `pay` where `user`=1 ") ? NULL : $error = 1;
//        $database->query("delete from `users` where `id`=1 ") ? NULL : $error = 1;
//
//        if ($error = 0) {
//            $database->commit();
//        } else {
//            $database->rollback();
//        }
//        $database->close();
//    }

}
