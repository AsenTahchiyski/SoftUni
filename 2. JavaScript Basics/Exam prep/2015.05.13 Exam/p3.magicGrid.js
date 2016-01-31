function solve(arr) {
    var encrypted = arr[0];
    var magicNum = Number(arr[1]);
    var matrix = [];
    for(var i = 2; i < arr.length; i++) {
        var line = arr[i].split(' ');
        var lineNums = [];
        line.forEach(function(n) {
            lineNums.push(Number(n));
        });
        matrix[i - 2] = lineNums;
    }

    var number1row, number1col, number2row, number2col;
    var result = getMagicNumbersCoord(matrix, magicNum);
    number1row = result.firstNum[0];
    number1col = result.firstNum[1];
    number2row = result.secondNum[0];
    number2col = result.secondNum[1];

    var key = number1row + number1col + number2row + number2col;

    var charArr = encrypted.split('');
    for(var j = 0; j < charArr.length; j++) {
        var asciiCode = charArr[j].charCodeAt(0);
        if(j % 2 == 0) {
            asciiCode += key;
        } else {
            asciiCode -= key;
        }

        charArr[j] = String.fromCharCode(asciiCode);
    }

    function getMagicNumbersCoord(matrix, magicNum) {
        var resultObj = {};
        for(var row = 0; row < matrix.length; row++) {
            for(var col = 0; col < matrix[row].length; col++) {
                var number1 = matrix[row][col];
                for(var rowIn = 0; rowIn < matrix.length; rowIn++) {
                    for(var colIn = 0; colIn < matrix[rowIn].length; colIn++) {
                        if(row != rowIn || col != colIn) {
                            var number2 = matrix[rowIn][colIn];
                            if(number1 + number2 == magicNum) {
                                resultObj.firstNum = [row, col];
                                resultObj.secondNum = [rowIn, colIn];
                                return resultObj;
                            }
                        }
                    }
                }
            }
        }

        return false;
    }

    console.log(charArr.join(''));
}

var input = [
    'QqdvSpg',
    400,
    '100 200 120',
    '120 300 310',
    '150 290 370'];
solve(input);