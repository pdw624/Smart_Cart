<?php
 $con = mysqli_connect("localhost", "root", "apmsetup", "smartcart");

 $barcode = $_POST["orderList"];
 $pieces = explode(" ",$barcode);
 
 $statement = mysqli_prepare($con, "insert into `order` values('$pieces[0]','$pieces[1]','$pieces[2]','$pieces[3]')");
 $stroke = mysqli_query($con,"update product set quantity = quantity-1 where name='$pieces[1]'"); 
 //mysqli_stmt_bind_param($statement, "ssis", $pieces[0], $pieces[1], $pieces[2], $pieces[3]);
 
mysqli_stmt_execute($stroke);
 mysqli_stmt_execute($statement);
 $response["order"]=$pieces[0];
 $response["product"]=$pieces[1];
 $response["price"]=$pieces[2];
 $response["buydate"]=$pieces[3];
 echo json_encode($response);
 //접속을 종료합니다. 
 mysqli_close($con);
?>