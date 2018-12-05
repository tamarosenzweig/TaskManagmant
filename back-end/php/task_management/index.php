
<?php

require './includes.php';

header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Credentials", "true");
header('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE,PATCH,OPTIONS');
header("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers");
header('Content-type: application/json');

$routes_loader = new routes_loader();

$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
$path = parse_url($link, PHP_URL_PATH);
$exploded_path = explode('/', $path);
$controller_name = $exploded_path[count($exploded_path) - 2];
$method_name = $exploded_path[count($exploded_path) - 1];
$type = $_SERVER['REQUEST_METHOD'];
$params;
if ($type == 'GET') {
    $params = $_GET;
} else {
    $json = file_get_contents('php://input');
    $params = json_decode($json, true);
}

echo $routes_loader->invoke($controller_name, $method_name, $params);

die();




