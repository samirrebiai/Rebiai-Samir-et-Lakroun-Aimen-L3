function validate()
{
var username=document.getElementsByID("username").value;
var password=document.getElementsByID("password").value;
if(username=="admin" && password=="admin"){
    window.location.href="http://localhost/unityquiz/lgnfrm.html";
    
alert("login sucssufly");
return false;
}
else {
    alert("login failed");
}

}
function exit()
{    window.location.href="http://localhost/unityquiz/test22.php";
}