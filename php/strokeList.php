<?php

 $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");
 $result = mysqli_query($con, "SELECT * FROM PRODUCT;");

 $response = array();

 while($row = mysqli_fetch_array($result)){
	
 array_push($response,array("strokeName"=>$row[0],"strokePrice"=>$row[1],"strokeQuantity"=>$row[2]));

 }
 
 echo json_encode(array("response" =>$response));
 mysqli_close($con);

?>