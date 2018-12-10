
<?php

require './includes.php';

//------------------------------------------ init headers -----------------------------------------

header('Access-Control-Allow-Origin: *');
header('Content-type: application/json');
header('Access-Control-Allow-Headers: Origin, X-Requested-With,Content-Type, Accept');
header('Access-Control-Allow-Methods: GET, POST, PUT');

$routes_loader = new routes_loader();

//------------------------- init controller-name and method-name from url -------------------------

$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
$path = parse_url($link, PHP_URL_PATH);
$exploded_path = explode('/', $path);
$controller_name = $exploded_path[count($exploded_path) - 2];
$method_name = $exploded_path[count($exploded_path) - 1];

//------------------------------------------ init params ------------------------------------------

$type = $_SERVER['REQUEST_METHOD'];
$params;
if ($type == 'GET') {
    $params = $_GET;
}
//if type is different from get like:post/put...
else {
    //get post object
    $json = file_get_contents('php://input');
    $post_object = json_decode($json, true);

    //merge post object and url data(url data exist in $_GET)
    $params = isset($post_object) ? array_merge($post_object, $_GET) : $_GET;

    //merge form data to params(form data exist in $_POST)
    $params = array_merge($params, $_POST);
    $params['files'] = $_FILES;
}

//------------------------------------------ invoke method ------------------------------------------
    echo $routes_loader->invoke($controller_name, $method_name, $params);
die();




