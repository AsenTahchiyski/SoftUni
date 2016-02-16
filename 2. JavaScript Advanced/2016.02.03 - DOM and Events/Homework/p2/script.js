function validate() {
    var button = document.getElementsByTagName('button')[0];
    var validationField = document.getElementById('validation');
    var inputStr = document.getElementById('email').value;
    var regex = /^\w[\w\d_-]+@\w[\w\d_-]+\.\w{2,4}$/g;
    validationField.style.width = '173px';
    if (regex.exec(inputStr)) {
        validationField.style.backgroundColor = 'lightgreen';
    } else {
        validationField.style.backgroundColor = 'red';
    }

    validationField.innerText = inputStr;
}