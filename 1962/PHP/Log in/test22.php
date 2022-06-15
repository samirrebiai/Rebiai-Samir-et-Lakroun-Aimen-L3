<?php
session_start();
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "quiz";

$conn = new mysqli($servername, $username, $password, $dbname);



 
if(isset($_POST["submit"])){
    $question = mysqli_real_escape_string($conn, $_POST["question"]);
    $answer1 = mysqli_real_escape_string($conn, $_POST["answer1"]);
    $answer2 = mysqli_real_escape_string($conn, $_POST["answer2"]);
    $answer3 = mysqli_real_escape_string($conn, $_POST["answer3"]);
    $answer4 = mysqli_real_escape_string($conn, $_POST["answer4"]);
    $soulorder = mysqli_real_escape_string($conn, $_POST["soulorder"]);
    

    //Check are they empty?
    if($question != "" && $answer1 != "" && $answer2 != "" && $answer3 != ""  && $answer4 != "" && $soulorder != ""){
        
        //Check if the username has not taken
       
        if(mysqli_num_rows(mysqli_query($conn, "SELECT * FROM qstan WHERE question = '$question'")) == 0){
            mysqli_query($conn, "INSERT INTO qstan (question, answer1, answer2, answer3, answer4, soulorder) VALUES ('$question', '$answer1', '$answer2', '$answer3', '$answer4', '$soulorder')");
            $_SESSION["succs"]=" Data Insert Sucsefully";
            

        }else{
            $_SESSION["exist"]=" This Question is already exist ";
        }       
    }else{
        $_SESSION["rempiler"]=" Rempiler all field ";
    }

}
if(isset($_POST['cancel'])){
    
 header('location:test22.php');
}

 
?>

 
 <!DOCTYPE html>  
 <html> 
 

 <head >  
 
      <meta charset="utf-8">  
      
      <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
      <link rel="stylesheet" type="text/css" href="style.css">  
      <!-- Font Awsome -->
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" integrity="sha512-KfkfwYDsLkIlwQp6LFnl8zNdLGxu9YAA1QvwINks4PhcElQSvqcyVLLD9aMhXd13uQjoXtEKNosOWaZqXgel0g==" crossorigin="anonymous" referrerpolicy="no-referrer" />
      <script src="function validate().js"></script>

 
    </head>  
 <body > 
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script> <header></header>  

<nav class="navbar navbar-dark bg-dark fs-3 mb-5"><h1 style="color:white ;  " style="text-align : right">ADMIN SPACE</h1>
<script language="javascript">

function exit(form)
{


window.open("http://localhost/unityquiz/lgnfrm.html","_self")
}
</script>

<button style="text-align: left;" type="submit" class="btn btn-primary" value="logout" onclick="exit(this.form)">Log out</button>




</nav>

  </div>

<div style="text-align: right;">
<a  class="link-dark" ><i class="bi bi-box-arrow-right" class="link-dark"></i></a>
</div>
<?php
if(isset($_SESSION['succs'])){
?>
<div class="alert alert-success alert-dismissible">
  <strong>Well Done!</strong><?PHP echo  $_SESSION['succs'];?>
  
  </button>
</div>
<?php
  unset ($_SESSION['succs']);
}
    ?>



    <?php
if(isset($_SESSION['exist'])){
?>
<div class="alert alert-success alert-dismissible">
  <strong>OOps!</strong><?PHP echo  $_SESSION['exist'];?>
  
  </button>
</div>
<?php
  unset ($_SESSION['exist']);
}
    ?>



    <?php
if(isset($_SESSION['rempiler'])){
?>
<div  class="alert alert-warning alert-dismissible fade show">
  <strong>OOps!</strong><?PHP echo  $_SESSION['rempiler'];?>
  
  </button>
</div>
<?php
  unset ($_SESSION['rempiler']);
}
    ?>

<?php
if(isset($_SESSION['upd'])){
?>
<div  class="alert alert-success alert-dismissible">
  <strong>Well Done!</strong><?PHP echo  $_SESSION['upd'];?>
  
  </button>
</div>
<?php
  unset ($_SESSION['upd']);
}
    ?>

<?php
if(isset($_SESSION['dele'])){
?>
<div  class="alert alert-success alert-dismissible">
  <strong>Well Done!</strong><?PHP echo  $_SESSION['dele'];?>
  
  </button>
</div>
<?php
  unset ($_SESSION['dele']);
}
    ?>
    
    </div>
 
<div class ="container">
    <div class="text-center mb-4">
        <h3>Add New Question<h3>
            <p class="text-muted">Complet the form below </p>
            <div class="container d-flex justify-content-center">
                <form action="" method="POST" style="width:50vw; min-width:500px;">
            <div class="row mb-3">
                     <div class="col">
                        <label class="form-label d-flex justify-content-left">Question:</label>
                        <input type="text" class="form-control" name="question" style="word-break: break-all;" pattern="[A-Z,a-z,0-9,/,.,]{1}">
                   </div>
            </div>
            <div class="row mb-3">
                     <div class="col">
                        <label class="form-label d-flex justify-content-left">Answer1:</label>
                        <input type="text" class="form-control" name="answer1" pattern="[A-Z,a-z,0-9,/,.,]{1}">
                   </div>
                   <div class="col">
                        <label class="form-label d-flex justify-content-left">Anwser2:</label>
                        <input type="text" class="form-control" name="answer2" pattern="[A-Z,a-z,0-9,/,.,]{1}">
                   </div>
            </div>
            <div class="row mb-3">
                     <div class="col">
                        <label class="form-label d-flex justify-content-left">Answer3:</label>
                        <input type="text" class="form-control" name="answer3" pattern="[A-Z,a-z,0-9,/,.,]{1}">
                   </div>
                   <div class="col">
                        <label class="form-label d-flex justify-content-left">Answer4:</label>
                        <input type="text" class="form-control" name="answer4" pattern="[A-Z,a-z,0-9,/,.,]{1}">
                   </div>
                   
            </div>
            <div class="col" style="width:15vw; min-width:50px;">
                        <label class="form-label d-flex justify-content-left">Soul-Order:</label>
                        <input type="text" class="form-control" name="soulorder" required size="1"
           pattern="[0-4]{1}" title="1 number between 0 est 4">
                   </div>
                    
            <div>
<button type="submit" class="btn btn-success" name="submit" > ADD </button>
<button  href="http://localhost/unityquiz/login.html" type="submit" class="btn btn-danger" name="cancel" > Cancel </button>
            </div>
            
            </form>
           

            
    </div>
    </div>
    <table class="table table-hover text-left" style="table-layout:Fixed   ;">
  <thead class="table-dark">
    <tr>
      
      <th style="width:auto ;   overflow: hidden;" scope="col">ID</th>
      <th style="width:auto ;   overflow: hidden;" scope="col">Question</th>
      <th scope="col">Answer1</th>
      <th scope="col">Answer2</th>
      <th scope="col">Answer3</th>
      <th scope="col">Answer4</th>
      <th scope="col">Soultion order</th>
      <th scope="col">Operation</th>
    </tr>
  </thead>
  <tbody>
      <?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "quiz";

$conn1 = new mysqli($servername, $username, $password, $dbname);
$sql1 = "SELECT * FROM qstan";
	
	// Execute the query and store the result set
	$result1 = mysqli_query($conn1, $sql1);
    while($row=mysqli_fetch_assoc($result1)){
        ?>
  <tr style="overflow:hidden;
  word-wrap:break-word; width:900px" >
      <td ><?php echo $row['ID']?></td>
      <td style="overflow: hidden;"><?php echo $row['question']?></td>
      <td><?php echo $row['answer1']?></td>      
      <td><?php echo $row['answer2']?></td>      
      <td><?php echo $row['answer3']?></td> 
      <td><?php echo $row['answer4']?></td>
      <td><?php echo $row['soulorder']?></td>     
      <td> 
      <a href="EEdit.php?ID=<?php echo $row['ID']?>" class="link-dark" ><i class="fa-solid fa-pen fs-5 me-3"></i></a>
      <a href="delete.php?ID=<?php echo $row['ID']?>" class="link-dark" ><i class="fa-solid fa-trash fs-5 me-3"></i></a>
    
    </td>

    </tr>
    <?php
    }
    ?>
  </tbody>
</table>
 </body>  
 </html>  