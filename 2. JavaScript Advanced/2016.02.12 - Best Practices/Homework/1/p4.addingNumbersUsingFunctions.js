"use strict";
function add(num) {
    var sum = num;

    function addMore(more) {
        sum += more;
        return addMore;
    }

    addMore.toString = function(){return sum};
    return addMore;
}

console.log(add(1).toString());
console.log(add(2)(3).toString());
console.log(add(1)(1)(1)(1)(1).toString());
console.log(add(1)(0)(-1)(-1).toString());

var addTwo = add(2);
console.log(addTwo.toString());
var addTwo = add(2);
console.log(addTwo(3).toString());
var addTwo = add(2);
console.log(addTwo(3)(5).toString());
