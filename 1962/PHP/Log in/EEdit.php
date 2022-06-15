<?php   
session_start();
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "quiz";

$conn = new mysqli($servername, $username, $password, $dbname);

$ID = $_GET['ID']; 



if(isset($_POST['update'])){
    
     $question = mysqli_real_escape_string($conn, $_POST["question"]);
     $answer1 = mysqli_real_escape_string($conn, $_POST["answer1"]);
     $answer2 = mysqli_real_escape_string($conn, $_POST["answer2"]);
     $answer3 = mysqli_real_escape_string($conn, $_POST["answer3"]);
     $answer4 = mysqli_real_escape_string($conn, $_POST["answer4"]);
     $soulorder = mysqli_real_escape_string($conn, $_POST["soulorder"]);

    if($question && $answer1 && $answer2 && $answer3 && $answer3 && $answer4 && $soulorder){
        $sql = "
                    UPDATE qstan SET question='$question', answer1 = '$answer1', answer2 = '$answer2', answer3 = '$answer3', answer4 = '$answer4', soulorder = '$soulorder' WHERE ID='$ID';                    
        ";

        if(mysqli_query($GLOBALS['conn'], $sql)){
          $_SESSION["upd"]=" Data Updated Sucsefully";
            
            header('location:test22.php');
        }else{
            echo"error", "Enable to Update Data";
        }

    }else{
        echo"error", "Select Data Using Edit Icon";
    }
}
    if(isset($_POST['cancel'])){
    

    
     header('location:test22.php');
}

?>
<!DOCTYPE html>  
 <html> 
 

 <head>  
 
      <meta charset="utf-8">  
      
      <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
      <link rel="stylesheet" type="text/css" href="style.css">  
      <!-- Font Awsome -->
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" integrity="sha512-KfkfwYDsLkIlwQp6LFnl8zNdLGxu9YAA1QvwINks4PhcElQSvqcyVLLD9aMhXd13uQjoXtEKNosOWaZqXgel0g==" crossorigin="anonymous" referrerpolicy="no-referrer" />
 </head>  
 <body> 
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script> <header><p style="color: black;">h</p></header>  
<nav class="navbar navbar-dark bg-dark justify-content-center fs-3 mb-5"><h1 style="color:white ; ">Admin Space</h1> </nav>
<div class ="container">
    <div class="text-center mb-4">
        <h3>Edit Quizz Question And Answers<h3>
            <p class="text-muted">Click Update After Any Information Changing </p>
            <div class="container d-flex justify-content-center">
                <form action="" method="POST" style="width:50vw; min-width:500px;">

                <?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "quizz1";

$conn1 = new mysqli($servername, $username, $password, $dbname);

$ID = $_GET['ID'];  

$sql1 = "SELECT * FROM qstan WHERE ID = '$ID' LIMIT 1";
	
	// Execute the query and store the result set
     
	$result1 = mysqli_query($conn1, $sql1);
    while($row=mysqli_fetch_assoc($result1)){
        ?>


            <div class="row mb-3">
                     <div class="col">
                        <label class="form-label d-flex justify-content-left">Question:</label>
                        <input type="text" class="form-control" name="question" style="word-break: break-all;" value="<?php echo $row['question']?>">
                   </div>
            </div>
            <div class="row mb-3">
                     <div class="col">
                        <label class="form-label d-flex justify-content-left">Answer 1:</label>
                        <input type="text" class="form-control" name="answer1" value="<?php echo $row['answer1']?>">
                   </div>
                   <div class="col">
                        <label class="form-label d-flex justify-content-left">Anwser 2:</label>
                        <input type="text" class="form-control" name="answer2" value="<?php echo $row['answer2']?>">
                   </div>
            </div>
            <div class="row mb-3">
                     <div class="col">
                        <label class="form-label d-flex justify-content-left">Answer 3:</label>
                        <input type="text" class="form-control" name="answer3" value="<?php echo $row['answer3']?>">
                   </div>
                   <div class="col">
                        <label class="form-label d-flex justify-content-left">Answer 4:</label>
                        <input type="text" class="form-control" name="answer4" value="<?php echo $row['answer4']?>">
                   </div>
                   
            </div>
            <div class="col" style="width:15vw; min-width:50px;">
                        <label class="form-label d-flex justify-content-left">Soul-Order:</label>
                        <input type="text" class="form-control" name="soulorder" required size="1"
           pattern="[0-4]{1}" title="1 number between 0 est 4" value="<?php echo $row['soulorder']?>">
                   </div>
                   <?php
    }
    ?>   
   
            <div>
<button  type="submit" class="btn btn-success" name="update" > Update </button>
<button  href="http://localhost/unityquiz/test22.php" type="submit" class="btn btn-danger" name="cancel" >Cancel </button>
            </div>
            
            </form>
    </div>
    </div>
   
 </body>  
 </html>  