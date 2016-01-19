function sortLetters(string, reversed) {
    var output = [];
    for(var i = 0; i < string.length; i++) {
        var char = string.charAt(i);
        if(isLetter(char)) {
            output.push(char);
        }
    }

    output.sort(function(a, b) {
        return a.toLowerCase() >= b.toLowerCase();
    });

    if(!reversed) {
        output.reverse();
    }

    return output.join('');
}

function isLetter(str) {
    return str.length === 1 && str.match(/[a-z]/i);
}

console.log(sortLetters('HelloWorld', false));