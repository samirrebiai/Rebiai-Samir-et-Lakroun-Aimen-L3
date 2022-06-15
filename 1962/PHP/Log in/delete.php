<?php 
session_start();
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "quiz";

$conn = new mysqli($servername, $username, $password, $dbname);

      $ID = $_GET['ID'];  
      $query = "DELETE FROM qstan WHERE ID = '$ID'";  
      $run1 = mysqli_query($conn,$query);  
      if ($run1) {  
          $_SESSION["dele"]=" Data Dleted Sucsefully";
            
           header('location:test22.php');  
      }else{  
           echo "Error: ".mysqli_error($conn);  
      }  
 
 ?>  