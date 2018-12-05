<?php

$dbPassword = "1234";
$dbUserName = "root";
$dbServer = "localhost";
$dbName = "task_management";

$connection = new mysqli($dbServer, $dbUserName, $dbPassword, $dbName);

//print_r($connection);

if ($connection->connect_errno) {
    //echo "Database Connection Failed. Reason: ".$connection->connect_error;
    exit("Database Connection Failed. Reason: " . $connection->connect_error);
}