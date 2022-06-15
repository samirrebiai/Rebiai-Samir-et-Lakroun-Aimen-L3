<?php

use LDAP\Result;

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "quiz";

$conn = new mysqli($servername, $username, $password, $dbname);

$sql = "SELECT answer1 FROM qstan  ";


if ($result = $conn -> query($sql)) {
 
  $qwst = array();
  $i = 0;
 while ($row = $result -> fetch_row()) {
  
  
  $qwst[$i]=$row[0];
 
  $i++;
  
  
  }
  $arrayLength=count($qwst);
  
  for($i=0;$i<$arrayLength;$i++){

echo  $qwst[$i];
echo  "\t";
}
 
}

?>