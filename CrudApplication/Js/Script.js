function FormValid() {
    var FName, LName, gender, Zip, Country, State, City,Pwd, ConfirmPwd, EmailId, emailExp,rb;
    var isChecked = false;
    FName = document.getElementById("txtFname").value;
    LName = document.getElementById("txtLname").value;
    rb = document.getElementById("RdBtnListGender");
    gender = rb.getElementsByTagName("input");
    EmailId = document.getElementById("txtEmail").value;
    Zip = document.getElementById("txtZip").value;
    Country = document.getElementById("DdlCountry").value;
    State = document.getElementById("DdlState").value;
    City = document.getElementById("DdlCity").value;
    Pwd = document.getElementById("txtPwd").value;
    ConfirmPwd = document.getElementById("txtConfirmPwd").value;
    emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id    

 if (FName == '' && LName == '' && EmailId == '' && Pwd == '' && ConfirmPwd == '' && Zip == '' && (Country == 'Select Country--') && State == '' && City == '')
    {
    alert("Enter All Required Fields first");
    return false;
}
 if (FName == '') {
    alert("Please Enter First Name");
    return false;
    }
 if (LName == '') {
        alert("Please Enter Last Name");
        return false;
    }
   
 for (var i = 0; i < gender.length; i++) {
        if (gender[i].checked) { 
        isChecked = true;
            break;
        }
    }
 if (!isChecked) {
        alert("Select any Gender");
        return isChecked;
    }
    
 if (EmailId == '') {
        alert("Email Id Is Required");
        return false;
    }
 if (EmailId != '') {
        if (!EmailId.match(emailExp)) {
            alert("Invalid Email Id");
            return false;
        }
    }
 if (Zip == '') {
        alert("Please Enter Zip Code");
        return false;
    }
    if (Country=='' || Country=='Select Country--') {
        alert("Please Enter Country");
        return false;
    }
    if (State == '' || State == 'Select State--') {
        alert("Please Enter State");
        return false;
    }
    if (City == '' || City =='Select City--') {
        alert("Please Enter City");
        return false;
    }
    if (Pwd == '') {
        alert("Please Enter Password");
        return false;
    }
    if (ConfirmPwd == '') {
        alert("Please Enter Confirm Password");
        return false;
    }
    if (Pwd != ConfirmPwd) {
        alert("\nPassword did not match: Please try again...")
        return false;
    }

return true;    
}


function userValid() {
    var UserName, Password;
    UserName = document.getElementById("txtUsername").value;
    Password = document.getElementById("txtUserpwd").value;
    if (UserName == '' && Password=='') {
        alert("Please Enter UserName and Password for Login");
        return false;
    }
    if (UserName == '') {
        alert("Please Enter UserName");
        return false;
    } 
    if (Password == '') {
        alert("Please Enter Password");
        return false;
    } 
}
function EmailValid() {
    var email;
    email = document.getElementById("txtresetEmail");
    if (email == '') {
        alert("Please Enter Registered Emailid to Reset Password");
        return false;
    }
}
function PasswordValid() {
    var newPwd, cnfmPwd;
    newPwd = document.getElementById("txtNewPwd").value;;
    cnfmPwd = document.getElementById("txtCnfmpwd").value;
    if (newPwd == '' && cnfmPwd=='') {
        alert("Please Enter Required fields");
        return false;
    }
    if (newPwd =='') {
        alert("Please Enter New Password");
        return false;
    }
    if (cnfmPwd == '') {
        alert("Please Enter Confirm Password");
        return false;
    }
    if (newPwd != cnfmPwd) {
        alert("\nPassword did not match: Please try again...")
        return false;
    }
    return true; 
}


