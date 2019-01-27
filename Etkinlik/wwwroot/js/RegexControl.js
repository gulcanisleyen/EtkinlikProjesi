function regexEmail() {
    var email = document.getElementById("mailBox").value;
    var reg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (reg.test(String(email).toLowerCase()))
        document.getElementById("emailSpan").style.display = 'none';
    else
        document.getElementById("emailSpan").style.display = 'inline';
}

function regexName() {
    var fullName = document.getElementById("fullNameBox").value;
	var reg = /^[a-zA-Z]{5,25}\w*$/;
    if( reg.test(String(fullName)) )
        document.getElementById("fullNameSpan").style.display = ' none ';
    else
        document.getElementById("fullNameSpan").style.display = ' inline';
}

function regexPassword() {
    var password = document.getElementById("passwordBox").value;
	var reg = /^[a-zA-Z0-9]{5,25}\w*$/;
    if (reg.test(String(password)))
        document.getElementById("passwordSpan").style.display = ' none ';
    else
        document.getElementById("passwordSpan").style.display = ' inline';
}

function passwordAgain() {
    var password = document.getElementById("passwordBox").value;
    var password_again = document.getElementById("passwordAgainBox").value;
    if (password == password_again)
        document.getElementById("passwordAgainSpan").style.display = ' none ';
    else
        document.getElementById("passwordAgainSpan").style.display = ' inline';
}

