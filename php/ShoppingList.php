<?php

 $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");
 $barcode = $_POST["barcode"];
 $result = mysqli_query($con, "SELECT * FROM product WHERE barcode = '$barcode';");
 $response = array();

 while($row = mysqli_fetch_array($result)){
	
 array_push($response,array("name"=>$row[0],"price"=>$row[1]));

 }
 
 echo json_encode(array("response" =>$response));
 mysqli_close($con);

?>