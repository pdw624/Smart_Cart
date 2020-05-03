<?php

    $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");


    //포스트 방식으로 데이터 받는다.
     $userName = $_POST["userName"];
     $userMail = $_POST["userMail"];

     $statement = mysqli_prepare($con, "SELECT userID FROM USER WHERE userName = ? and userMail = ?");

    //데이터베이스에 값을 넣는 부분
     mysqli_stmt_bind_param($statement, "ss", $userName, $userMail);
     mysqli_stmt_execute($statement);
     mysqli_stmt_store_result($statement);//결과를 클라이언트에 저장함
     mysqli_stmt_bind_result($statement, $userID);//결과를 $userID에 바인딩함
    //배열 선언 후 
     $response = array();
    //success라는 인덱스에 true값 넣음
     $response["success"] = false; 

     while(mysqli_stmt_fetch($statement)){
       $response["success"] = true; //아이디찾기 일치시 
       $response["userID"] = $userID;   
     }

     echo json_encode($response);


?>