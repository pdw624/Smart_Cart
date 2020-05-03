<?php
 $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");

 $userName = "jhj";
 $userMail = "oioow@naver.com";

 $statement = mysqli_prepare($con, "SELECT userID FROM USER WHERE userName = 'jhj' AND userMail = 'oioow@naver.com');
 $response = array();
 while($row = mysqli_fetch_array($result)){
   
 array_push($response,array("userID"=>$row[0]);

 }
 
 echo json_encode(array("response" =>$response));

 mysqli_close($con);

?>