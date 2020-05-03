<?php

    $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");
    $userID = $_POST["userID"];
    $result = mysqli_query($con,"SELECT * FROM user WHERE userID = '$userID';");
    $response = array();

    while($row = mysqli_fetch_array($result)){

    array_push($response,array("userName"=>$row[2],"userMail"=>$row[3],"userPhone"=>$row[4]));

     }
     echo json_encode(array("response" =>$response));

     mysqli_close($con);

?>