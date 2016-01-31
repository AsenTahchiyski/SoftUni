function solve(arr) {
    var col = -1;
    var row = 0;

    function containCount(char, string) {
        var counter = 0;
        for (var i = 0; i < string.length; i++) {
            if (String(string).charAt(i) === char) {
                counter++;
            }
        }

        return counter;
    }

    var finished = false;
    arr.forEach(function (line) {
        if(!finished) {
            if (col == -1 && line.indexOf('o') >= 0) {
                col = line.indexOf('o');
            }

            var directionChange = 0;
            if (row > 0 && col >= 0) {
                if (line.indexOf('>') >= 0) {
                    directionChange += containCount('>', line);
                }

                if (line.indexOf('<') >= 0) {
                    directionChange -= containCount('<', line);
                }

                row++;
                col += directionChange;

                if (line.charAt(col) === '\\' || line.charAt(col) === '/' || line.charAt(col) === '|') {
                    console.log("Got smacked on the rock like a dog!");
                    finished = true;
                } else if (line.charAt(col) === '_') {
                    console.log("Landed on the ground like a boss!");
                    finished = true;
                } else if (line.charAt(col) === '~') {
                    console.log("Drowned in the water like a cat!");
                    finished = true;
                }
            } else {
                row++;
            }
        }
    });

    console.log(row - 1 + ' ' + col);
}

//var input = [
//    '--o----------------------',
//    '>------------------------',
//    '>------------------------',
//    '>-----------------/\\-----',
//    '-----------------/--\\----',
//    '>---------/\\----/----\\---',
//    '---------/--\\--/------\\--',
//    '<-------/----\\/--------\\-',
//    '\\------/----------------\\',
//    '-\\____/------------------'];

//var input = [
//    '-------------o-<<--------',
//    '-------->>>>>------------',
//    '---------------->-<---<--',
//    '------<<<<<-------/\\--<--',
//    '--------------<--/-<\\----',
//    '>>--------/\\----/<-<-\\---',
//    '---------/<-\\--/------\\--',
//    '<-------/----\\/--------\\-',
//    '\\------/--------------<-\\',
//    '-\\___~/------<-----------'];

var input = [
    '>>>>>>>>>>>o<<<<<<<<<<<<<',
    '----------~~~------------',
    '--------~/~~~\\~----------',
    '-------~/~---~\\~---------',
    '------~/~-----~\\~--------',
    '-----~/~-------~\\~-------',
    '----~/~---------~\\~------',
    '---~/~-----------~\\~-----',
    '--~/~-------------~\\~----',
    '-~/~---------------~\\~---'
];

solve(input);