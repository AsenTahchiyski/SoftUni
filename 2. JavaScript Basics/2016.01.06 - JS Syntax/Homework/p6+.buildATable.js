function solve(arr) {
    function fibCheck(number) {
        var previous = 0;
        var current = 1;
        while(previous<=number) {
            if(previous == number) {
                return true;
            }
            current = previous + current;
            previous = current - previous;
        }
        return false;
    }

    var start = arr[0];
    var end = arr[1];
    var output = '<table>\n' + '<tr><th>Num</th><th>Square</th><th>Fib</th></tr>\n';
    for(var i = start; i <= end; i++) {
        var fibonacci = fibCheck(+i) === true ? 'yes' : 'no';
        output += '<tr><td>' + i + '</td><td>' + (i * i) +
            '</td><td>' + fibonacci + '</td></tr>\n';
    }
    output += '</table>';
    console.log(output);
    //return output;
}

solve([5, 10]);