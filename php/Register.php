<?php 
    $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");
    mysqli_query($con,'SET userName utf8');

    $userID = $_POST["userID"];
    $userPassword = $_POST["userPassword"];
    $userName = $_POST["userName"];
    $userMail = $_POST["userMail"];
    $userPhone = $_POST["userPhone"];

    $statement = mysqli_prepare($con, "INSERT INTO user VALUES (?,?,?,?,?)");
    mysqli_stmt_bind_param($statement, "sssss", $userID, $userPassword, $userName, $userMail, $userPhone);
    mysqli_stmt_execute($statement);


    $response = array();
    $response["success"] = true;
 
   
    echo json_encode($response);



?>