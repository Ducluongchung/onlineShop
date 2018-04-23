var user = document.getElementById('username');
var password = document.getElementById('password');
var UserID = 'admin';
var PassW='123'

var formLogin = document.getElementById('Login')
if (formLogin.attachEvent) {
    formLogin.attachEvent('submit', Formsubmit);
}
else {
    formLogin.addEventListener('submit', Formsubmit);
}

function Formsubmit(e){
    var user = user.value;
    var password = password.value;
    if (user == UserID && password == PassW) {
        alert('Dang Nhap thaanh cong');
    }
    else {
        alert('Dang Nhap thaanh cong');
    }
}