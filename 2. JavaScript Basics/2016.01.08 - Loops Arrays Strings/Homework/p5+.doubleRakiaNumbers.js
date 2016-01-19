function solve(arr) {
    function countInstances(number, part) {
        number = number.toString();
        part = part.toString();
        var initLength = number.length;
        number = number.replace(new RegExp(part, 'g'), '');
        return (initLength - number.length) / part.length;
    }
    var start = arr[0];
    var end = arr[1];
    var output = [];
    output[0] = '<ul>';
    for(var i = start; i <= end; i++) {
        var isRakiaNumber = false;
        var numAsString = i.toString();
        for(var j = 0; j < numAsString.length; j++) {
            if(countInstances(i, numAsString.substr(j, 2)) == 2) {
                isRakiaNumber = true;
                break;
            }
        }

        if(isRakiaNumber) {
            output[i - start + 1] = "\<li><span class='rakiya'>" + i +
              "\</span><a href=\"view.php?id=" + i + "\"\>View</a></li>";
        } else {
            output[i - start + 1] = "\<li><span class='num'>" + i + "\</span></li>";
        }
    }

    output[output.length] = "\</ul>";
    for (var i = 0; i < output.length; i++) {
        console.log(output[i]);
    }
}

var arr = [11210, 11215];
solve(arr);


