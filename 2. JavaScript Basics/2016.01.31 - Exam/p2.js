function solve(arr) {
    var iter = Number(arr[arr.length - 1]);
    var array = [];
    for (var i = 0; i < arr.length - 1; i++) {
        var line = arr[i].split(' ');
        for (var j = 0; j < line.length; j++) {
            array.push(line[j]);
        }

        if(i < arr[i].length - 2) {
            array.push('|');
        }
    }

    var counter = 1;
    for (var y = 1; y < array.length; y++) {
        if(array[y] == array[y-1]) {
            counter++;
            if(counter == iter) {
                array.splice(y - iter + 1, iter);
                counter = 1;
            }
        } else if(array[y] == '|' &&
            ((y < array.length - 2) && array[y + 1] == array[y - 1])) {
            counter++;
            if(counter == iter) {
                array.splice(y - iter + 1, iter + 1);
                counter = 1;
            }
        } else {
            counter = 1;
        }

    }

    for (var i = 0; i < array.length; i++) {
        var out = '';
        if(array[i].match(/\|/g)) {
            out += array[i];
        } else {
            console.log(out);
        }
    }
}

//var input = [
//    '3 3 3 2 5 9 9 9 9 1 2',
//    '1 1 1 1 1 2 5 8 1 1 7 7',
//    '7 1 2 3 5 7 4 4 1 2',
//    '2'];

var input = [
    '1 2 3 3',
    '3 5 7 8',
    '3 2 2 1',
    '3'];
solve(input);