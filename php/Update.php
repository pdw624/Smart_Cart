<?php

    $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");
    mysqli_query($con, 'SET NAMES utf8');

    $userID = $_POST["userID"];
    $userName = $_POST["userName"];
    $userPassword = $_POST["userNewpassword"];
    $userPhone = $_POST["userPhone"];
    $userMail = $_POST["userMail"];
    
    $statement = mysqli_prepare($con, "UPDATE user SET userName = '$userName', userPassword = '$userPassword', userPhone = '$userPhone', userMail = '$userMail' where userID = '$userID'");

//    mysqli_stmt_bind_param($statement, "ssss", $userName, $userPassword, $userMail, $userPhone);
    

    mysqli_stmt_execute($statement);
    $response["success"] = true;
    $response["userPassword"] = $userPassword;
    $response["userNewpassword"] = $userNewpassword;
    $response["userNewpasswordcheck"] = $userNewpasswordcheck;


    echo json_encode($response);
    
    //접속을 종료합니다. 
    mysqli_close($con);


?>