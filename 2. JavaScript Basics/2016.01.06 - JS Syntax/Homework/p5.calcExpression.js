function calcExpression() {
    var result = eval(document.getElementById('input').value);
    document.getElementById('result').innerHTML = result;
}