function solve(arr) {
    function findTriangle(row, col, array) {
        var currentChar = array[row].charAt(col);
        if(array[row + 1].substr(col - 1, 3) ===
            currentChar + currentChar + currentChar) {
            return true;
        } else {
            return false;
        }
    }

    function traverseArray(arr) {
        var triangleMap = [];
        var counter = 0;
        for (var row = 0; row < arr.length - 1; row++) {
            for (var col = 1; col < arr[row].length; col++) {
                var formsTriangle = findTriangle(row, col, arr);
                if(formsTriangle) {
                    triangleMap[counter] = ([row, col]);
                    counter++;
                }
            }
        }
        return triangleMap;
    }

    function fillTriangles(coordinates, array) {
        var triangleChar = '*';
        for (var i = 0; i < coordinates.length; i++) {
            var row = coordinates[i][0];
            var col = coordinates[i][1];
            array[row] = array[row].substr(0, col) +
                triangleChar + array[row].substr(col + 1, array[row].length);

            var pre = array[row + 1].substr(0, col - 1);
            var triangle = triangleChar + triangleChar + triangleChar;
            var post = array[row + 1].substr(col + 2, array[row + 1].length);

            array[row + 1] = pre + triangle + post;
        }
        return array.join('\n');
    }

    var arrayMap = traverseArray(arr);
    return fillTriangles(arrayMap, arr);
}

//var arr = ['abcdexgh', 'bbbdxxxh', 'abcxxxxx'];
//solve(arr);