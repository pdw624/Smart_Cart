<?php

 $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");
  $result = mysqli_query($con, "SELECT * FROM `order` where orderID in ('".$_POST["orderID"]."') and buydate in ('".$_POST["date"]."')");
 $response = array();

 while($row = mysqli_fetch_array($result)){
   
 array_push($response,array("product"=>$row[1],"price"=>$row[2],"buydate"=>$row[3]));

 }
 
 echo json_encode(array("response" =>$response));

 mysqli_close($con);

?>
