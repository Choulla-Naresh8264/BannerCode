
function validate_fileds() {
//alert("hi");
    
  validator_ProfileFor();
    validate_name();
    //validate_date();
    validate_Gender();    
    validator_Religion();
    validator_MotherTongue();    
    validator_Caste();
    validator_Country();    
   phonenumber(); 
    validateEmail();
    validate_Pwd();  
   
    

}
function validate_name() {   // validate for name text box

    var str_name = document.getElementById("Txt_Name").value;
    if (str_name == "") {  // validate for empty
        alert("Please the Fill the name");
    }
    else if (!isNaN(str_name)) { // validate for numeric value
        alert("Numeric Values are not allowed");
    }
    else if (str_name.length > 7) { // validate for max char
        alert("Max 7 Value Are allowed");
    }
    else if (str_name.length > 0) { // validate for whitespace 
        //var spaces = '';
        for (var i = 0; i < str_name.length; i++) {
            var spaces = str_name[i];
            if (spaces == " ") {
                i = str_name.length;
                alert("Blank Spaces are not allowed");

            }

        }
    }
}


function validate_Pwd()
{

    

    var decimal = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
    if (decimal.test(Txt_Pwd.value) == false) 
    {

        alert("The Pwd Have to contain least one lowercase letter, one uppercase letter, one numeric digit, and one special character");
        return false;
    }


}



function validateEmail() {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

    if (reg.test(Txt_Mail.value) == false) 
    {
        alert('Invalid Email Address');
        return false;
    }



}

function validator_Religion() {

    if (document.getElementsByName("DDL_Religion").item(0).value == 0) {
        alert("Please select Religion");
        
        return false;
    }

}


function validator_MotherTongue() {
    if (DDL_MotherTongue[DDL_MotherTongue.selectedIndex].value == 0) {
        alert("Please select MotherTongue");
        return false;
    }

}


function validator_Country() {
    if (DDL_Country[DDL_Country.selectedIndex].value == 0) {
        alert("Please select Country");

        return false;
    }

}


function validator_Caste() {
    if (DDL_Caste[DDL_Caste.selectedIndex].value == 0) {
        alert("Please select Caste");

        return false;
    }

}

function validator_ProfileFor() {
    if (document.getElementsByName("DDl_ProfileFor").item(0).value == 0) {
        alert("Please select ProfileFor");

        return false;
    }

}

function phonenumber()  
{  
  var phoneno = /^\d{10}$/;  

  if (phoneno.test(Txt_Phoneno.value) == false) 


       {  
        alert("Not Valid Phone No");  
        return false;  
        }
}



function validate_Gender() {
    alert(11);
    var radios = document.getElementsByName("Gender");
    var j = 0;
    for (var i = 0; i < radios.length; i++) {
        if (radios.item(i).checked == false) {
            j++;
        }
       
    }

    if (j == radios.length) {
        alert("Please select the gender");
        return false;
    }
    else {
        return false;
    }
}


function validate_date() {
    var chkdate = document.getElementById("Txt_DOB").value;
    if (document.getElementById("Txt_DOB").value == "") {
        alert("Please enter the Date..!!")
        Txt_DOB.focus();
        return false;
    }
    else if (chkdate.match(/^(0[1-9]|[12][0-9]|3[01])[\- \/.](?:(0[1-9]|1[012])[\- \/.](201)[2-9]{1})$/)) {
        alert('date format is wrong');
        Txt_DOB.focus();
        return false;
    }
    else {
        return false;
    }
}
