"use strict";
Array.prototype.flatten = function() {
    var result = [];
    function traverse(arr) {
        if(arr) {
            for (var i = 0; i < arr.length; i++) {
                var element = arr[i];
                if(Array.isArray(element)) {
                    traverse(element);
                } else {
                    result.push(element);
                }
            }
        }
    }

    traverse(this);
    return result;
};

//var array = [1, 2, 3, 4];
//console.log(array.flatten());

//var array = [1, 2, [3, 4], [5, 6]];
//console.log(array.flatten());
//console.log(array); // Not changed

var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());